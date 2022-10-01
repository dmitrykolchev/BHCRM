create procedure [dbo].[ItemColorGet] @Id TIdentifier
as
begin
	set nocount on;

	select
		[Id],
		[State],
		[FileAs],
		[ColorSample],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from
		[dbo].[ItemColor]
	where
		[Id] = @Id;

	return 0;
end
