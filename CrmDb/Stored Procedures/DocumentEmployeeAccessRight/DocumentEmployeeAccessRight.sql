create table [dbo].[DocumentEmployeeAccessRight]
(
	[Id] int not null identity primary key,
	[State] TState not null,
	[DocumentTypeId] int not null,
	[DocumentId] TIdentifier not null,
	[DocumentAccessTypeId] TIdentifier not null,
	[EmployeeId] TIdentifier not null,
	[StartDate] date null,
	[EndDate] date null,
    [Created] datetime not null default(getdate()), 
    [CreatedBy] int not null,
    [Modified] datetime not null default(getdate()), 
    [ModifiedBy] int not null, 
    [RowVersion] rowversion not null, 
    CONSTRAINT [FK_DocumentEmployeeAccessRight_DocumentAccessType] FOREIGN KEY ([DocumentAccessTypeId]) REFERENCES [DocumentAccessType]([Id]), 
    CONSTRAINT [FK_DocumentEmployeeAccessRight_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [Employee]([Id])
)
