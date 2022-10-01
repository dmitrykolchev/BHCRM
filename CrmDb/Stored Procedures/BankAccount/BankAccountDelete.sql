create procedure [dbo].[BankAccountDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[BankAccount] where [Id] = @Id;

	return 0;
end
