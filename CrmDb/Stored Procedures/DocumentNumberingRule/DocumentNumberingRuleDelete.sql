create procedure [dbo].[DocumentNumberingRuleDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[DocumentNumberingRule] where [Id] = @Id;

	return 0;
end
