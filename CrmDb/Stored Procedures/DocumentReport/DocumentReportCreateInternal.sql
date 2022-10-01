create procedure [dbo].[DocumentReportCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Code varchar(128),
			@DocumentTypeId TIdentifier,
			@ReportPath nvarchar(1024),
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Code = T.c.value('@Code', 'varchar(128)'),
		@DocumentTypeId = T.c.value('@DocumentTypeId', 'TIdentifier'),
		@ReportPath = T.c.value('@ReportPath', 'nvarchar(1024)'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('DocumentReport') as T(c);

	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[DocumentReport]
		([State], [Code], [FileAs], [DocumentTypeId], [ReportPath], [Comments], [Created], [CreatedBy], [Modified],
		[ModifiedBy])
	values
		(1, @Code, @FileAs, @DocumentTypeId, @ReportPath, @Comments, getdate(), @CurrentUserId, getdate(),
		@CurrentUserId);

	if @@error <> 0
		return 1;
	set @Id = scope_identity();

	return 0;
end
