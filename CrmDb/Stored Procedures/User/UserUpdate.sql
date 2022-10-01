CREATE PROCEDURE [dbo].[UserUpdate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[UserUpdateInternal] @xml, @Id out;

	exec [dbo].[UserGet] @Id;

	return 0;
end
