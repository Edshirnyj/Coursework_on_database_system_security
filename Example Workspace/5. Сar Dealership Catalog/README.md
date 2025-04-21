# Car Dealership Catalog

This project is a full-stack car dealership catalog application built using React for the client-side, ASP.NET for the server-side, and PostgreSQL as the database. The application allows users to browse a catalog of cars, apply filters, view detailed information about each car, and make purchases.

## Project Structure

The project is organized into three main directories:

- **client**: Contains the React application.
- **server**: Contains the ASP.NET backend.
- **database**: Contains SQL scripts for database migrations and seeding.

## Features

- **Car Catalog**: Users can view a list of available cars.
- **Filters**: Users can apply filters to narrow down the car selection based on criteria such as make, model, and price range.
- **Car Details**: Users can click on a car to view detailed information and have the option to purchase.
- **Responsive Design**: The application is designed to be user-friendly and responsive.

## Getting Started

### Prerequisites

- Node.js and npm installed for the client-side.
- .NET SDK installed for the server-side.
- PostgreSQL installed and running for the database.

### Installation

1. **Clone the repository**:
   ```
   git clone <repository-url>
   cd car-dealership-catalog
   ```

2. **Set up the database**:
   - Navigate to the `database` directory and run the SQL scripts to create the database schema and seed initial data.

3. **Run the server**:
   - Navigate to the `server` directory and run:
   ```
   dotnet run
   ```

4. **Run the client**:
   - Navigate to the `client` directory and run:
   ```
   npm install
   npm start
   ```

### Usage

- Open your browser and navigate to `http://localhost:3000` to access the car dealership catalog.
- Use the filters to refine your search and click on any car to view its details.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any enhancements or bug fixes.

## License

This project is licensed under the MIT License. See the LICENSE file for details.