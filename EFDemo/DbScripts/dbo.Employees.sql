CREATE TABLE [dbo].[Employees]
(
	[EmployeeId] INT NOT NULL identity(1, 1) PRIMARY KEY,
	[Version] int not null,
	[Name] varchar(100) not null,
	[Address] varchar(100) not null,
	[EmployeeTypeId] int not null foreign key references EmployeeTypes(EmployeeTypeId)
)
