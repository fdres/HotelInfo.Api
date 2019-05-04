# HotelInfo.Api

This project is a simple REST Web Api which implements CRUD operations for managing hotel and booking records.

The project is developed in Visual Studio 2017 with .NET Core 2.2 Framework and EF Core for database queries.
All calls are made asynchronously using async/await.

SQL Server is used as a database provider. 

Controller implementation is done with usage of repository pattern.

### Usage

The project uses local mssqlserver that is installed with Visual Studio.
In order to use another sql server instance, just change the connection string in appSettings.json file.

Before you begin, run the following command in Package Manager Console

```powershell
> update-database
```

This will create the database HotelsDB and apply all migrations.
Migrations include some demo data.

### Notes

- The solution includes a xUnit test project. The tests are done on the service implementations, not the controllers.
- A postman collection and a postman environment file are included in the project directory.
- All exceptions are handled by a custom middleware.
