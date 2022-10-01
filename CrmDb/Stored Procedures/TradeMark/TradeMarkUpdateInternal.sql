create procedure [dbo].[TradeMarkUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@BusinessActivityTypeId TIdentifier,
			@OrganizationId TIdentifier,
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@BusinessActivityTypeId = T.c.value('@BusinessActivityTypeId', 'TIdentifier'),
		@OrganizationId = T.c.value('@OrganizationId', 'TIdentifier'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('TradeMark') as T(c);
	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[TradeMark]
	set
		[FileAs] = @FileAs,
		[BusinessActivityTypeId] = @BusinessActivityTypeId,
		[OrganizationId] = @OrganizationId,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

	return 0;
end
