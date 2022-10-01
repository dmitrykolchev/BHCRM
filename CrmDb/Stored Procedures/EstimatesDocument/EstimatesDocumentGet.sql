create procedure [dbo].[EstimatesDocumentGet] @Id TIdentifier
as
begin
	set nocount on;
	select [dbo].[EstimatesDocumentGetFn](@Id);
	return 0;
end
