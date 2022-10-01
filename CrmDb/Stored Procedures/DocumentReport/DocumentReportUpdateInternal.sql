create procedure [dbo].[DocumentReportUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Code varchar(128),
			@DocumentTypeId TIdentifier,
			@ReportPath nvarchar(1024),
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Code = T.c.value('@Code', 'varchar(128)'),
		@DocumentTypeId = T.c.value('@DocumentTypeId', 'TIdentifier'),
		@ReportPath = T.c.value('@ReportPath', 'nvarchar(1024)'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('DocumentReport') as T(c);
	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	update [dbo].[DocumentReport]
	set
		[FileAs] = @FileAs,
		[Code] = @Code,
		[DocumentTypeId] = @DocumentTypeId,
		[ReportPath] = @ReportPath,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @CurrentUserId
	where
		[Id] = @Id;

	if @@error <> 0
		return 1;

	return 0;
end
