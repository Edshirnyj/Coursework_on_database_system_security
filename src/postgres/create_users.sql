-- [PostgreSQL] Создание пользователей и ролей для базы данных car_for_sale

CREATE ROLE admin_cfs WITH LOGIN PASSWORD 'cfsisgreat';
GRANT ALL PRIVILEGES ON DATABASE car_for_sales TO admin_cfs;

CREATE ROLE mechanic_cfs WITH LOGIN PASSWORD 'imrepaircars';
GRANT SELECT, INSERT, UPDATE, DELETE ON repairs TO mechanic_cfs;
GRANT SELECT, INSERT, UPDATE, DELETE ON details TO mechanic_cfs;
GRANT SELECT, UPDATE ON mechanics TO mechanic_cfs;
GRANT SELECT ON profile_mechanics TO mechanic_cfs;
GRANT SELECT, UPDATE ON autos TO mechanic_cfs;

CREATE ROLE salesman_cfs WITH LOGIN PASSWORD 'isellcars';
GRANT SELECT, UPDATE ON salesmans TO salesman_cfs;
GRANT SELECT ON profile_salesmans TO salesman_cfs;
GRANT SELECT, INSERT, UPDATE ON history_transforms TO salesman_cfs;
GRANT SELECT, INSERT, UPDATE, DELETE ON contracts TO salesman_cfs;
GRANT SELECT, INSERT ON trades TO salesman_cfs;
GRANT SELECT, INSERT, UPDATE ON test_drives TO salesman_cfs;
GRANT SELECT, INSERT, UPDATE, DELETE ON autos TO salesman_cfs;

CREATE ROLE client_cfs WITH LOGIN;
GRANT SELECT, UPDATE ON clients TO client_cfs;
GRANT SELECT, UPDATE, DELETE ON profile_clients TO client_cfs;
GRANT SELECT, UPDATE ON passports TO client_cfs;
GRANT SELECT, INSERT, UPDATE, DELETE ON autos TO client_cfs;
GRANT SELECT, INSERT, UPDATE, DELETE ON desireds TO client_cfs;
GRANT INSERT ON test_drives TO client_cfs;
GRANT SELECT ON brands TO client_cfs;
GRANT SELECT ON models TO client_cfs;


CREATE ROLE guest_cfs WITH LOGIN;
GRANT SELECT, INSERT ON clients TO guest_cfs;
GRANT SELECT, INSERT ON profile_clients TO guest_cfs;
GRANT INSERT ON passports TO guest_cfs;
GRANT SELECT ON autos TO guest_cfs;
GRANT SELECT ON brands TO guest_cfs;
GRANT SELECT ON models TO guest_cfs;

