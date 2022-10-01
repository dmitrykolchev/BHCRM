create procedure [dbo].[DocumentNumberingRuleGet] @Id TIdentifier
as
begin
	set nocount on;

	select
		[Id],
		[State],
		[FileAs],
		[OrganizationId],
		[DocumentTypeId],
		[PeriodStart],
		[PeriodEnd],
		[Value],
		[Increment],
		[FormatString],
		[FileAsFormatString],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[DocumentNumberingRule]
	where
		[Id] = @Id;

	return 0;
end
