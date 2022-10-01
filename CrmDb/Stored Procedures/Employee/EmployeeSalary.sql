CREATE TABLE [dbo].[EmployeeSalary]
(
	[EmployeeSalaryId] TIdentifier not null identity primary key,
	[EmployeeId] TIdentifier not null,
	[Value] TMoney not null,
	[CashValue] TMoney not null default(0),
	[ActiveFrom] date not null, 
    CONSTRAINT [FK_EmployeeSalary_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [Employee]([Id])
)
