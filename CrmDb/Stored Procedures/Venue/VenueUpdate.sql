CREATE PROCEDURE [dbo].[VenueUpdate] @xml xml
as
begin
	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[VenueUpdateInternal] @xml, @Id out;

	delete [AccountReason] where [AccountId] = @Id;

	insert into [AccountReason]
		([AccountId], [ReasonId])
	select 
		@Id,
		T.c.value('@Id', 'int')
	from 
		@xml.nodes('Venue/Reasons/ReasonSelector') as T(c)
	where
		T.c.value('@Selected', 'bit') = 1;

	delete [AccountMarketingProgramType] where [AccountId] = @Id and [ContactId] is null;

	insert into [AccountMarketingProgramType]
		([AccountId], [ContactId], [MarketingProgramTypeId])
	select 
		@Id,
		null,
		T.c.value('@Id', 'int')
	from 
		@xml.nodes('Venue/MarketingProgramTypes/MarketingProgramTypeSelector') as T(c)
	where
		T.c.value('@Selected', 'bit') = 1;

	exec [dbo].[VenueGet] @Id;

	return 0;
end
