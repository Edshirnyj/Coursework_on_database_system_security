-- [PostgreSQL] Cоздание базу данных car_for_sale с кодировкой UTF-8 и локалью ru_RU.UTF-8
CREATE DATABASE car_for_sale
    WITH OWNER = postgres
    TEMPLATE = template0
    ENCODING = 'UTF8'
    LC_COLLATE = 'ru_RU.UTF-8'
    LC_CTYPE = 'ru_RU.UTF-8'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;