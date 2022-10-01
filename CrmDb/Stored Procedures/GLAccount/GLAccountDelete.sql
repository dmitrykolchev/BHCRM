create procedure [dbo].[GLAccountDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[GLAccount] where [Id] = @Id;

	return 0;
end
