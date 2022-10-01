create procedure [dbo].[ProjectTemplateDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[ProjectTemplate] where [Id] = @Id;

	return 0;
end
