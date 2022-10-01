create procedure [dbo].[AccountEventTemplateDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[AccountEventTemplate] where [Id] = @Id;

	return 0;
end
