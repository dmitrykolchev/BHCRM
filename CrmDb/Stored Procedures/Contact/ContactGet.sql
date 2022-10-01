create procedure [dbo].[ContactGet] @Id TIdentifier
as
begin
	set nocount on;
	select [dbo].[ContactGetFn](@Id);
	return 0;
end
