create procedure [dbo].[SizeOfServiceRequestDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[SizeOfServiceRequest] where [Id] = @Id;

	return 0;
end
