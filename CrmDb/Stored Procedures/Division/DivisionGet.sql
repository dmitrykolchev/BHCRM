create procedure [dbo].[DivisionGet] @Id TIdentifier
as
begin
	set nocount on;

	select
		[Id],
		[State],
		[FileAs],
		[AccountId],
		[HeadOfDivisionId],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[Division]
	where
		[Id] = @Id;

	return 0;
end
