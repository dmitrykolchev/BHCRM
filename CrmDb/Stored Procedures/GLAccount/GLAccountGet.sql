create procedure [dbo].[GLAccountGet] @Id TIdentifier
as
begin
	set nocount on;

	select
		[Id],
		[State],
		[FileAs],
		[Code],
		[ParentId],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[GLAccount]
	where
		[Id] = @Id;

	return 0;
end
