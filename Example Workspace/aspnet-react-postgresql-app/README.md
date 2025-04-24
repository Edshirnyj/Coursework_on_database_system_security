# ASP.NET + React + PostgreSQL Application

This project is a web application built using ASP.NET for the backend, React for the frontend, and PostgreSQL as the database. It implements role-based access with separate pages for users, admins, and salesmen, each having its own database context.

## Project Structure

```
aspnet-react-postgresql-app
├── backend
│   ├── AspNetApp.sln
│   ├── AspNetApp
│   │   ├── Controllers
│   │   │   ├── AdminController.cs
│   │   │   ├── SalesmanController.cs
│   │   │   └── UserController.cs
│   │   ├── Data
│   │   │   ├── AdminDbContext.cs
│   │   │   ├── SalesmanDbContext.cs
│   │   │   └── UserDbContext.cs
│   │   ├── Models
│   │   │   ├── Admin
│   │   │   │   └── AdminModel.cs
│   │   │   ├── Salesman
│   │   │   │   └── SalesmanModel.cs
│   │   │   └── User
│   │   │       └── UserModel.cs
│   │   ├── Program.cs
│   │   ├── Startup.cs
│   │   └── appsettings.json
├── frontend
│   ├── package.json
│   ├── tsconfig.json
│   ├── public
│   │   └── index.html
│   └── src
│       ├── App.tsx
│       ├── index.tsx
│       ├── components
│       │   ├── Admin
│       │   │   └── AdminPage.tsx
│       │   ├── Salesman
│       │   │   └── SalesmanPage.tsx
│       │   └── User
│       │       └── UserPage.tsx
│       ├── contexts
│       │   ├── AdminContext.tsx
│       │   ├── SalesmanContext.tsx
│       │   └── UserContext.tsx
│       └── services
│           ├── AdminService.ts
│           ├── SalesmanService.ts
│           └── UserService.ts
├── database
│   ├── migrations
│   │   ├── AdminMigrations
│   │   ├── SalesmanMigrations
│   │   └── UserMigrations
│   └── scripts
│       └── init.sql
└── README.md
```

## Setup Instructions

1. **Clone the repository:**
   ```
   git clone <repository-url>
   cd aspnet-react-postgresql-app
   ```

2. **Backend Setup:**
   - Navigate to the `backend` directory.
   - Restore the NuGet packages:
     ```
     dotnet restore
     ```
   - Update the `appsettings.json` file with your PostgreSQL connection string.
   - Run the migrations to set up the database:
     ```
     dotnet ef database update
     ```
   - Start the backend server:
     ```
     dotnet run
     ```

3. **Frontend Setup:**
   - Navigate to the `frontend` directory.
   - Install the dependencies:
     ```
     npm install
     ```
   - Start the React application:
     ```
     npm start
     ```

## Usage

- Access the application in your browser at `http://localhost:3000`.
- The application has role-based access:
  - Admin functionalities are accessible via the Admin page.
  - Salesman functionalities are accessible via the Salesman page.
  - User functionalities are accessible via the User page.

## Contributing

Feel free to submit issues or pull requests for improvements or bug fixes.