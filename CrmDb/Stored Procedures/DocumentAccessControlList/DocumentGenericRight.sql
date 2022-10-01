/*
	Generig Rights
		List			0x0001
		Browse			0x0002
		Get				0x0004
		Create			0x0008
		Edit Own		0x0010
		Edit All		0x0020
		Change State	0x0040
		Delete Own		0x0080
		Delete All		0x0100
*/
CREATE TABLE [dbo].[DocumentGenericRight]
(
	[DocumentTypeId] int not null,
	[ApplicationRoleId] TIdentifier not null,
	[RightFlags] int not null default(0xFFFF), 
    constraint [PK_DocumentGenericRight] primary key ([DocumentTypeId], [ApplicationRoleId])
)
