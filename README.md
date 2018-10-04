# Time-ish
A Small Business Time Sheet Management Web App

## Project Dependencies
* Microsoft .NET Core v2.1
* Microsoft Entity Framework Core v2.1.4
* MySql v8.0.12
* Angular


## Prototype API
- [ ] GET `/timesheets`
- [ ] POST `/timesheets/`
- [ ] GET `/timesheets/${id}`
- [ ] PUT `/timesheets/${id}`
- [ ] DELETE `/timesheets/${id}`
- [ ] OAuth with Facebook


## Local MySql Database Instance (For Development Only)
* Username: efuser
* Password: password
* Connection string found in `/api/appsettings.json`

## Code First Migrations
* `dotnet ef migrations add <NAME>`
* `dotnet ef database update`