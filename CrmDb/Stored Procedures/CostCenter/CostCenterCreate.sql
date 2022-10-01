create procedure [dbo].[CostCenterCreate]
	@FileAs TName,
	@AccountId TIdentifier,
	@Comments nvarchar(max)
as
begin
	set nocount on;

	declare @Id TIdentifier, @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[CostCenter]
		([State], [FileAs], [AccountId], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @AccountId, @Comments, getdate(), @UserId, getdate(), @UserId);

	set @Id = scope_identity();

	exec [dbo].[CostCenterGet] @Id;

	return 0;
end
