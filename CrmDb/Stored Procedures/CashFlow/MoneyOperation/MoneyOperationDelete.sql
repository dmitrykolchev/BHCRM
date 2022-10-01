create procedure [dbo].[MoneyOperationDelete] @Id TIdentifier
as
begin
	set nocount on;


	begin transaction;
	
	declare @MoneyOperationTypeId TIdentifier, @ParentId TIdentifier;

	select @MoneyOperationTypeId = [MoneyOperationTypeId], @ParentId = [ParentId] from [MoneyOperation] where [Id] = @Id;

	if @MoneyOperationTypeId = 5
	begin
		if @ParentId is not null
		begin
			delete [dbo].[MoneyOperation] where [Id] = @Id;
			if @@error <> 0
			begin
				rollback transaction;
				return 1;
			end
			delete [dbo].[MoneyOperation] where [Id] = @ParentId;
			if @@error <> 0
			begin
				rollback transaction;
				return 1;
			end
		end
		else
		begin
			delete [dbo].[MoneyOperation] where [ParentId] = @Id;
			if @@error <> 0
			begin
				rollback transaction;
				return 1;
			end
			delete [dbo].[MoneyOperation] where [Id] = @Id;
			if @@error <> 0
			begin
				rollback transaction;
				return 1;
			end
		end
	end
	else
	begin
		delete [dbo].[MoneyOperation] where [ParentId] = @Id;
		if @@error <> 0
		begin
			rollback transaction;
			return 1;
		end

		delete [dbo].[MoneyOperation] where [Id] = @Id;
		if @@error <> 0
		begin
			rollback transaction;
			return 1;
		end
	end
	commit transaction

	return 0;
end
