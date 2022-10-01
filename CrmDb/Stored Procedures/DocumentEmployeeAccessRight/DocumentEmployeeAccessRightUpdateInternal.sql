create procedure [dbo].[DocumentEmployeeAccessRightUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@DocumentTypeId int,
			@DocumentId TIdentifier,
			@DocumentAccessTypeId TIdentifier,
			@EmployeeId TIdentifier,
			@StartDate date,
			@EndDate date,
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'int'),
		@DocumentTypeId = T.c.value('@DocumentTypeId', 'int'),
		@DocumentId = T.c.value('@DocumentId', 'TIdentifier'),
		@DocumentAccessTypeId = T.c.value('@DocumentAccessTypeId', 'TIdentifier'),
		@EmployeeId = T.c.value('@EmployeeId', 'TIdentifier'),
		@StartDate = T.c.value('@StartDate', 'date'),
		@EndDate = T.c.value('@EndDate', 'date'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('DocumentEmployeeAccessRight') as T(c);
	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[DocumentEmployeeAccessRight]
	set
		[DocumentTypeId] = @DocumentTypeId,
		[DocumentId] = @DocumentId,
		[DocumentAccessTypeId] = @DocumentAccessTypeId,
		[EmployeeId] = @EmployeeId,
		[StartDate] = @StartDate,
		[EndDate] = @EndDate,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

	return 0;
end
