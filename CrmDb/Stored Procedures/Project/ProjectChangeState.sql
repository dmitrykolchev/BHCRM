create procedure [dbo].[ProjectChangeState] @Id TIdentifier, @NewState TState
as
begin
	set nocount on;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[Project]
	set
		[State] = @NewState,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;


	return 0;
end
