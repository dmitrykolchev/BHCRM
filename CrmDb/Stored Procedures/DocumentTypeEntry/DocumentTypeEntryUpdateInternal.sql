create procedure [dbo].[DocumentTypeEntryUpdateInternal] @xml xml, @Id TIdentifier out
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
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'int'),
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
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('DocumentTypeEntry') as T(c);
	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[DocumentType]
	set
		[Caption] = @FileAs,
		[ClassName] = @ClassName,
		[TableName] = @TableName,
		[SchemaName] = @SchemaName,
		[ClrTypeName] = @ClrTypeName,
		[DataAdapterTypeName] = @DataAdapterTypeName,
		[DataAdapterType] = @DataAdapterMode,
		[IsNumbered] = @IsNumbered,
		[SmallImage] = @SmallImage,
		[LargeImage] = @LargeImage,
		[SupportsTransitionTemplates] = @SupportsTransitionTemplates,
		[Description] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

	return 0;
end
