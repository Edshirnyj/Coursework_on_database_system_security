CREATE TABLE Cars (
    Id SERIAL PRIMARY KEY,
    Make VARCHAR(50) NOT NULL,
    Model VARCHAR(50) NOT NULL,
    Year INT NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    Description TEXT,
    ImageUrl VARCHAR(255)
);

CREATE TABLE Filters (
    Id SERIAL PRIMARY KEY,
    MinPrice DECIMAL(10, 2),
    MaxPrice DECIMAL(10, 2),
    Make VARCHAR(50),
    Model VARCHAR(50),
    Year INT
);