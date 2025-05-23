CREATE TABLE Workspaces (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    OwnerId INT NOT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (OwnerId) REFERENCES Users(Id) ON DELETE CASCADE
);