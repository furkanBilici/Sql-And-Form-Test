# Sql-And-Form-Test

This project is a sample application designed to **dynamically display SQL data in a table format using C#**. It was created primarily for learning and experimentation purposes and includes the following features:

## Features

- **Dynamic Data Fetching:** Easily connect to different databases by modifying the connection string.
- **MVC Integration:** Utilizes an MVC-compatible structure to manage and dynamically render the table.
- **Stored Procedure Support:** Includes support for certain operations using stored procedures (SPs).
- **Interactive Controls:** Features buttons integrated with MVC for table interactions.

## Usage

### 1. Requirements
- A development environment with .NET Framework or .NET Core installed (e.g., Visual Studio).
- SQL Server or another supported database.

### 2. Running the Project
1. Clone the repository:
   ```bash
   git clone https://github.com/username/project-name.git
   ```
2. Update the connection string in `appsettings.json` or the appropriate configuration file.
3. Build and run the project.

### 3. Customization
- To add a new table, update your database and create a corresponding model.
- Customize stored procedures by modifying the SQL scripts located in the `Scripts` folder.

## Project Structure

```
Project-Directory
├── Controllers
│   ├── HomeController.cs
│   └── TableController.cs
├── Models
│   ├── TableModel.cs
│   └── StoredProcedureModel.cs
├── Views
│   ├── Home
│   │   └── Index.cshtml
│   └── Table
│       └── TableView.cshtml
├── wwwroot
│   └── css
│       └── site.css
├── appsettings.json
└── Program.cs
```

## Contribute
This project welcomes contributions. Feel free to submit a `pull request` to add new features or improve the existing code.

## License
This project is licensed under the MIT License. See the `LICENSE` file for more details.
