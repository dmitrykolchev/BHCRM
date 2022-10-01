CREATE TABLE [dbo].[VenueData]
(
	[Id] TIdentifier not null primary key,
	[VenuePlaceId] TIdentifier null,
	[PrimaryVenueTypeId] TIdentifier null,
	[SecondaryVenueTypeId] TIdentifier null,
	[Summer] bit not null default(0),
	[Winter] bit not null default(0),
	[MaximumNumberOfGuestsForBanquet] int null,
	[MaximumNumberOfGuestsForReception] int null,
	[CateringTypeId] TIdentifier null, 
    CONSTRAINT [FK_VenueData_VenuePlace] FOREIGN KEY ([VenuePlaceId]) REFERENCES [VenuePlace]([Id]), 
    CONSTRAINT [FK_VenueData_PrimaryVenueType] FOREIGN KEY ([PrimaryVenueTypeId]) REFERENCES [VenueType]([Id]), 
    CONSTRAINT [FK_VenueData_SecondaryVenueType] FOREIGN KEY ([SecondaryVenueTypeId]) REFERENCES [VenueType]([Id]), 
    CONSTRAINT [FK_VenueData_Account] FOREIGN KEY ([Id]) REFERENCES [Account]([Id]) ON DELETE CASCADE
)
