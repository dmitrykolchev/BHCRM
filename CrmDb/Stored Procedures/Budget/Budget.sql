CREATE TABLE [dbo].[Budget]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[FileAs] TName not null,
	[Number] TCode not null default('без номера'),
	[DocumentDate] date not null default(getdate()),
	[OrganizationId] TIdentifier not null default(2),
	[ServiceRequestId] TIdentifier not null,
	[BudgetTemplateId] TIdentifier null,
	[AmountOfGuests] int null,
	[EventDuration] int null,
	[Value] TMoney not null default(0),
    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null, 
    CONSTRAINT [FK_Budget_ServiceRequest] FOREIGN KEY ([ServiceRequestId]) REFERENCES [dbo].[ServiceRequest]([Id]), 
    CONSTRAINT [FK_Budget_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Account]([Id]), 
    CONSTRAINT [FK_Budget_BudgetTemplate] FOREIGN KEY ([BudgetTemplateId]) REFERENCES [dbo].[BudgetTemplate]([Id])
)
