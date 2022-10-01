create procedure [dbo].[PriceMarginCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Margin TPercent,
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Margin = T.c.value('@Margin', 'TPercent'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('PriceMargin') as T(c);

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[PriceMargin]
		([State], [FileAs], [Margin], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @Margin, @Comments, getdate(), @UserId, getdate(), @UserId);

	set @Id = scope_identity();

	return 0;
end
