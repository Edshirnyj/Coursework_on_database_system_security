INSERT INTO Roles (Name) VALUES ('Гость'), ('Клиент');

INSERT INTO Users (Username, PasswordHash, RoleId) VALUES 
('guest_user', 'hashed_password_guest', (SELECT Id FROM Roles WHERE Name = 'Гость')),
('client_user', 'hashed_password_client', (SELECT Id FROM Roles WHERE Name = 'Клиент'));

INSERT INTO Workspaces (Name, OwnerId) VALUES 
('Workspace 1', (SELECT Id FROM Users WHERE Username = 'client_user')),
('Workspace 2', (SELECT Id FROM Users WHERE Username = 'client_user'));