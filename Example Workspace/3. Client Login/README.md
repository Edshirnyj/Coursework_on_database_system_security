# Fullstack Application

This project is a fullstack application built using React for the frontend, ASP.NET for the backend, and PostgreSQL as the database. The application allows users to create workspaces and manage their accounts with different roles.

## Project Structure

```
fullstack-app
├── backend                # ASP.NET backend
│   ├── Controllers        # API controllers
│   ├── Data               # Database context classes
│   ├── Models             # Data models
│   ├── Services           # Business logic services
│   ├── Program.cs         # Entry point of the application
│   ├── Startup.cs         # Application configuration
│   └── appsettings.json   # Configuration settings
├── frontend               # React frontend
│   ├── public             # Public assets
│   ├── src                # Source files for React
│   ├── package.json       # Frontend dependencies and scripts
│   └── vite.config.js     # Vite configuration
├── database               # Database migrations and seed data
└── README.md              # Project documentation
```

## Features

- User authentication and registration
- Role-based access control (Guest and Client roles)
- Workspace creation and management
- API endpoints for user and workspace operations

## Getting Started

### Prerequisites

- .NET SDK
- Node.js and npm
- PostgreSQL

### Backend Setup

1. Navigate to the `backend` directory.
2. Restore the NuGet packages:
   ```
   dotnet restore
   ```
3. Update the `appsettings.json` file with your PostgreSQL connection string.
4. Run the migrations to set up the database:
   ```
   dotnet ef database update
   ```
5. Start the backend server:
   ```
   dotnet run
   ```

### Frontend Setup

1. Navigate to the `frontend` directory.
2. Install the dependencies:
   ```
   npm install
   ```
3. Start the React application:
   ```
   npm run dev
   ```

## Usage

- Access the application in your web browser at `http://localhost:3000`.
- Register as a new user or log in with existing credentials.
- Create and manage your workspaces through the dashboard.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any improvements or features.

## License

This project is licensed under the MIT License.