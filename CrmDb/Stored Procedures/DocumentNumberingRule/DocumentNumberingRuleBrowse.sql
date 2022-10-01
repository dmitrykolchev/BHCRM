create procedure [dbo].[DocumentNumberingRuleBrowse] @filter xml
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
		[dbo].[DocumentNumberingRule];

	return 0;
end
