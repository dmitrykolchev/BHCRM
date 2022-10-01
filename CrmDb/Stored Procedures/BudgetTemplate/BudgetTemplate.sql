CREATE TABLE [dbo].[BudgetTemplate]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[FileAs] TName not null,
	[ServiceRequestTypeId] TIdentifier not null,
	[ServiceLevelId] TIdentifier not null default(2),
	[AmountOfPersons] int not null default(100),
	[EventDuration] int not null default(8),
    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null, 
    constraint [FK_BudgetTemplate_ServiceRequestType] foreign key ([ServiceRequestTypeId]) references [ServiceRequestType]([Id]), 
    constraint [FK_BudgetTemplate_ServiceLevel] foreign key ([ServiceLevelId]) references [ServiceLevel]([Id])
)


