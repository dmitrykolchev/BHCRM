create procedure [dbo].[EmployeeDelete] @Id TIdentifier
as
begin
	set nocount on;

	begin transaction;

	delete [dbo].[EmployeeSalary] where [EmployeeId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	declare @EmployeeAccountId TIdentifier;

	select @EmployeeAccountId = [EmployeeAccountId] from [Employee] where [Id] = @Id;

	delete [dbo].[Employee] where [Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [dbo].[Account] where [Id] = @EmployeeAccountId;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction;

	return 0;
end
