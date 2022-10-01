create procedure [dbo].[DataQueryCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@DocumentElement varchar(256),
			@Selector varchar(1024),
			@Value varchar(1024),
			@SchemaName nvarchar(128),
			@ProcedureName nvarchar(128),
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@DocumentElement = T.c.value('@DocumentElement', 'varchar(256)'),
		@Selector = T.c.value('@Selector', 'varchar(1024)'),
		@Value = T.c.value('@Value', 'varchar(1024)'),
		@SchemaName = T.c.value('@SchemaName', 'nvarchar(128)'),
		@ProcedureName = T.c.value('@ProcedureName', 'nvarchar(128)'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('DataQuery') as T(c);

	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[DataQuery]
		([State], [FileAs], [DocumentElement], [Selector], [Value], [SchemaName], [ProcedureName],
		[Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @DocumentElement, @Selector, @Value, @SchemaName, @ProcedureName, @Comments, getdate(),
		@CurrentUserId, getdate(), @CurrentUserId);

	if @@error <> 0
		return 1;
	set @Id = scope_identity();

	return 0;
end
