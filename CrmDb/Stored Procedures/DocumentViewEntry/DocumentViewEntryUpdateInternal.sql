create procedure [dbo].[DocumentViewEntryUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs nvarchar(256),
			@ClassName varchar(256),
			@ViewName varchar(256),
			@TableName nvarchar(128),
			@SchemaName nvarchar(128),
			@ClrTypeName varchar(1024),
			@DataAdapterTypeName varchar(1024),
			@DataAdapterMode varchar(32),
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'int'),
		@FileAs = T.c.value('@FileAs', 'nvarchar(256)'),
		@ClassName = T.c.value('@ClassName', 'varchar(256)'),
		@ViewName = T.c.value('@ViewName', 'varchar(256)'),
		@TableName = T.c.value('@TableName', 'nvarchar(128)'),
		@SchemaName = T.c.value('@SchemaName', 'nvarchar(128)'),
		@ClrTypeName = T.c.value('@ClrTypeName', 'varchar(1024)'),
		@DataAdapterTypeName = T.c.value('@DataAdapterTypeName', 'varchar(1024)'),
		@DataAdapterMode = T.c.value('@DataAdapterMode', 'varchar(32)'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('DocumentViewEntry') as T(c);
	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[DocumentView]
	set
		[Caption] = @FileAs,
		[ClassName] = @ClassName,
		[ViewName] = @ViewName,
		[TableName] = @TableName,
		[SchemaName] = @SchemaName,
		[ClrTypeName] = @ClrTypeName,
		[DataAdapterTypeName] = @DataAdapterTypeName,
		[DataAdapterType] = @DataAdapterMode,
		[Description] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

	return 0;
end
