create procedure [dbo].[VenueCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare @result int;

	exec @result = [dbo].[AccountCreateInternal] @xml, N'Venue', @Id out;

	declare	@AccountTypeId int,
			@VenuePlaceId TIdentifier,
			@PrimaryVenueTypeId TIdentifier,
			@SecondaryVenueTypeId TIdentifier,
			@Summer bit,
			@Winter bit,
			@MaximumNumberOfGuestsForBanquet int,
			@MaximumNumberOfGuestsForReception int,
			@CateringTypeId TIdentifier;
	select
		@AccountTypeId = T.c.value('@AccountTypeId', 'int'),
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

	update [dbo].[Account] set [AccountTypeId] = @AccountTypeId | 0x10 where [Id] = @Id;

	insert into [dbo].[VenueData]
		([Id], [VenuePlaceId], 
		[PrimaryVenueTypeId], [SecondaryVenueTypeId], [Summer], [Winter], [MaximumNumberOfGuestsForBanquet],
		[MaximumNumberOfGuestsForReception], [CateringTypeId])
	values
		(@Id, @VenuePlaceId, @PrimaryVenueTypeId, @SecondaryVenueTypeId, @Summer, @Winter,
		@MaximumNumberOfGuestsForBanquet, @MaximumNumberOfGuestsForReception, @CateringTypeId);

	return 0;
end
