create procedure [dbo].[SecuritySchemeDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[SecurityScheme] where [Id] = @Id;

	return 0;
end
