# ASP-NET_WEB-API
WEB REST API Created using ASP MVC .NET 6.0 and MYSQL

This Application is an ASP.NET Core MVC webapi that accessing MYSQL Server with EF Core, With EF Core, data access is performed using a models.
A model is made up of entity classes and a context object that represents a session with the database. The context object allows querying and saving data.
Instances of your entity classes are retrieved from the database using Language Integrated Query (LINQ).

Entity Framework(EF) Core is the latest object database mapper for .NET. Supports LINQ queries, change tracking, updates, and schema migration. EF Core works with SQL Server, Azure SQL Database, SQLite, Azure Cosmos DB, MySQL, PostgreSQL, and other databases via the provider plug-in API.
EF supports the following model development approaches: 
Generate a model from an existing database, 
Manually code the model to match it to the database, 
Once the model is created, use EF migration to create the database from the model,
Migration allows you to evolve your database as your model changes.

If you have a MySQL server installed on your computer, you can open it and paste the following SQL code. Alternatively, you can use any visual database design tool (for example, use Mysql Workbench to create the database and its tables). 

CREATE SCHEMA IF NOT EXISTS `LibraryDB`;

USE `LibraryDB` ;

CREATE TABLE IF NOT EXISTS `LibraryDB`.`Books` (
  `Book_Id` INT NOT NULL AUTO_INCREMENT,
  `Category` VARCHAR(250) NOT NULL,
  `Title` VARCHAR(250) NOT NULL,
  `Author` VARCHAR(250) NOT NULL,
  PRIMARY KEY (`Book_Id`))
ENGINE = InnoDB;

Things you need to know to understand the project :
C# 8.0, 
ASP.NET Core MVC, 
MYSQL DATABASE, 
Entity Framework Core,
