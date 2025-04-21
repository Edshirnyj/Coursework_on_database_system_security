INSERT INTO Users (Username, Email, CreatedAt) VALUES
('user1', 'user1@example.com', NOW()),
('user2', 'user2@example.com', NOW()),
('user3', 'user3@example.com', NOW());

INSERT INTO Products (ProductName, Price, CreatedAt) VALUES
('Product A', 19.99, NOW()),
('Product B', 29.99, NOW()),
('Product C', 39.99, NOW());

INSERT INTO Orders (UserId, ProductId, OrderDate) VALUES
(1, 1, NOW()),
(1, 2, NOW()),
(2, 1, NOW()),
(3, 3, NOW());