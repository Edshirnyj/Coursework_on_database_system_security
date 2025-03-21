/*
1. AddNewClient  
   Добавление нового клиента.  
   Регистрирует клиента, проводит валидацию вводимых данных и присваивает уникальный идентификатор.
*/
CREATE OR REPLACE PROCEDURE AddNewClient(
    IN first_name VARCHAR(255),
    IN second_name VARCHAR(255),
    IN third_name VARCHAR(255),
    IN phone BYTEA,
    IN email BYTEA,
    IN passport_number BYTEA, -- Encrypted passport number
    IN passport_session BYTEA, -- Encrypted session
    IN country_name VARCHAR(255) DEFAULT 'Российская Федерация',
    IN city_name VARCHAR(255) DEFAULT 'Москва'
)
LANGUAGE plpgsql
AS $$
DECLARE
    existing_passport UUID;
    existing_locality UUID;
    existing_citizen UUID;
BEGIN
    -- Validate input data
    IF first_name IS NULL OR second_name IS NULL OR third_name IS NULL THEN
        RAISE EXCEPTION 'Name fields cannot be null';
    END IF;

    IF octet_length(phone) = 0 THEN
        RAISE EXCEPTION 'Phone cannot be empty';
    END IF;

    IF octet_length(email) = 0 THEN
        RAISE EXCEPTION 'Email cannot be empty';
    END IF;

    IF octet_length(passport_number) = 0 OR octet_length(passport_session) = 0 THEN
        RAISE EXCEPTION 'Passport data cannot be empty';
    END IF;

    -- Ensure the locality exists
    SELECT locality_id INTO existing_locality
    FROM localities
    WHERE name = country_name;

    IF existing_locality IS NULL THEN
        INSERT INTO localities(name)
        VALUES (country_name)
        RETURNING locality_id INTO existing_locality;
    END IF;

    -- Ensure the citizen exists
    SELECT citizen_id INTO existing_citizen
    FROM citizens
    WHERE name = city_name AND locality_id = existing_locality;

    IF existing_citizen IS NULL THEN
        INSERT INTO citizens(name, locality_id)
        VALUES (city_name, existing_locality)
        RETURNING citizen_id INTO existing_citizen;
    END IF;

    -- Check if passport already exists
    SELECT passport_id INTO existing_passport
    FROM passports
    WHERE number = passport_number AND session = passport_session;

    IF existing_passport IS NOT NULL THEN
        RAISE NOTICE 'This user already exists with passport_id: %', existing_passport;
        RETURN;
    END IF;

    -- Insert new passport
    INSERT INTO passports(number, session, citizen_id)
    VALUES (passport_number, passport_session, existing_citizen)
    RETURNING passport_id INTO existing_passport;

    -- Insert new client
    INSERT INTO clients(first_name, second_name, third_name, phone, email, passport_id)
    VALUES (first_name, second_name, third_name, phone, email, existing_passport);
END;
$$;
/*
Вызов:
CALL AddNewClient('John', 'Doe', 'Smith',
    pgp_sym_encrypt('1234567890', 'key'),
    pgp_sym_encrypt('john.doe@example.com', 'key'),
    pgp_sym_encrypt('AB1234567', 'key'),
    pgp_sym_encrypt('session_data', 'key'),
    "United States", "New York"
);
*/

/*
2. UpdateClientDetails  
   Обновление информации о клиенте.  
   Изменяет контактные и персональные данные, проводит проверку корректности обновлений.
*/
CREATE OR REPLACE PROCEDURE UpdateClientDetails(
    IN u_client_id UUID,
    IN u_first_name VARCHAR(255),
    IN u_second_name VARCHAR(255),
    IN u_third_name VARCHAR(255),
    IN u_phone BYTEA,
    IN u_email BYTEA,
    IN u_passport_number BYTEA,
    IN u_passport_session BYTEA
)
LANGUAGE plpgsql
AS $$
DECLARE
    existing_passport UUID;
