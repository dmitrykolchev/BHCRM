CREATE FUNCTION [dbo].[GetAccountsOfEmployee]
(
	@EmployeeId TIdentifier
)
RETURNS @returntable TABLE
(
	[Id] TIdentifier not null
)
AS
BEGIN

	declare @DocumentTypeId TIdentifier;

	if @EmployeeId is null
		set @EmployeeId = [dbo].[GetCurrentEmployeeId]();

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'Account';

	insert into @returntable
	select distinct
		[DocumentId]
	from
		[dbo].[DocumentEmployeeAccessRight]
	where
		[DocumentTypeId] = @DocumentTypeId
	and
		[EmployeeId] = @EmployeeId
	and
		(
			([DocumentAccessTypeId] in (1, 2) and getdate() >= [StartDate])
		or 
			([DocumentAccessTypeId] = 3 and getdate() between [StartDate] and [EndDate])
		)
	union
	select
		[Id]
	from
		[dbo].[Account]
	where
		[AssignedToEmployeeId] = @EmployeeId or [AssistantEmployeeId] = @EmployeeId
	return
end
