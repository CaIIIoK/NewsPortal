# NewsPortal

Portal for reading, publishing, editing and removing news.

Now only functionality for administrator of Portal is implemented.

# Installation
1) Install Microsoft SQL Server.
2) Install Node.js and reload your PC after installation.
    - https://nodejs.org/uk/download/
3) Clone this project and open it in your IDE.
4) In class Startup.cs specify your SQL Server name (instead of "ALEX-PC\\SQLEXPRESS").
5) Run project.

# Project Help
In case of SQL-related exceptions after project Run clear Migrations folder and make one of two steps:
1) Specify in Package Manager Console:
    - Add-Migration Initial
    - Update-Database
2) In cmd go to folder where Project is located and specify:
    - dotnet ef migrations add InitialCreate
    - dotnet ef database update