BEGIN
    -- Validate input data
    IF u_first_name IS NULL OR u_second_name IS NULL OR u_third_name IS NULL THEN
        RAISE EXCEPTION 'Name fields cannot be null';
    END IF;

    IF octet_length(u_phone) = 0 THEN
        RAISE EXCEPTION 'Phone cannot be empty';
    END IF;

    IF octet_length(u_email) = 0 THEN
        RAISE EXCEPTION 'Email cannot be empty';
    END IF;

    IF octet_length(u_passport_number) = 0 OR octet_length(u_passport_session) = 0 THEN
        RAISE EXCEPTION 'Passport data cannot be empty';
    END IF;

    -- Check if the client exists
    IF NOT EXISTS (
        SELECT 1 FROM clients
        WHERE client_id = u_client_id
    ) THEN
        RAISE EXCEPTION 'Client with ID % does not exist', u_client_id;
    END IF;

    -- Check if the passport already exists and belongs to another client
    SELECT passport_id INTO existing_passport
    FROM passports
    WHERE number = u_passport_number 
      AND session = u_passport_session 
      AND citizen_id != (
          SELECT citizen_id FROM clients WHERE client_id = u_client_id
      );

    IF existing_passport IS NOT NULL THEN
        RAISE EXCEPTION 'Passport data already exists for another client';
    END IF;

    -- Update passport details
    UPDATE passports
    SET number = u_passport_number,
        session = u_passport_session
    WHERE passport_id = (
        SELECT passport_id FROM clients WHERE client_id = u_client_id
    );

    -- Update client details
    UPDATE clients
    SET first_name = u_first_name,
        second_name = u_second_name,
        third_name = u_third_name,
        phone = u_phone,
        email = u_email
    WHERE client_id = u_client_id;
END;
$$;
/*
Вызов:
CALL UpdateClientDetails('uuid', 'John', 'Doe', 'Smith',
    pgp_sym_encrypt('1234567890', 'key'),
    pgp_sym_encrypt('john.doe@example.com', 'key'),
    pgp_sym_encrypt('AB1234567', 'key'),
    pgp_sym_encrypt('session_data', 'key'),
);
*/

/*
3. DeleteClientAccount  
   Удаление клиента из базы. 
   Проверяет связанные продажи и контракты перед удалением записи клиента, обеспечивая целостность данных.
*/
CREATE OR REPLACE PROCEDURE DeleteClientAccount(
    IN d_client_id UUID
)
LANGUAGE plpgsql
AS $$
DECLARE
    client_passport_id UUID;
BEGIN
    -- Check if the client exists
    IF NOT EXISTS (
        SELECT 1 FROM clients
        WHERE client_id = d_client_id
    ) THEN
        RAISE EXCEPTION 'Client with ID % does not exist', d_client_id;
    END IF;

    -- Retrieve the passport ID associated with the client
    SELECT passport_id INTO client_passport_id
    FROM clients
    WHERE client_id = d_client_id;

    -- Update related history_transforms to set client_id to NULL
    UPDATE history_transforms
    SET client_id = NULL
    WHERE client_id = d_client_id;

    -- Update related test_drives to set client_id to NULL
    UPDATE test_drives
    SET client_id = NULL
    WHERE client_id = d_client_id;

    -- Delete the client record
    DELETE FROM clients
    WHERE client_id = d_client_id;

    -- Delete the associated passport record
    DELETE FROM passports
    WHERE passport_id = client_passport_id;
END;
$$;
/*
Вывод:
CALL DeleteClientAccount('uuid');
*/


/*
4. AddNewCar  
   Регистрация нового автомобиля в инвентаре.  
   Вносит информацию о транспортном средстве (марка, год, пробег, VIN и т.д.) с проверками на уникальность.
*/
CREATE OR REPLACE PROCEDURE AddNewCar(
    IN brand_name VARCHAR(255),
    IN model_name VARCHAR(255),
    IN year INTEGER,
    IN mileage INTEGER,
    IN a_vin BYTEA,
    IN continent_name VARCHAR(255) DEFAULT 'Неизвестно',
    IN status_name VARCHAR(255) DEFAULT 'В обработке'
)
LANGUAGE plpgsql
AS $$
DECLARE
    existing_continent UUID;
    existing_brand UUID;
    existing_model UUID;
    existing_status UUID;
    existing_auto UUID;
    final_status_name VARCHAR(255);
    final_mileage INTEGER;
