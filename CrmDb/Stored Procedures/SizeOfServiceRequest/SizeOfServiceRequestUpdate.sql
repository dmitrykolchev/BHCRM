create procedure [dbo].[SizeOfServiceRequestUpdate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[SizeOfServiceRequestUpdateInternal] @xml, @Id out;

	exec @result = [dbo].[SizeOfServiceRequestGet] @Id;

	return 0;
end
