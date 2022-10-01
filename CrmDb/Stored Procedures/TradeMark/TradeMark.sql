CREATE TABLE [dbo].[TradeMark]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[FileAs] TName not null,
	[BusinessActivityTypeId] TIdentifier not null,
	[OrganizationId] TIdentifier not null,
    [Comments] nvarchar(max) null, 
    [Created] datetime not null, 
    [CreatedBy] int not null, 
    [Modified] datetime not null, 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null, 
    CONSTRAINT [FK_TradeMark_BusinessActivity] FOREIGN KEY ([BusinessActivityTypeId]) REFERENCES [BusinessActivityType]([Id]), 
    CONSTRAINT [FK_TradeMark_Organization] FOREIGN KEY ([OrganizationId]) REFERENCES [Account]([Id]), 
)
