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
2. UpdateCustomerDetails  
   Обновление информации о клиенте.  
   Изменяет контактные и персональные данные, проводит проверку корректности обновлений.
*/


/*
3. DeleteCustomerAccount  
   Удаление клиента из базы. 
   Проверяет связанные продажи и контракты перед удалением записи клиента, обеспечивая целостность данных.
*/


/*
4. AddNewCar  
   Регистрация нового автомобиля в инвентаре.  
   Вносит информацию о транспортном средстве (марка, год, пробег, VIN и т.д.) с проверками на уникальность.
*/



/*
5. UpdateCarInfo  
   Обновление сведений об автомобиле.  
   Позволяет корректировать характеристики авто, например, изменения статуса, пробега или косметических деталей.
*/


/*
6. RemoveCarFromInventory  
   Удаление автомобиля из инвентаря.  
   Выполняется при продаже или списании автомобиля, включая проверку связанных сделок.
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
13. AddEmployeeRecord  
    Добавление нового сотрудника.  
    Регистрирует нового сотрудника (продавца, менеджера, техника) с присвоением ролей и прав доступа.
*/



/*
14. UpdateEmployeeDetails
    Обновление информации о сотруднике.
    Изменяет контактные данные, должность или статус сотрудника.
*/



/*
15. DeleteEmployeeRecord 
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