CREATE VIEW [dbo].[DocumentStateEntry]
as
	select
		[Id],
		[DocumentTypeId],
		cast(1 as tinyint) as [State],
		[State] as [Value],
		[OrdinalPosition],
		[Name] as [Code],
		[Caption] as [FileAs],
		[OverlayImage],
		[Description] as [Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from	
		[dbo].[DocumentState];