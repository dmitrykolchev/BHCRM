create procedure [dbo].[DivisionCreate]
	@FileAs TName,
	@AccountId TIdentifier,
	@HeadOfDivisionId TIdentifier,
	@Comments nvarchar(max)
as
begin
	set nocount on;

	declare @Id TIdentifier, @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[Division]
		([State], [FileAs], [AccountId], [HeadOfDivisionId], [Comments], [Created], [CreatedBy], [Modified],
		[ModifiedBy])
	values
		(1, @FileAs, @AccountId, @HeadOfDivisionId, @Comments, getdate(), @UserId, getdate(), @UserId);
	
	set @Id = scope_identity();

	exec [dbo].[DivisionGet] @Id;

	return 0;
end
