CREATE PROCEDURE [dbo].[DishCourseUpdate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[DishCourseUpdateInternal] @xml, @Id out;

	exec [dbo].[DishCourseGet] @Id;

	return 0;
end
