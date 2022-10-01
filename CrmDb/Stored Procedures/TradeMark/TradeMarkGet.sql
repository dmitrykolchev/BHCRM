create procedure [dbo].[TradeMarkGet] @Id TIdentifier
as
begin
	set nocount on;

	select
		[Id],
		[State],
		[FileAs],
		[BusinessActivityTypeId],
		[OrganizationId],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[TradeMark] as [TradeMark]
	where
		[Id] = @Id
	for xml auto;

	return 0;
end
