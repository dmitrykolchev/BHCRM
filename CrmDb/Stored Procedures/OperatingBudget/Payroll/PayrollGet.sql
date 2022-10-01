create procedure [dbo].[PayrollGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int = [dbo].[GetDocumentTypeId]('Payroll');
	declare @SalaryBudgetItemId TIdentifier,
			@TaxBudgetItemId TIdentifier,
			@CashingBudgetItemId TIdentifier;

	select 
		@SalaryBudgetItemId = [SalaryBudgetItemId],
		@TaxBudgetItemId = [TaxBudgetItemId],
		@CashingBudgetItemId = [CashingBudgetItemId]
	from
		[dbo].[Payroll]
	where
		[Id] = @Id;
	

	with [L1] ([OperatingBudgetLineId], [OperatingBudgetId], [CalculationStage], [DocumentTypeId], [DocumentId], [BudgetItemId], [Tag], [OrdinalPosition], [AccountId], [FileAs], [Comments], [Amount], [Price]) as
	(
		select * from [dbo].[GetOperatingBudgetLines](@DocumentTypeId, @Id, @SalaryBudgetItemId, 1)
	),
	[L2] ([OperatingBudgetLineId], [OperatingBudgetId], [CalculationStage], [DocumentTypeId], [DocumentId], [BudgetItemId], [Tag], [OrdinalPosition], [AccountId], [FileAs], [Comments], [Amount], [Price]) as
	(
		select * from  [dbo].[GetOperatingBudgetLines](@DocumentTypeId, @Id, @SalaryBudgetItemId, 2)
	),
	[L3] ([OperatingBudgetLineId], [OperatingBudgetId], [CalculationStage], [DocumentTypeId], [DocumentId], [BudgetItemId], [Tag], [OrdinalPosition], [AccountId], [FileAs], [Comments], [Amount], [Price]) as
	(
		select * from  [dbo].[GetOperatingBudgetLines](@DocumentTypeId, @Id, @TaxBudgetItemId, 3)
	),
	[L4] ([OperatingBudgetLineId], [OperatingBudgetId], [CalculationStage], [DocumentTypeId], [DocumentId], [BudgetItemId], [Tag], [OrdinalPosition], [AccountId], [FileAs], [Comments], [Amount], [Price]) as
	(
		select * from  [dbo].[GetOperatingBudgetLines](@DocumentTypeId, @Id, @TaxBudgetItemId, 4)
	),
	[L5] ([OperatingBudgetLineId], [OperatingBudgetId], [CalculationStage], [DocumentTypeId], [DocumentId], [BudgetItemId], [Tag], [OrdinalPosition], [AccountId], [FileAs], [Comments], [Amount], [Price]) as
	(
		select * from  [dbo].[GetOperatingBudgetLines](@DocumentTypeId, @Id, @CashingBudgetItemId, 5)
	),
	[PayrollLine] ([OrdinalPosition], [AccountId], [EmployeeId], [DivisionId], [PositionId], [FileAs], [Comments], [SalaryTotal], [SalaryBase], [IncomeTax], [SocialTax], [Cashing]) as
	(
		select
			[L1].[OrdinalPosition],
			[L1].[AccountId],
			[Employee].[Id],
			[Employee].[DivisionId],
			[Employee].[PositionId],
			[L1].[FileAs],
			[L1].[Comments],
			[L1].[Price] + [L2].[Price],
			[L2].[Price],
			[L3].[Price],
			[L4].[Price],
			[L5].[Price]
		from
			[L1] inner join [L2] on
				([L1].[OrdinalPosition] = [L2].[OrdinalPosition])
			inner join [L3] on
				([L1].[OrdinalPosition] = [L3].[OrdinalPosition])
			inner join [L4] on
				([L1].[OrdinalPosition] = [L4].[OrdinalPosition])
			inner join [L5] on
				([L1].[OrdinalPosition] = [L5].[OrdinalPosition])
			left outer join [Employee] on
				([L1].[AccountId] = [Employee].[EmployeeAccountId])
	)
	select
		[Id],
		[State],
		[FileAs],
		[Number],
		[DocumentDate],
		[OrganizationId],
		[OperatingBudgetId],
		[SalaryBudgetItemId],
		[TaxBudgetItemId],
		[CashingBudgetItemId],
		[ExtraCostRateId],
		[CalculationStage],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion],
		(select
			[OrdinalPosition],
			[AccountId],
			[EmployeeId],
			[DivisionId],
			[PositionId],
			[FileAs],
			[Comments],
			[SalaryTotal],
			[SalaryBase],
			[IncomeTax],
			[SocialTax],
			[Cashing]
		from
			[PayrollLine]
		order by 
			[OrdinalPosition] for xml auto, type) as [Lines],
		(select
			[Id], [BlobId], [BlobName] as [Name]
		from
			[DocumentAttachment] as [AttachmentItem]
		where
			[DocumentId] = @Id and [DocumentTypeId] = @DocumentTypeId for xml auto, type) as [Attachments]
	from
		[dbo].[Payroll] as [Payroll]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
