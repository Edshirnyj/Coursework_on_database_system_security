# Fullstack Mini Project

This project is a full-stack web application built using React for the frontend, ASP.NET for the backend, and PostgreSQL for the database. The application allows users to manage roles through a user-friendly interface with manual data entry.

## Project Structure

```
fullstack-mini-project
├── client
│   ├── public
│   │   └── index.html
│   ├── src
│   │   ├── components
│   │   │   ├── Header.tsx
│   │   │   ├── Footer.tsx
│   │   │   └── RoleForm.tsx
│   │   ├── pages
│   │   │   ├── HomePage.tsx
│   │   │   └── RolesPage.tsx
│   │   ├── styles
│   │   │   ├── global.css
│   │   │   └── form.css
│   │   ├── App.tsx
│   │   └── index.tsx
│   ├── package.json
│   └── tsconfig.json
├── server
│   ├── Controllers
│   │   ├── RolesController.cs
│   │   └── HomeController.cs
│   ├── Models
│   │   ├── Role.cs
│   │   └── DatabaseContext.cs
│   ├── Program.cs
│   ├── Startup.cs
│   └── appsettings.json
├── database
│   ├── init.sql
│   ├── schema.sql
│   └── seed.sql
└── README.md
```

## Features

- **Role Management**: Users can create, read, update, and delete roles.
- **Responsive Design**: The application is designed to be responsive and user-friendly.
- **Data Validation**: Input forms include validation to ensure data integrity.
- **Security**: The application adheres to information security standards, including secure data handling and validation.

## Technologies Used

- **Frontend**: React, TypeScript, CSS
- **Backend**: ASP.NET Core
- **Database**: PostgreSQL

## Setup Instructions

### Prerequisites

- .NET SDK
- Node.js
- PostgreSQL

### Installation

1. Clone the repository:
   ```
   git clone <repository-url>
   cd fullstack-mini-project
   ```

2. Set up the database:
   - Create a PostgreSQL database and configure the connection string in `server/appsettings.json`.
   - Run the SQL scripts in the `database` folder to initialize the database schema and seed data.

3. Install the client dependencies:
   ```
   cd client
   npm install
   ```

4. Run the client application:
   ```
   npm start
   ```

5. Run the server application:
   ```
   cd server
   dotnet run
   ```

## Usage

- Navigate to the home page to view the application.
- Use the roles page to manage roles through the provided form.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any improvements or bug fixes.

## License

This project is licensed under the MIT License.