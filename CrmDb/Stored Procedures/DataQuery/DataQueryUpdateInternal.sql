create procedure [dbo].[DataQueryUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@DocumentElement varchar(256),
			@Selector varchar(1024),
			@Value varchar(1024),
			@SchemaName nvarchar(128),
			@ProcedureName nvarchar(128),
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@DocumentElement = T.c.value('@DocumentElement', 'varchar(256)'),
		@Selector = T.c.value('@Selector', 'varchar(1024)'),
		@Value = T.c.value('@Value', 'varchar(1024)'),
		@SchemaName = T.c.value('@SchemaName', 'nvarchar(128)'),
		@ProcedureName = T.c.value('@ProcedureName', 'nvarchar(128)'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('DataQuery') as T(c);
	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	update [dbo].[DataQuery]
	set
		[FileAs] = @FileAs,
		[DocumentElement] = @DocumentElement,
		[Selector] = @Selector,
		[Value] = @Value,
		[SchemaName] = @SchemaName,
		[ProcedureName] = @ProcedureName,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @CurrentUserId
	where
		[Id] = @Id;

	if @@error <> 0
		return 1;

	return 0;
end
