create procedure [dbo].[AccountGet] @Id TIdentifier
as
begin
	set nocount on;

	select [dbo].[AccountGetFn](@Id);

	return 0;
end
