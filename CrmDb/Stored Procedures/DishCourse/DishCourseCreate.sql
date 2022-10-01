CREATE PROCEDURE [dbo].[DishCourseCreate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[DishCourseCreateInternal] @xml, @Id out;

	exec [dbo].[DishCourseGet] @Id;

	return 0;
end
