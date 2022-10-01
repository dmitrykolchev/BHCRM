CREATE PROCEDURE [dbo].[CalculationStatementDeleteBypassSecurityCheck] @Id TIdentifier with execute as 'InternalUser'
as
begin
	set nocount on;

	declare @result int;
	exec @result = [dbo].[CalculationStatementDeleteInternal] @Id;

	if @@error <> 0 or @result <> 0
		return 1;

	return 0;
end
