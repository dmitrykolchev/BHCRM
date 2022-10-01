create procedure [dbo].[VenueUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare @result int;

	exec @result = [dbo].[AccountUpdateInternal] @xml, N'Venue', @Id out;

	declare	@VenuePlaceId TIdentifier,
			@PrimaryVenueTypeId TIdentifier,
			@SecondaryVenueTypeId TIdentifier,
			@Summer bit,
			@Winter bit,
			@MaximumNumberOfGuestsForBanquet int,
			@MaximumNumberOfGuestsForReception int,
			@CateringTypeId TIdentifier;
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@VenuePlaceId = T.c.value('@VenuePlaceId', 'TIdentifier'),
		@PrimaryVenueTypeId = T.c.value('@PrimaryVenueTypeId', 'TIdentifier'),
		@SecondaryVenueTypeId = T.c.value('@SecondaryVenueTypeId', 'TIdentifier'),
		@Summer = T.c.value('@Summer', 'bit'),
		@Winter = T.c.value('@Winter', 'bit'),
		@MaximumNumberOfGuestsForBanquet = T.c.value('@MaximumNumberOfGuestsForBanquet', 'int'),
		@MaximumNumberOfGuestsForReception = T.c.value('@MaximumNumberOfGuestsForReception', 'int'),
		@CateringTypeId = T.c.value('@CateringTypeId', 'TIdentifier')
	from
		@xml.nodes('Venue') as T(c);

	if exists(select * from [dbo].[VenueData] where [Id] = @Id)
	begin
		update [dbo].[VenueData]
		set
			[VenuePlaceId] = @VenuePlaceId,
			[PrimaryVenueTypeId] = @PrimaryVenueTypeId,
			[SecondaryVenueTypeId] = @SecondaryVenueTypeId,
			[Summer] = @Summer,
			[Winter] = @Winter,
			[MaximumNumberOfGuestsForBanquet] = @MaximumNumberOfGuestsForBanquet,
			[MaximumNumberOfGuestsForReception] = @MaximumNumberOfGuestsForReception,
			[CateringTypeId] = @CateringTypeId
		where
			[Id] = @Id;
	end
	else
	begin
		insert into [dbo].[VenueData]
			([Id], [VenuePlaceId], 
			[PrimaryVenueTypeId], [SecondaryVenueTypeId], [Summer], [Winter], [MaximumNumberOfGuestsForBanquet],
			[MaximumNumberOfGuestsForReception], [CateringTypeId])
		values
			(@Id, @VenuePlaceId, @PrimaryVenueTypeId, @SecondaryVenueTypeId, @Summer, @Winter,
			@MaximumNumberOfGuestsForBanquet, @MaximumNumberOfGuestsForReception, @CateringTypeId);
	end
	return 0;
end
