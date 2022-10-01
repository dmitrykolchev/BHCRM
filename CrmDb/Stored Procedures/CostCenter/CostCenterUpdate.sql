create procedure [dbo].[CostCenterUpdate]
	@Id TIdentifier,
	@FileAs TName,
	@AccountId TIdentifier,
	@Comments nvarchar(max),
	@RowVersion timestamp
as
begin
	set nocount on;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[CostCenter]
	set
		[FileAs] = @FileAs,
		[AccountId] = @AccountId,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

	exec [dbo].[CostCenterGet] @Id;

	return 0;
end
