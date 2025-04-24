CREATE TABLE Admins (
    Id SERIAL PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE Salesmen (
    Id SERIAL PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE Users (
    Id SERIAL PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO Admins (Username, PasswordHash, Email) VALUES
('admin1', 'hashed_password_1', 'admin1@example.com'),
('admin2', 'hashed_password_2', 'admin2@example.com');

INSERT INTO Salesmen (Username, PasswordHash, Email) VALUES
('salesman1', 'hashed_password_1', 'salesman1@example.com'),
('salesman2', 'hashed_password_2', 'salesman2@example.com');

INSERT INTO Users (Username, PasswordHash, Email) VALUES
('user1', 'hashed_password_1', 'user1@example.com'),
('user2', 'hashed_password_2', 'user2@example.com');