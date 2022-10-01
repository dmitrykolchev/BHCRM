CREATE TABLE [dbo].[DocumentLog]
(
	[DocumentTypeId] int not null,
	[DocumentId] TIdentifier not null,
	[State] TState not null,
	[FileAs] TName null,
	[Number] TCode null,
	[DocumentDate] date null,
	[OrganizationId] TIdentifier null,
	[Comments] nvarchar(max) null,
	[Created] datetime not null,
	[CreatedBy] int not null,
	[Modified] datetime not null,
	[ModifiedBy] int not null,
	[RowVersion] binary(8) not null, 
    constraint [PK_DocumentLog] primary key ([DocumentTypeId], [DocumentId])
)
