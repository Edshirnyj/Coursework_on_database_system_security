CREATE TABLE categories (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL
);

CREATE TABLE products (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    description TEXT,
    price DECIMAL(10, 2) NOT NULL,
    category_id INT REFERENCES categories(id)
);

INSERT INTO categories (name) VALUES ('Electronics'), ('Books'), ('Clothing');

INSERT INTO products (name, description, price, category_id) VALUES 
('Smartphone', 'Latest model smartphone', 699.99, 1),
('Laptop', 'High performance laptop', 1299.99, 1),
('Novel', 'Bestselling novel', 19.99, 2),
('T-shirt', 'Cotton T-shirt', 15.99, 3);