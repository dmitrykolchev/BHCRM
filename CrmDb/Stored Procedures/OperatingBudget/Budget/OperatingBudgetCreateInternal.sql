create procedure [dbo].[OperatingBudgetCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Number TCode,
			@DocumentDate date,
			@OrganizationId TIdentifier,
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Number = T.c.value('@Number', 'TCode'),
		@DocumentDate = T.c.value('@DocumentDate', 'date'),
		@OrganizationId = T.c.value('@OrganizationId', 'TIdentifier'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('OperatingBudget') as T(c);

	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[OperatingBudget]
		([State], [FileAs], [Number], [DocumentDate], [OrganizationId], [Comments], [Created], [CreatedBy],
		[Modified], [ModifiedBy])
	values
		(1, @FileAs, @Number, @DocumentDate, @OrganizationId, @Comments, getdate(), @CurrentUserId,
		getdate(), @CurrentUserId);

	if @@error <> 0
		return 1;
	set @Id = scope_identity();

	return 0;
end
