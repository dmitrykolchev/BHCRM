create procedure [dbo].[ContactUpdate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int, @AccountId TIdentifier;

	begin transaction;

	exec @result = [dbo].[ContactUpdateInternal] @xml, @Id out;
	if @@error <> 0 or @result <> 0
	begin
		rollback transaction;
		return 1;
	end;

	delete [dbo].[AccountMarketingProgramType] where [ContactId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end;

	select @AccountId = [AccountId] from [dbo].[Contact] where [Id] = @Id;

	insert into [AccountMarketingProgramType]
		([AccountId], [ContactId], [MarketingProgramTypeId])
	select 
		@AccountId,
		@Id,
		T.c.value('@Id', 'int')
	from 
		@xml.nodes('Contact/MarketingProgramTypes/MarketingProgramTypeSelector') as T(c)
	where
		T.c.value('@Selected', 'bit') = 1;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end;

	commit transaction;

	exec @result = [dbo].[ContactGet] @Id;

	return 0;
end
