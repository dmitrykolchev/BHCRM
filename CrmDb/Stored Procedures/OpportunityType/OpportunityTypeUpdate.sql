create procedure [dbo].[OpportunityTypeUpdate]
	@Id TIdentifier,
	@FileAs TName,
	@Comments nvarchar(max),
	@RowVersion timestamp
as
begin
	set nocount on;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[OpportunityType]
	set
		[FileAs] = @FileAs,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id and [RowVersion] = @RowVersion;

	exec [dbo].[OpportunityTypeGet] @Id;

	return 0;
end
