CREATE TABLE [dbo].[EstimatesTemplateSection]
(
	[EstimatesTemplateSectionId] int not null identity primary key,
	[EstimatesTemplateId] TIdentifier not null,
	[OrdinalPosition] int not null, 
	[FileAs] TName not null,
	[ProductCategoryId] TIdentifier not null,
	[Comments] nvarchar(1024) null,
    CONSTRAINT [FK_EstimatesTemplatSection_EstimatesTemplate] FOREIGN KEY ([EstimatesTemplateId]) REFERENCES [EstimatesTemplate]([Id]), 
    CONSTRAINT [FK_EstimatesTemplateSection_ProductCategory] FOREIGN KEY ([ProductCategoryId]) REFERENCES [ProductCategory]([Id]),

)
