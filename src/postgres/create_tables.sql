-- Enable the pgcrypto extension for cryptographic functions
CREATE EXTENSION IF NOT EXISTS pgcrypto;

-- Enable the uuid-ossp extension for UUID generation
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

-- Updated tables with encryption for sensitive fields
CREATE TABLE IF NOT EXISTS details
(
    detail_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    name VARCHAR(255) NOT NULL,
    price DECIMAL(10, 2) NOT NULL
);

CREATE TABLE IF NOT EXISTS statuses
(
    status_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    name VARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS workers
(
    worker_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    first_name VARCHAR(255) NOT NULL,
    second_name VARCHAR(255) NOT NULL,
    third_name VARCHAR(255) NOT NULL,
    position VARCHAR(255) NOT NULL,
    cost BYTEA NOT NULL CHECK (octet_length(cost) > 0) -- Encrypted salary
);

CREATE TABLE IF NOT EXISTS trades
(
    trade_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    payment_type VARCHAR(255) NOT NULL,
    price DECIMAL(10, 2) NOT NULL CHECK (price >= 0)
);

CREATE TABLE IF NOT EXISTS contract_types
(
    type_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
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
    brand_id UUID NOT NULL,
    name VARCHAR(255) NOT NULL UNIQUE,
    FOREIGN KEY (brand_id) REFERENCES brands(brand_id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS autos
(
    auto_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    model_id UUID NOT NULL,
    year INTEGER NOT NULL CHECK (year >= 1886),
    vin VARCHAR(255) NOT NULL UNIQUE,
    status_id UUID,

    FOREIGN KEY (model_id) REFERENCES models(model_id) ON DELETE CASCADE,
    FOREIGN KEY (status_id) REFERENCES statuses(status_id) ON DELETE SET NULL
);

CREATE TABLE IF NOT EXISTS repairs
(
    repair_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    auto_id UUID NOT NULL,
    date_of_repair DATE NOT NULL,
    detail_id UUID NOT NULL,

    FOREIGN KEY (auto_id) REFERENCES autos(auto_id) ON DELETE CASCADE,
    FOREIGN KEY (detail_id) REFERENCES details(detail_id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS localities
(
    locality_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    name VARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS citizens
(
    citizen_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    name VARCHAR(255) NOT NULL,
    locality_id UUID NOT NULL,

    FOREIGN KEY (locality_id) REFERENCES localities(locality_id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS passports
(
    passport_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    number BYTEA NOT NULL UNIQUE CHECK (octet_length(number) > 0), -- Encrypted passport number
    session BYTEA NOT NULL CHECK (octet_length(session) > 0), -- Encrypted session
    citizen_id UUID NOT NULL,

    FOREIGN KEY (citizen_id) REFERENCES citizens(citizen_id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS clients
(
    client_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    first_name VARCHAR(255) NOT NULL,
    second_name VARCHAR(255) NOT NULL,
    third_name VARCHAR(255) NOT NULL,
    phone BYTEA NOT NULL UNIQUE CHECK (octet_length(phone) > 0), -- Encrypted phone
    email BYTEA NOT NULL UNIQUE CHECK (octet_length(email) > 0), -- Encrypted email
    passport_id UUID NOT NULL,

    FOREIGN KEY (passport_id) REFERENCES passports(passport_id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS test_drives
(
    test_drive_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    client_id UUID NOT NULL,
    auto_id UUID NOT NULL,
    date_of_test DATE NOT NULL,
    fine_points VARCHAR(255) NOT NULL,

    FOREIGN KEY (client_id) REFERENCES clients(client_id) ON DELETE CASCADE,
    FOREIGN KEY (auto_id) REFERENCES autos(auto_id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS contracts
(
    contract_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    auto_id UUID NOT NULL,
    trade_id UUID NOT NULL,
    contract_type_id UUID NOT NULL,
    date_of_contract DATE NOT NULL,

    FOREIGN KEY (auto_id) REFERENCES autos(auto_id) ON DELETE CASCADE,
    FOREIGN KEY (trade_id) REFERENCES trades(trade_id) ON DELETE CASCADE,
    FOREIGN KEY (contract_type_id) REFERENCES contract_types(type_id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS history_transforms
(
    transform_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    client_id UUID NOT NULL,
    worker_id UUID NOT NULL,
    contract_id UUID NOT NULL,
    name VARCHAR(255) NOT NULL
);
