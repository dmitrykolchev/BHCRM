create procedure [dbo].[ProjectTaskTemplateDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[ProjectTaskTemplate] where [Id] = @Id;

	return 0;
end
