CREATE TABLE [dbo].[DocumentType]
(
	[Id] int identity not null primary key,
	[ClassName] varchar(256) not null,
	[TableName] nvarchar(128) not null,
	[SchemaName] nvarchar(128) not null,
	[ClrTypeName] varchar(1024) null,
	[DataAdapterTypeName] varchar(1024) null,
	[DataAdapterType] varchar(32) null,
	[IsNumbered] bit default(0) not null,
	[Caption] nvarchar(256) not null,
	[SmallImage] varbinary(max) null,
	[LargeImage] varbinary(max) null,
	[Description] nvarchar(max) null,
	[SupportsTransitionTemplates] bit not null default(0),
    [Created] datetime not null default(getdate()), 
    [CreatedBy] int not null default(1), 
    [Modified] datetime not null default(getdate()), 
    [ModifiedBy] int not null default (1), 
    [RowVersion] rowversion not null, 
    constraint [AK_DocumentType_ClassName] unique ([ClassName])
)
