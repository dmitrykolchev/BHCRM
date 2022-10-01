create procedure [dbo].[AccountUpdate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	begin transaction;

	exec @result = [dbo].[AccountUpdateInternal] @xml, N'Account', @Id out;
	if @@error <> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [AccountReason] where [AccountId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	insert into [AccountReason]
		([AccountId], [ReasonId])
	select 
		@Id,
		T.c.value('@Id', 'int')
	from 
		@xml.nodes('Account/Reasons/ReasonSelector') as T(c)
	where
		T.c.value('@Selected', 'bit') = 1;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [AccountMarketingProgramType] where [AccountId] = @Id and [ContactId] is null;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	insert into [AccountMarketingProgramType]
		([AccountId], [ContactId], [MarketingProgramTypeId])
	select 
		@Id,
		null,
		T.c.value('@Id', 'int')
	from 
		@xml.nodes('Account/MarketingProgramTypes/MarketingProgramTypeSelector') as T(c)
	where
		T.c.value('@Selected', 'bit') = 1;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end
	commit transaction;
	exec [dbo].[AccountGet] @Id;

	return 0;
end
