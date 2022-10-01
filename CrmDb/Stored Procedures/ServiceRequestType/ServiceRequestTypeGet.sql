create procedure [dbo].[ServiceRequestTypeGet] @Id TIdentifier
as
begin
	set nocount on;

	select
		[Id],
		[State],
		[FileAs],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[ServiceRequestType] as [ServiceRequestType]
	where
		[Id] = @Id
	for xml auto;

	return 0;
end
