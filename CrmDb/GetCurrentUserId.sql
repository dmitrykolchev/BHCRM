create function [dbo].[GetCurrentUserId]()
returns TIdentifier as
begin
	declare @Id int;
	select @Id = [Id] from [dbo].[User] where [WindowsIdentity] = original_login() or [SqlIdentity] = original_login();
	if @Id is null and user_name() = 'dbo'
		set @Id = 1;
	return @Id;
end
