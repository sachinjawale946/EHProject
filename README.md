# main

Project Architecture

1) EH.Assessment.Models - Models / Lookups / Constants
   All Application Level Models, Lookup and Constant are created in this seperate class libarary for reuseablity puprose.

2) EH.Assessment.Data - Database Layer 
   This class libarary will all logic related to databas layer.
   Entity Framework has to create database and tables with seed / master data.
   Using Entity Framework Fluent API Database Table Key, Relationships are managed in EHDBContext File.
   This project is used in Web Project using Repository Pattern.
   
3) EH.Assessment.Presentation - Web Project
   This the main web project which will run in browser with UI to manage contacts.
   All ef core repositores are registered in startup file
   Application Level exception handling is done in this project in - Filters/EHExceptionFilter.cs ( all errors will be logged in ErrorLogs Table )
   Application Level helper classed are created in - Helpers Folder
   

Evolent Health Project - Run Projct 
1) Project will run with VS 2017 and SQL Server 
2) Please change database connection string in web projects ( EH.Assessment.Presentation ) appsettings file, it will create the database when you start the project using Entity Framework Core.
