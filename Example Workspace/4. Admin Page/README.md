# Fullstack Mini Project

This project is a full-stack application built using React for the frontend, ASP.NET for the backend, and PostgreSQL as the database. It provides an admin interface for managing database records with functionalities to create, read, update, and delete data.

## Project Structure

```
fullstack-mini-project
├── backend
│   ├── Controllers
│   │   └── AdminController.cs
│   ├── Models
│   │   └── DatabaseModel.cs
│   ├── Services
│   │   └── DatabaseService.cs
│   ├── appsettings.json
│   ├── Program.cs
│   ├── Startup.cs
│   └── fullstack-mini-project.csproj
├── frontend
│   ├── public
│   │   └── index.html
│   ├── src
│   │   ├── components
│   │   │   ├── Sidebar.jsx
│   │   │   ├── DataTable.jsx
│   │   │   └── FormSection.jsx
│   │   ├── pages
│   │   │   └── AdminPage.jsx
│   │   ├── App.jsx
│   │   └── index.js
│   ├── package.json
│   └── vite.config.js
├── database
│   ├── init.sql
│   └── schema.sql
└── README.md
```

## Technologies Used

- **Frontend**: React, Vite
- **Backend**: ASP.NET Core
- **Database**: PostgreSQL

## Setup Instructions

### Backend

1. Navigate to the `backend` directory.
2. Restore the dependencies using the command:
   ```
   dotnet restore
   ```
3. Update the `appsettings.json` file with your PostgreSQL connection string.
4. Run the application using:
   ```
   dotnet run
   ```

### Frontend

1. Navigate to the `frontend` directory.
2. Install the dependencies using:
   ```
   npm install
   ```
3. Start the development server with:
   ```
   npm run dev
   ```

### Database

1. Use the `schema.sql` file to create the necessary tables in your PostgreSQL database.
2. Optionally, run the `init.sql` file to populate the database with sample data.

## Usage

- Access the admin interface through the frontend application.
- Use the sidebar to navigate between different database categories (tables).
- Use the form section to input new data, edit existing records, or delete records.
- View the data from the selected database table in the data display area.

## Contributing

Feel free to fork the repository and submit pull requests for any improvements or features you would like to add. 

## License

This project is licensed under the MIT License.