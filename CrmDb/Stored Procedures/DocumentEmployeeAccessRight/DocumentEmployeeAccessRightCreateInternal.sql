create procedure [dbo].[DocumentEmployeeAccessRightCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@DocumentTypeId int,
			@DocumentId TIdentifier,
			@DocumentAccessTypeId TIdentifier,
			@EmployeeId TIdentifier,
			@StartDate date,
			@EndDate date;
	select
		@DocumentTypeId = T.c.value('@DocumentTypeId', 'int'),
		@DocumentId = T.c.value('@DocumentId', 'TIdentifier'),
		@DocumentAccessTypeId = T.c.value('@DocumentAccessTypeId', 'TIdentifier'),
		@EmployeeId = T.c.value('@EmployeeId', 'TIdentifier'),
		@StartDate = T.c.value('@StartDate', 'date'),
		@EndDate = T.c.value('@EndDate', 'date')
	from
		@xml.nodes('DocumentEmployeeAccessRight') as T(c);

	if @@error <> 0
		return 1;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[DocumentEmployeeAccessRight]
		([State], [DocumentTypeId], [DocumentId], [DocumentAccessTypeId], [EmployeeId], [StartDate],
		[EndDate], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @DocumentTypeId, @DocumentId, @DocumentAccessTypeId, @EmployeeId, @StartDate, @EndDate,
		getdate(), @UserId, getdate(), @UserId);

	if @@error <> 0
		return 1;

	set @Id = scope_identity();

	return 0;
end
