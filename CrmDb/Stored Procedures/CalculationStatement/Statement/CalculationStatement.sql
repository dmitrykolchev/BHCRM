﻿create table [dbo].[CalculationStatement]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[FileAs] TName not null,
	[Number] TCode not null,
	[DocumentDate] date not null,
	[OrganizationId] TIdentifier not null,
	[ServiceRequestId] TIdentifier not null,
	[BudgetId] TIdentifier not null,
	[CalculationStage] int not null,
	[IncomeBudgetItemId] TIdentifier null,
	[ExpenseBudgetItemId] TIdentifier null,
	[DependsOnAmountOfPersons] bit not null default(0),
	[AmountOnly] bit not null default(0),
	[VATRateId] TIdentifier not null,
	[Margin] TPercent not null default(0),
	[Discount] TPercent not null default(0),
	[ResponsibleEmployeeId] TIdentifier null,
    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null, 
    CONSTRAINT [FK_CalculationStatement_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [Account]([Id]), 
    CONSTRAINT [FK_CalculationStatement_ServiceRequest] FOREIGN KEY ([ServiceRequestId]) REFERENCES [ServiceRequest]([Id]), 
    CONSTRAINT [FK_CalculationStatement_Budget] FOREIGN KEY ([BudgetId]) REFERENCES [Budget]([Id]), 
    CONSTRAINT [FK_CalculationStatement_IncomeBudgetItem] FOREIGN KEY ([IncomeBudgetItemId]) REFERENCES [BudgetItem]([Id]), 
    CONSTRAINT [FK_CalculationStatement_ExpenseBudgetItem] FOREIGN KEY ([ExpenseBudgetItemId]) REFERENCES [BudgetItem]([Id]), 
    CONSTRAINT [FK_CalculationStatement_VATRate] FOREIGN KEY ([VATRateId]) REFERENCES [VATRate]([Id]), 
    CONSTRAINT [FK_CalculationStatement_ResponsibleEmployee] FOREIGN KEY ([ResponsibleEmployeeId]) REFERENCES [Employee]([Id])
)