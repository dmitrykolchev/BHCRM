create procedure [dbo].[ContractDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[Contract] where [Id] = @Id;

	return 0;
end
