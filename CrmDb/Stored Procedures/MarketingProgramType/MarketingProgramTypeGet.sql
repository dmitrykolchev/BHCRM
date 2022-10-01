create procedure [dbo].[MarketingProgramTypeGet] @Id TIdentifier
as
begin
	set nocount on;

	select
		[Id],
		[State],
		[FileAs],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[MarketingProgramType]
	where
		[Id] = @Id;

	return 0;
end
