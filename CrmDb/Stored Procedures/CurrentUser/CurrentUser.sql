CREATE VIEW [dbo].[CurrentUser]
AS 
	select
		[Id],
		[State],
		[FileAs],
		[FirstName],
		[MiddleName],
		[LastName],
		[WindowsIdentity],
		[SqlIdentity],
		[Comments],
		[Created],
		[CreatedBy],
		[Modified],
		[ModifiedBy],
		[RowVersion]
	from	
		[dbo].[User]
	where
		[Id] = [dbo].[GetCurrentUserId]();
