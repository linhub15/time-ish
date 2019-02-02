# Tymish API
[Back to Tymish.github.io](https://tymish.github.io)

Before building the project ensure all tools and dependencies are installed.

### Setup MySql Database Instance (Dev)
* User Name: `efuser`
* Host: `localhost`
* Role: `DB Manager`
* Authentication: `MySQL`
* Password: `password`
* Connection string `Server=localhost;Port=3306;Database=timeish;Uid=efuser;Pwd=password;`

### Entity Framework Code First Migration Commands
* To Clear database
  * Drop all tables in MySql work bench
  * Delete /app/Migrations
  * run commands below
* `dotnet ef migrations add <NAME>`
* `dotnet ef database update`
