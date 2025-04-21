# Fullstack Mini Project

This project is a full-stack application built using React for the frontend, ASP.NET for the backend, and PostgreSQL as the database. It features a simple admin login system that provides feedback based on the login attempt.

## Project Structure

```
fullstack-mini-project
├── client
│   ├── public
│   │   └── index.html
│   ├── src
│   │   ├── components
│   │   │   ├── AdminLogin.tsx
│   │   │   └── Dashboard.tsx
│   │   ├── App.tsx
│   │   ├── index.tsx
│   │   └── styles
│   │       └── App.css
│   ├── package.json
│   └── tsconfig.json
├── server
│   ├── Controllers
│   │   └── AuthController.cs
│   ├── Models
│   │   └── User.cs
│   ├── Program.cs
│   ├── Startup.cs
│   ├── appsettings.json
│   └── fullstack-mini-project.csproj
├── database
│   ├── init.sql
│   └── README.md
└── README.md
```

## Features

- **Admin Login**: A login form for admin users that validates credentials against a PostgreSQL database.
- **Feedback Messages**: Displays "Error!" on failed login attempts and "Congratulations!" on successful logins.
- **Dashboard**: A simple dashboard that welcomes the admin after a successful login.

## Setup Instructions

### Prerequisites

- .NET SDK
- Node.js
- PostgreSQL

### Backend Setup

1. Navigate to the `server` directory.
2. Restore the dependencies:
   ```
   dotnet restore
   ```
3. Update the `appsettings.json` file with your PostgreSQL connection string.
4. Run the application:
   ```
   dotnet run
   ```

### Frontend Setup

1. Navigate to the `client` directory.
2. Install the dependencies:
   ```
   npm install
   ```
3. Start the React application:
   ```
   npm start
   ```

### Database Setup

1. Open PostgreSQL and create a new database.
2. Run the SQL commands in `database/init.sql` to set up the initial schema.

## Usage

- Access the application in your web browser at `http://localhost:3000`.
- Use the admin login form to authenticate.

## License

This project is open-source and available under the MIT License.