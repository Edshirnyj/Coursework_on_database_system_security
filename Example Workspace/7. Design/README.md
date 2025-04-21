# Fullstack Mini Project

This is a fullstack mini project built using React for the frontend, ASP.NET for the backend, and PostgreSQL as the database. The project showcases a glassmorphism design with a focus on clean separation of components.

## Project Structure

```
fullstack-mini-project
├── client
│   ├── public
│   │   ├── index.html
│   │   └── favicon.ico
│   ├── src
│   │   ├── components
│   │   │   ├── Header.tsx
│   │   │   ├── Footer.tsx
│   │   │   └── GlassCard.tsx
│   │   ├── pages
│   │   │   ├── HomePage.tsx
│   │   │   └── AboutPage.tsx
│   │   ├── styles
│   │   │   ├── global.css
│   │   │   └── glassmorphism.css
│   │   ├── App.tsx
│   │   └── index.tsx
│   ├── package.json
│   └── tsconfig.json
├── server
│   ├── Controllers
│   │   ├── HomeController.cs
│   │   └── ApiController.cs
│   ├── Models
│   │   └── DatabaseContext.cs
│   ├── Program.cs
│   ├── Startup.cs
│   └── appsettings.json
├── database
│   ├── init.sql
│   └── schema.sql
└── README.md
```

## Technologies Used

- **Frontend**: React, TypeScript, CSS
- **Backend**: ASP.NET Core
- **Database**: PostgreSQL

## Features

- Responsive design with glassmorphism aesthetics.
- Clean separation of components for maintainability.
- Montserrat font for a modern look.

## Setup Instructions

### Prerequisites

- Node.js
- PostgreSQL
- .NET SDK

### Client Setup

1. Navigate to the `client` directory.
2. Install dependencies:
   ```
   npm install
   ```
3. Start the development server:
   ```
   npm start
   ```

### Server Setup

1. Navigate to the `server` directory.
2. Restore the NuGet packages:
   ```
   dotnet restore
   ```
3. Run the application:
   ```
   dotnet run
   ```

### Database Setup

1. Create a PostgreSQL database.
2. Run the SQL scripts in `database/schema.sql` and `database/init.sql` to set up the schema and initial data.

## Usage

- Access the application at `http://localhost:3000` for the frontend.
- The backend API can be accessed at `http://localhost:5000/api`.

## Contributing

Feel free to fork the repository and submit pull requests for any improvements or features you would like to add.