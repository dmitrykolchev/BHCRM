create procedure [dbo].[AccountEventTemplateCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@AccountEventTypeId TIdentifier,
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@AccountEventTypeId = T.c.value('@AccountEventTypeId', 'TIdentifier'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('AccountEventTemplate') as T(c);

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[AccountEventTemplate]
		([State], [FileAs], [AccountEventTypeId], [Comments], [Created], [CreatedBy], [Modified],
		[ModifiedBy])
	values
		(1, @FileAs, @AccountEventTypeId, @Comments, getdate(), @UserId, getdate(), @UserId);

	set @Id = scope_identity();

	return 0;
end
