# Tymish API
[Back to Tymish.github.io](https://tymish.github.io)

Before building the project ensure all tools and dependencies are installed.

1. Install MySQL Server
2. Setup the application user
3. Run the database script

### Setup MySql Database Instance (Dev)
* User Name: `efuser`
* Host: `localhost`
* Role: `DB Manager`
* Authentication: `MySQL`
* Password: `password`
* Connection string `Server=localhost;Port=3306;Database=timeish;Uid=efuser;Pwd=password;`

### Build and run API
Once you have to project open in VS Code
* `cd src`
* `dotnet build`
* `dotnet run --launch-profile api`
* It should be running on localhost:5001
* Test the app by opening chrome and navigate to `https://localhost:5001/api/employees`
* Test the other endpoints on the API with Postman

### Entity Framework Code First Migration Commands (For code changes that affect schema)
* To Clear database
  * Drop all tables in MySql work bench
  * Delete /app/Migrations
  * run commands below
* `dotnet ef migrations add <NAME>`
* `dotnet ef database update`
