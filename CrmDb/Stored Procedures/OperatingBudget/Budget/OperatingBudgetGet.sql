create procedure [dbo].[OperatingBudgetGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'OperatingBudget';

	declare @MaxGroupId int;

	select @MaxGroupId = max([Id]) + 10 from [BudgetItemGroup];

	with [C] ([BudgetItemId], [CalculationStage], [TotalValue]) as
	(
		select 
			[BudgetItemId], 
			[CalculationStage], 
			sum([Amount] * [Price])
		from 
			[OperatingBudgetLine] 
		where 
			[OperatingBudgetId] = @Id 
		group by
			[BudgetItemId], [CalculationStage]
	),
	[BI] ([Id], [ParentId], [Level], [BudgetItemGroupId], [BudgetItemId], [Code], [FileAs]) as
	(
		select 1 as [Id], 0 as [ParentId], 0 as [Level], null as [BudgetItemGroupId],  null as [BudgetItemId], '0001' as [Code], N'Доходы' as [FileAs]
		union all
		select 2 as [Id], 0 as [ParentId], 0 as [Level], null as [BudgetItemGroupId],  null as [BudgetItemId], '0002' as [Code], N'Расходы' as [FileAs]
		union all
		select [Id] + 2 as [Id], 1 as [ParentId], 1 as [Level], [Id] as [BudgetItemGroupId], null as [BudgetItemId], [Code], [FileAs] from [BudgetItemGroup] where [BudgetItemGroupType] = 2 and [IsExpenseGroup] = 0
		union all
		select [Id] + 2 as [Id], 2 as [ParentId], 1 as [Level], [Id] as [BudgetItemGroupId], null as [BudgetItemId], [Code], [FileAs] from [BudgetItemGroup] where [BudgetItemGroupType] = 2 and [IsExpenseGroup] = 1
		union all
		select @MaxGroupId + [Id] as [Id], [BudgetItemGroupId] + 2 as [ParentId], 2 as [Level], [BudgetItemGroupId], [Id] as [BudgetItemId], [Code], [FileAs] from BudgetItem where BudgetItemGroupId in (select [Id] from [BudgetItemGroup] where [BudgetItemGroupType] = 2 and [IsExpenseGroup] = 0)
		union all
		select @MaxGroupId + [Id] as [Id], [BudgetItemGroupId] + 2 as [ParentId], 2 as [Level], [BudgetItemGroupId], [Id] as [BudgetItemId], [Code], [FileAs] from BudgetItem where BudgetItemGroupId in (select [Id] from [BudgetItemGroup] where [BudgetItemGroupType] = 2 and [IsExpenseGroup] = 1)
	),
	[Line] ([Id], [ParentId], [Level], [BudgetItemGroupId], [BudgetItemId], [Code], [FileAs], [PlannedValue], [ActualValue]) as
	(
		select
			[BI].[Id], 
			[BI].[ParentId], 
			[BI].[Level], 
			[BI].[BudgetItemGroupId], 
			[BI].[BudgetItemId], 
			[BI].[Code], 
			[BI].[FileAs],
			sum(case when [C].[CalculationStage] = 2 then [C].[TotalValue] else null end),
			sum(case when [C].[CalculationStage] = 3 then [C].[TotalValue] else null end)
		from
			[BI] left outer join [C]
				on ([BI].[BudgetItemId] = [C].[BudgetItemId])
		group by
			[BI].[Id], [BI].[ParentId], [BI].[Level], [BI].[BudgetItemGroupId], [BI].[BudgetItemId], [BI].[Code], [BI].[FileAs]
	)
	select
		[Id],
		[State],
		[FileAs],
		[Number],
		[DocumentDate],
		[OrganizationId],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion],
		(select
			[Id], [ParentId], [Level], [BudgetItemGroupId], [BudgetItemId], [Code], [FileAs], [PlannedValue], [ActualValue]
		from
			[Line] as [OperatingBudgetLine]
		order by [Level], [ParentId], [Code] 
		for xml auto, type) as [Lines],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[OperatingBudget] as [OperatingBudget]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
