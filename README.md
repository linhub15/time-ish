# Time-ish
A Small Business Time Sheet Management Web App

## Project Dependencies
* Microsoft .NET Core v2.1
* Microsoft Entity Framework Core v2.1.4
* MySql v8.0.12
* Angular

## Dev DB
### MySql Database Instance (Dev)
* Username: efuser
* Password: password
* Connection string found in `/api/appsettings.json`

### Entity Framework Code First Migration Commands
* `dotnet ef migrations add <NAME>`
* `dotnet ef database update`