BEGIN
    -- Validate input data
    IF brand_name IS NULL OR model_name IS NULL OR a_vin IS NULL THEN
        RAISE EXCEPTION 'Brand, model, and VIN cannot be null';
    END IF;

    IF year < 1886 THEN
        RAISE EXCEPTION 'Year must be 1886 or later';
    END IF;

    IF year > EXTRACT(YEAR FROM CURRENT_DATE) THEN
        RAISE EXCEPTION 'Year cannot be in the future';
    END IF;

    IF mileage < 0 THEN
        RAISE EXCEPTION 'Mileage cannot be negative';
    END IF;

    IF mileage > 1000000 THEN
        RAISE EXCEPTION 'This car is not considered operational';
    END IF;

    -- Set final mileage and status
    IF mileage = 0 THEN
        final_mileage := 0;
        final_status_name := 'Новый';
    ELSE
        final_mileage := mileage;
        final_status_name := status_name;
    END IF;

    -- Ensure the continent exists
    SELECT continent_id INTO existing_continent
    FROM continents
    WHERE name = continent_name;

    IF existing_continent IS NULL THEN
        INSERT INTO continents(name)
        VALUES (continent_name)
        RETURNING continent_id INTO existing_continent;
    END IF;

    -- Ensure the brand exists
    SELECT brand_id INTO existing_brand
    FROM brands
    WHERE name = brand_name AND continent_id = existing_continent;

    IF existing_brand IS NULL THEN
        INSERT INTO brands(name, continent_id)
        VALUES (brand_name, existing_continent)
        RETURNING brand_id INTO existing_brand;
    END IF;

    -- Ensure the model exists
    SELECT model_id INTO existing_model
    FROM models
    WHERE name = model_name AND brand_id = existing_brand;

    IF existing_model IS NULL THEN
        INSERT INTO models(name, brand_id)
        VALUES (model_name, existing_brand)
        RETURNING model_id INTO existing_model;
    END IF;

    -- Ensure the status exists
    SELECT status_id INTO existing_status
    FROM statuses
    WHERE name = final_status_name;

    IF existing_status IS NULL THEN
        INSERT INTO statuses(name)
        VALUES (final_status_name)
        RETURNING status_id INTO existing_status;
    END IF;

    -- Check if the car already exists
    SELECT auto_id INTO existing_auto
    FROM autos
    WHERE vin = a_vin;

    IF existing_auto IS NOT NULL THEN
        RAISE NOTICE 'This car already exists with auto_id: %', existing_auto;
        RETURN;
    END IF;

    -- Insert new car
    INSERT INTO autos(model_id, year, vin, mileage, status_id)
    VALUES (existing_model, year, a_vin, final_mileage, existing_status);
END;
$$;
/*
Вызов:
CALL AddNewCar('Toyota', 'Camry', 2021, 0, pgp_sym_encrypt('4T1BF1FK0GU572575', 'Key'), 'Япония');
*/


/*
5. UpdateCarInfo  
   Обновление сведений об автомобиле.  
   Позволяет корректировать характеристики авто, например, изменения статуса, пробега или косметических деталей.
*/
CREATE OR REPLACE PROCEDURE UpdateCarInfo(
    IN p_auto_id UUID,
    IN new_status_name VARCHAR(255),
    IN new_mileage INTEGER DEFAULT NULL,
    IN new_vin BYTEA DEFAULT NULL
)
LANGUAGE plpgsql
AS $$
DECLARE
    existing_status UUID;
    final_status_name VARCHAR(255);
BEGIN
    -- Validate input data
    IF p_auto_id IS NULL THEN
        RAISE EXCEPTION 'Auto ID cannot be null';
    END IF;

    IF new_mileage IS NOT NULL AND new_mileage < 0 THEN
        RAISE EXCEPTION 'Mileage cannot be negative';
    END IF;

    IF new_mileage IS NOT NULL AND new_mileage > 1000000 THEN
        RAISE EXCEPTION 'This car is not considered operational';
    END IF;

    -- Determine final status name
    IF new_mileage = 0 AND new_status_name IS NULL THEN
        final_status_name := 'Новый';
    ELSE
        final_status_name := new_status_name;
    END IF;

    -- Ensure the status exists
    SELECT status_id INTO existing_status
    FROM statuses
    WHERE name = final_status_name;

    IF existing_status IS NULL THEN
        INSERT INTO statuses(name)
        VALUES (final_status_name)
        RETURNING status_id INTO existing_status;
    END IF;

    -- Update car information
    UPDATE autos
    SET status_id = existing_status,
        mileage = COALESCE(new_mileage, mileage),
        vin = COALESCE(new_vin, vin)
    WHERE auto_id = p_auto_id;

    IF NOT FOUND THEN
        RAISE EXCEPTION 'Car with auto_id % does not exist', p_auto_id;
    END IF;
END;
$$;
/*
Вызов:
CALL UpdateCarInfo('uuid', 'Ремонт', 3000, pgp_sym_encrypt('4T1BF1F43GU572575', 'Key'))
*/



