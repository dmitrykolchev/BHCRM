create procedure [dbo].[DivisionUpdate]
	@Id TIdentifier,
	@FileAs TName,
	@AccountId TIdentifier,
	@HeadOfDivisionId TIdentifier,
	@Comments nvarchar(max),
	@RowVersion timestamp
as
begin
	set nocount on;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[Division]
	set
		[FileAs] = @FileAs,
		[AccountId] = @AccountId,
		[HeadOfDivisionId] = @HeadOfDivisionId,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

	exec [dbo].[DivisionGet] @Id;

	return 0;
end
