create procedure [dbo].[BudgetTemplateGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'BudgetTemplate';

	select
		[Id],
		[State],
		[FileAs],
		[ServiceRequestTypeId],
		[ServiceLevelId],
		[AmountOfPersons],
		[EventDuration],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion],
		(select * from [BudgetTemplateLine] where [BudgetTemplateId] = @Id for xml auto, type) as [Lines],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[BudgetTemplate] as [BudgetTemplate]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
