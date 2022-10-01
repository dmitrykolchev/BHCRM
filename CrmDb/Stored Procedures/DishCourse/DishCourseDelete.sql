create procedure [dbo].[DishCourseDelete] @Id TIdentifier
as
begin
	set nocount on;

	delete [dbo].[DishCourse] where [Id] = @Id;

	return 0;
end
