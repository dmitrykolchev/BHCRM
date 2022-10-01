CREATE TABLE [dbo].[MasterMenuData]
(
	[Id] TIdentifier not null primary key, 
    [DishIngredientId] TIdentifier null,
	[DishTypeId] TIdentifier null,
	[DishSubtypeId] TIdentifier null, 
	[DishCourseId] TIdentifier null,
	[DishOccasionId] TIdentifier null,
	[DishWorldId] TIdentifier null,
	[DishServingMask] TIdentifier null,
	[DishCookingMethodId] TIdentifier null,
	[SeasonMask] int default(0),
    [ServiceRequestTypeMask] int null default(0), 
    [ServingAmount] TAmount null, 
    CONSTRAINT [FK_MasterMenu_DishIngredient] FOREIGN KEY ([DishIngredientId]) REFERENCES [DishIngredient]([Id]), 
	CONSTRAINT [FK_MasterMenu_DishType] FOREIGN KEY ([DishTypeId]) REFERENCES [DishType]([Id]), 
	CONSTRAINT [FK_MasterMenu_DishSubtype] FOREIGN KEY ([DishSubtypeId]) REFERENCES [DishSubtype]([Id]), 
	CONSTRAINT [FK_MasterMenu_DishCourse] FOREIGN KEY ([DishCourseId]) REFERENCES [DishCourse]([Id]), 
	CONSTRAINT [FK_MasterMenu_DishOccasion] FOREIGN KEY ([DishOccasionId]) REFERENCES [DishOccasion]([Id]), 
	CONSTRAINT [FK_MasterMenu_DishWorld] FOREIGN KEY ([DishWorldId]) REFERENCES [DishWorld]([Id]), 
	CONSTRAINT [FK_MasterMenu_DishCookingMethod] FOREIGN KEY ([DishCookingMethodId]) REFERENCES [DishCookingMethod]([Id]), 
    CONSTRAINT [FK_MasterMenu_Product] FOREIGN KEY ([Id]) REFERENCES [Product]([Id])
)
