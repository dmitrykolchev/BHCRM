create procedure [dbo].[ServiceRequestGet] @Id TIdentifier
as
begin
	set nocount on;

	select [dbo].[ServiceRequestGetFn](@Id);

	return 0;
end
