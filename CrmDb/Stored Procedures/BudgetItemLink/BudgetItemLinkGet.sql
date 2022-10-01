create procedure [dbo].[BudgetItemLinkGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'BudgetItemLink';

	select
		[Id],
		[State],
		[FileAs],
		[IncomeBudgetItemId],
		[ExpenseBudgetItemId],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[BudgetItemLink] as [BudgetItemLink]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
