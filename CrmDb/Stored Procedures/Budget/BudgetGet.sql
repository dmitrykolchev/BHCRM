create procedure [dbo].[BudgetGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int, @ServiceRequestId TIdentifier, @AmountOfGuests int, @EventDuration int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'Budget';

	select @ServiceRequestId = [ServiceRequestId] from [Budget] where [Id] = @Id;
	select @AmountOfGuests = [AmountOfGuests], @EventDuration = [EventDuration] from [ServiceRequest] where [Id] = @ServiceRequestId;

	select
		[Id],
		[State],
		[FileAs],
		[Number],
		[DocumentDate],
		[OrganizationId],
		[ServiceRequestId],
		[BudgetTemplateId],
		isnull([AmountOfGuests], @AmountOfGuests) as [AmountOfGuests], 
		isnull([EventDuration], @EventDuration) as [EventDuration],
		[Value],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion],
		(select 
			[Id], 
			[BudgetId], 
			(select [BudgetItemGroupId] from [BudgetItem] where [Id] = [BudgetItemId]) as [BudgetItemGroupId], 
			[BudgetItemId], 
			(select min([State]) from [CalculationStatement] where [BudgetId] = @Id and [CalculationStage] = [BudgetLine].[CalculationStage] and ([IncomeBudgetItemId] = [BudgetItemId] or [ExpenseBudgetItemId] = [BudgetItemId])) as [CalculationState],
			[CalculationStage], 
			[Value] 
		from	
			[BudgetLine]
		where 
			[BudgetId] = @Id for xml auto, type) as [Lines],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[Budget] as [Budget]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
