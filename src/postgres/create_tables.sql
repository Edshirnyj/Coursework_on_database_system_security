-- [PostgreSQL] Создание таблиц базы данных car_for_sale с учетом стандартов информационной безопасности

CREATE EXTENSION IF NOT EXISTS pgcrypto;
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE IF NOT EXISTS positions
(
    position_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    name VARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS salesmans
(
    salesman_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    name VARCHAR(255) NOT NULL,
    surname VARCHAR(255) NOT NULL,
    patronymic VARCHAR(255) NOT NULL,
    position_id UUID NOT NULL,

    FOREIGN KEY (position_id) REFERENCES positions(position_id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS profile_salesmans
(
    profile_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    salesman_id UUID NOT NULL,
    e_mail BYTEA NOT NULL UNIQUE CHECK (octet_length(e_mail) > 0),
    phone BYTEA NOT NULL UNIQUE CHECK (octet_length(phone) > 0),
    username VARCHAR(255) NOT NULL UNIQUE,
    password BYTEA NOT NULL CHECK (octet_length(password) > 0),
    secret_key BYTEA NOT NULL CHECK (octet_length(secret_key) > 0),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,

    FOREIGN KEY (salesman_id) REFERENCES salesmans(salesman_id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS citizens
(
    citizen_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    location VARCHAR(255) NOT NULL
);

CREATE TABLE IF NOT EXISTS passports
(
    passport_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    number BYTEA NOT NULL UNIQUE CHECK (octet_length(number) > 0),
    session BYTEA NOT NULL UNIQUE CHECK (octet_length(session) > 0),
    citizen_id UUID NOT NULL,

    FOREIGN KEY (citizen_id) REFERENCES citizens(citizen_id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS clients
(
    client_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    name VARCHAR(255) NOT NULL,
    surname VARCHAR(255) NOT NULL,
    patronymic VARCHAR(255) NOT NULL,
    birth_date DATE NOT NULL,
    city VARCHAR(255) NOT NULL,
    passport_id UUID NOT NULL,

    FOREIGN KEY (passport_id) REFERENCES passports(passport_id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS profile_clients
(
    profile_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    client_id UUID NOT NULL,
    e_mail BYTEA NOT NULL UNIQUE CHECK (octet_length(e_mail) > 0),
    phone BYTEA NOT NULL UNIQUE CHECK (octet_length(phone) > 0),
    username VARCHAR(255) NOT NULL UNIQUE,
    password BYTEA NOT NULL CHECK (octet_length(password) > 0),
    secret_key BYTEA NOT NULL CHECK (octet_length(secret_key) > 0),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,

    FOREIGN KEY (client_id) REFERENCES clients(client_id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS statuses
(
    status_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    name VARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS continents
(
    continent_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    name VARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS brands
(
    brand_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    name VARCHAR(255) NOT NULL UNIQUE,
    continent_id UUID NOT NULL,

    FOREIGN KEY (continent_id) REFERENCES continents(continent_id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS models
(
    model_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    name VARCHAR(255) NOT NULL UNIQUE,
    brand_id UUID NOT NULL,

    FOREIGN KEY (brand_id) REFERENCES brands(brand_id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS desireds
(
    desired_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    client_id UUID NOT NULL,
    model_id UUID NOT NULL,
    brand_id UUID NOT NULL,

    FOREIGN KEY (client_id) REFERENCES clients(client_id) ON DELETE CASCADE,
    FOREIGN KEY (model_id) REFERENCES models(model_id) ON DELETE CASCADE,
    FOREIGN KEY (brand_id) REFERENCES brands(brand_id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS autos
(
    auto_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    model_id UUID NOT NULL,
    brand_id UUID NOT NULL,
    year_of_issue INTEGER NOT NULL,
    color VARCHAR(255) NOT NULL,
    vin VARCHAR(16) NOT NULL UNIQUE,
    photo_path TEXT NOT NULL,
    mileage DECIMAL(10, 2) NOT NULL,
    status_id UUID NOT NULL,

    FOREIGN KEY (model_id) REFERENCES models(model_id) ON DELETE CASCADE,
    FOREIGN KEY (brand_id) REFERENCES brands(brand_id) ON DELETE CASCADE,
    FOREIGN KEY (status_id) REFERENCES statuses(status_id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS test_drives
(
    test_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    client_id UUID NOT NULL,
    auto_id UUID NOT NULL,
    date_of_test DATE NOT NULL,
    fine_point DECIMAL(10, 2) NOT NULL,

    FOREIGN KEY (client_id) REFERENCES clients(client_id) ON DELETE CASCADE,
    FOREIGN KEY (auto_id) REFERENCES autos(auto_id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS trades
(
    trade_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    payment_type VARCHAR(255) NOT NULL,
    price DECIMAL(10, 2) NOT NULL
);

CREATE TABLE IF NOT EXISTS type_contracts
(
    type_contract_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    name VARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS contracts
(
    contract_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    auto_id UUID NOT NULL,
    trade_id UUID NOT NULL,
    typecontract_id UUID NOT NULL,
    date_of_contract DATE NOT NULL,

    FOREIGN KEY (auto_id) REFERENCES autos(auto_id) ON DELETE CASCADE,
    FOREIGN KEY (trade_id) REFERENCES trades(trade_id) ON DELETE CASCADE,
    FOREIGN KEY (typecontract_id) REFERENCES type_contracts(type_contract_id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS history_transforms
(
    history_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    salesman_id UUID NOT NULL,
    client_id UUID NOT NULL,
    contract_id UUID NOT NULL,
    name TEXT NOT NULL,

    FOREIGN KEY (salesman_id) REFERENCES salesmans(salesman_id) ON DELETE CASCADE,
    FOREIGN KEY (client_id) REFERENCES clients(client_id) ON DELETE CASCADE,
    FOREIGN KEY (contract_id) REFERENCES contracts(contract_id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS details
(
    detail_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    name VARCHAR(255) NOT NULL UNIQUE,
    price DECIMAL(10, 2) NOT NULL
);

CREATE TABLE IF NOT EXISTS mechanics
(
    mechanic_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    name VARCHAR(255) NOT NULL,
    surname VARCHAR(255) NOT NULL,
    patronymic VARCHAR(255) NOT NULL,
    position_id UUID NOT NULL,

    FOREIGN KEY (position_id) REFERENCES positions(position_id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS repairs
(
    repair_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    auto_id UUID NOT NULL,
    date_of_repair DATE NOT NULL,
    detail_id UUID NOT NULL,
    mechanic_id UUID NOT NULL,

    FOREIGN KEY (auto_id) REFERENCES autos(auto_id) ON DELETE CASCADE,
    FOREIGN KEY (mechanic_id) REFERENCES mechanics(mechanic_id) ON DELETE CASCADE,
    FOREIGN KEY (detail_id) REFERENCES details(detail_id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS profile_mechanics
(
    profile_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    mechanic_id UUID NOT NULL,
    e_mail BYTEA NOT NULL UNIQUE CHECK (octet_length(e_mail) > 0),
    phone BYTEA NOT NULL UNIQUE CHECK (octet_length(phone) > 0),
    username VARCHAR(255) NOT NULL UNIQUE,
    password BYTEA NOT NULL CHECK (octet_length(password) > 0),
    secret_key BYTEA NOT NULL CHECK (octet_length(secret_key) > 0),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,

    FOREIGN KEY (mechanic_id) REFERENCES mechanics(mechanic_id) ON DELETE CASCADE
);