/*
6. RemoveCarFromInventory  
   Удаление автомобиля из инвентаря.  
   Выполняется при продаже или списании автомобиля, включая проверку связанных сделок.
*/
CREATE OR REPLACE PROCEDURE RemoveCarFromInventory(
    IN p_auto_id UUID
)
LANGUAGE plpgsql
AS $$
BEGIN
    -- Validate input data
    IF p_auto_id IS NULL THEN
        RAISE EXCEPTION 'Auto ID cannot be null';
    END IF;

    -- Delete the car from the inventory
    DELETE FROM autos
    WHERE auto_id = p_auto_id;

    IF NOT FOUND THEN
        RAISE EXCEPTION 'Car with auto_id % does not exist', p_auto_id;
    END IF;
END;
$$;
/*
Вызов:
CALL RemoveCarFromInventory('uuid');
*/

/*
7. CreateSaleContract  
   Создание нового контракта продажи.
   Фиксирует условия сделки между продавцом, клиентом и выбранным автомобилем, связывая их посредством внешних ключей.
*/


/*
8. UpdateSaleContract
   Изменение деталей контракта продажи.
   Позволяет корректировать цену, условия оплаты или другие параметры сделки.
*/



/*
9. CancelSaleContract 
   Отмена заключённого контракта продажи. 
   Проводит процедуру отмены сделки с последующим обновлением статуса автомобиля и клиента.
*/



/*
10. LogTestDriveBooking
    Регистрация бронирования тест-драйва.  
    Добавляет запись о назначенном тест-драйве с привязкой к клиенту и автомобилю.
*/



/*
11. UpdateTestDriveDetails
    Изменение параметров бронирования тест-драйва.  
    Обновляет дату, время и комментарии, соблюдая доступность выбранного автомобиля и клиента.
*/



/*
12. RemoveTestDriveBooking
    Отмена записи о тест-драйве.  
    Удаляет бронирование с последующим уведомлением заинтересованных сторон.
*/



/*
13. AddWorkerRecord  
    Добавление нового сотрудника.  
    Регистрирует нового сотрудника (продавца, менеджера, техника) с присвоением ролей и прав доступа.
*/


/*
14. UpdateWorkerDetails
    Обновление информации о сотруднике.
    Изменяет контактные данные, должность или статус сотрудника.
*/



/*
15. DeleteWorkerRecord 
    Удаление сотрудника из базы. 
    Прорабатывается с проверкой на наличие незавершённых операций или связанных контрактов.
*/



/*
16. RecordPaymentTransaction 
    Регистрация платёжной операции.  
    Фиксирует данные о платеже по контракту, сверяя суммы и способы оплаты.
*/



/*
17. UpdatePaymentStatus 
    Обновление статуса платежа.
    Изменяет состояние платежа (ожидание, подтверждение, отказ) с соответствующей обработкой бизнес-правил.
*/



/*
18. RefundPayment 
    Возврат средств клиенту.
    Инициирует процедуру возврата денег по отменённой сделке и корректирует финансовую отчётность.
*/



/*
19. ScheduleMaintenance  
    Планирование обслуживания автомобиля. 
    Регистрирует заказы на ТО или ремонт с привязкой к конкретному авто и клиенту.
*/


/*
20. UpdateMaintenanceRecord 
    Обновление данных по обслуживанию.
    Вносит изменения в записи сервиса: дату, вид ремонта, затраты и комментарии техников.
*/



/*
21. DeleteMaintenanceRecord 
    Удаление устаревших или ошибочных данных по обслуживанию. 
    Удаляет записи, которые больше не соответствуют действительности, сохраняя историю изменений.
*/



/*
22. GenerateInventoryReport 
    Формирование отчёта по наличию автомобилей. 
    Составляет свод данных по статусу каждого авто, количеству моделей и состоянию инвентаря.
*/



/*
23. GenerateSalesReport
    Создание отчёта по продажам за период.
    Объединяет данные по контрактам, платежам и сотрудникам для анализа динамики продаж.
*/



/*
24. AuditTrailManagement  
    Ведение журнала аудита изменений в базе данных. 
    Логирует все ключевые операции (вставка, обновление, удаление) для обеспечения прозрачности и отладки.
*/



/*
25. ReconcileFinancialRecords 
    Сверка финансовых операций. 
    Сравнивает данные платежей, контрактов и бухгалтерских записей для выявления и устранения несоответствий.
*/