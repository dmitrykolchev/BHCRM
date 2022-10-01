create procedure [dbo].[TradeMarkCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@BusinessActivityTypeId TIdentifier,
			@OrganizationId TIdentifier,
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@BusinessActivityTypeId = T.c.value('@BusinessActivityTypeId', 'TIdentifier'),
		@OrganizationId = T.c.value('@OrganizationId', 'TIdentifier'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('TradeMark') as T(c);

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[TradeMark]
		([State], [FileAs], [BusinessActivityTypeId], [OrganizationId], [Comments], [Created], [CreatedBy],
		[Modified], [ModifiedBy])
	values
		(1, @FileAs, @BusinessActivityTypeId, @OrganizationId, @Comments, getdate(), @UserId, getdate(),
		@UserId);

	set @Id = scope_identity();

	return 0;
end
