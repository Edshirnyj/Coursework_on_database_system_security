# Car Dealership Catalog Client

This is the client-side application for the Car Dealership Catalog project, built using React and TypeScript. The application allows users to browse a catalog of cars, apply filters, and view detailed information about each car.

## Features

- **Car Catalog**: View a list of available cars with essential details.
- **Car Details**: Click on a car to view detailed information and a purchase option.
- **User-Editable Filters**: Adjust filters to refine the car search based on user preferences.
- **Responsive Design**: The application is designed to be user-friendly and responsive.

## Getting Started

To get started with the client-side application, follow these steps:

1. **Clone the Repository**:
   ```
   git clone <repository-url>
   cd car-dealership-catalog/client
   ```

2. **Install Dependencies**:
   ```
   npm install
   ```

3. **Run the Application**:
   ```
   npm start
   ```

   This will start the development server and open the application in your default web browser.

## Folder Structure

- **public/**: Contains the main HTML file and static assets.
- **src/**: Contains the source code for the React application.
  - **components/**: Reusable components such as `CarDetails`, `CarFilter`, and `CarList`.
  - **pages/**: Main pages of the application, including `CatalogPage` and `FilterWindow`.
  - **App.tsx**: Main application component that sets up routing.
  - **index.tsx**: Entry point for the React application.

## Technologies Used

- **React**: A JavaScript library for building user interfaces.
- **TypeScript**: A superset of JavaScript that adds static types.
- **PostgreSQL**: The database used for storing car and filter data.
- **ASP.NET**: The backend framework for handling API requests.

## Contributing

Contributions are welcome! If you have suggestions for improvements or new features, please open an issue or submit a pull request.

## License

This project is licensed under the MIT License. See the LICENSE file for details.