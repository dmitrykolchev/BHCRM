create function [dbo].[GetCurrentEmployeeId]()
returns TIdentifier
as
begin
	declare @Id TIdentifier;
	
	set @Id = [dbo].GetCurrentUserId();
	
	select @Id = [Id] from [Employee] where [UserId] = @Id;

	return @Id;
end
