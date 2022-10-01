create procedure [dbo].[DocumentLogGet] @DocumentTypeId TIdentifier, @DocumentId TIdentifier
as
begin
	set nocount on;

	select
		[DocumentTypeId],
		[DocumentId],
		[State],
		[FileAs],
		[Number],
		[OrganizationId],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[DocumentLog]
	where
		[DocumentId] = @DocumentId and [DocumentTypeId] = @DocumentTypeId;

	return 0;
end
