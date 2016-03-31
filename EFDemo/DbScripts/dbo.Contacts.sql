CREATE TABLE [dbo].[Contacts]
(
	[Id] INT NOT NULL identity(1,1) PRIMARY KEY,
	Contact varchar(20) not null,
	ContactKind int not null,
	EmployeeId int not null foreign key references Employees(EmployeeId)
)
