# Timeish API- A Small Business Time Sheet Management Web App

Before building the project ensure all dependencies are installed.

1. Build the Angular App `ng build --prod`
2. Copy the files into  `/timeish-api/wwwroot/`
    * by default wwwroot/ is ignored from git, you will need to add it

Then run the C# debugger. The VSCode `launch.json` should build and run the C# web api and serve the static angular app.

## Project Dependencies
* Microsoft .NET Core v2.1
* Microsoft Entity Framework Core v2.1.4
* MySql v8.0.12
* Node.js v8.11.4
* Angular Cli v7.0.0


## Tools
* VSCode - Editor
* MySql Workbench 8 - Database GUI
* Postman - API Testing
* Chrome - when using `ng serve` make sure to enable `chrome://flags/#allow-insecure-localhost`

## Dev DB
### MySql Database Instance (Dev)
* Username: efuser
* Password: password
* Connection string found in `/api/appsettings.json`

### Entity Framework Code First Migration Commands
* To Clear database
  * Drop all tables in MySql work bench
  * Delete /app/Migrations
  * run commands below
* `dotnet ef migrations add <NAME>`
* `dotnet ef database update`
