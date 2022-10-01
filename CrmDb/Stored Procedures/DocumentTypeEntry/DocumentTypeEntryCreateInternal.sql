create procedure [dbo].[DocumentTypeEntryCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs nvarchar(256),
			@ClassName varchar(256),
			@TableName nvarchar(128),
			@SchemaName nvarchar(128),
			@ClrTypeName varchar(1024),
			@DataAdapterTypeName varchar(1024),
			@DataAdapterMode varchar(32),
			@IsNumbered bit,
			@SmallImage varbinary(max),
			@LargeImage varbinary(max),
			@SupportsTransitionTemplates bit,
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'nvarchar(256)'),
		@ClassName = T.c.value('@ClassName', 'varchar(256)'),
		@TableName = T.c.value('@TableName', 'nvarchar(128)'),
		@SchemaName = T.c.value('@SchemaName', 'nvarchar(128)'),
		@ClrTypeName = T.c.value('@ClrTypeName', 'varchar(1024)'),
		@DataAdapterTypeName = T.c.value('@DataAdapterTypeName', 'varchar(1024)'),
		@DataAdapterMode = T.c.value('@DataAdapterMode', 'varchar(32)'),
		@IsNumbered = T.c.value('@IsNumbered', 'bit'),
		@SmallImage = T.c.value('@SmallImage', 'varbinary(max)'),
		@LargeImage = T.c.value('@LargeImage', 'varbinary(max)'),
		@SupportsTransitionTemplates = T.c.value('@SupportsTransitionTemplates', 'bit'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('DocumentTypeEntry') as T(c);

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[DocumentType]
		([Caption], [ClassName], [TableName], [SchemaName], [ClrTypeName], [DataAdapterTypeName],
		[DataAdapterType], [IsNumbered], [SmallImage], [LargeImage], [SupportsTransitionTemplates], [Description], 
		[Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(@FileAs, @ClassName, @TableName, @SchemaName, @ClrTypeName, @DataAdapterTypeName,
		@DataAdapterMode, @IsNumbered, @SmallImage, @LargeImage, @SupportsTransitionTemplates, @Comments,
		getdate(), @UserId, getdate(), @UserId);

	if @@error <> 0
	begin
		return 1;
	end

	set @Id = scope_identity();

	insert into [dbo].[DocumentState]
		([State], [DocumentTypeId], [OrdinalPosition], [Name], [Caption], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(0, @Id, 0, 'NotExist', N'Не существует', getdate(), @UserId, getdate(), @UserId),
		(1, @Id, 1, 'Draft', N'Черновик', getdate(), @UserId, getdate(), @UserId);

	if @@error <> 0
	begin
		return 1;
	end

	return 0;
end
