create procedure [dbo].[DocumentViewEntryCreateInternal] @xml xml, @Id TIdentifier out
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
			@BrowseAccessRightId TIdentifier;
	select
		@FileAs = T.c.value('@FileAs', 'nvarchar(256)'),
		@ClassName = T.c.value('@ClassName', 'varchar(256)'),
		@ViewName = T.c.value('@ViewName', 'varchar(256)'),
		@TableName = T.c.value('@TableName', 'nvarchar(128)'),
		@SchemaName = T.c.value('@SchemaName', 'nvarchar(128)'),
		@ClrTypeName = T.c.value('@ClrTypeName', 'varchar(1024)'),
		@DataAdapterTypeName = T.c.value('@DataAdapterTypeName', 'varchar(1024)'),
		@DataAdapterMode = T.c.value('@DataAdapterMode', 'varchar(32)'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('DocumentViewEntry') as T(c);

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[DocumentView]
		([Caption], [ClassName], [ViewName], [TableName], [SchemaName], [ClrTypeName],
		[DataAdapterTypeName], [DataAdapterType], [Description], [Created], [CreatedBy],
		[Modified], [ModifiedBy])
	values
		(@FileAs, @ClassName, @ViewName, @TableName, @SchemaName, @ClrTypeName, @DataAdapterTypeName,
		@DataAdapterMode, @Comments, getdate(), @UserId, getdate(), @UserId);

	set @Id = scope_identity();

	return 0;
end
