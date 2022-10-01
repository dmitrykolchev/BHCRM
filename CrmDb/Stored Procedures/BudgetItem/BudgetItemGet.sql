create procedure [dbo].[BudgetItemGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'BudgetItem';

	select
		[Id],
		[State],
		[Code],
		[FileAs],
		[BudgetItemGroupId],
		[BudgetItemType],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion],
		(select * from [dbo].[BudgetItemProductCategory] as [ProductCategory] where [BudgetItemId] = @Id for xml auto, type) as [Lines],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[BudgetItem] as [BudgetItem]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
