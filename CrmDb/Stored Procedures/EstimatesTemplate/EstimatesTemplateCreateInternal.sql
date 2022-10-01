create procedure [dbo].[EstimatesTemplateCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('EstimatesTemplate') as T(c);

	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[EstimatesTemplate]
		([State], [FileAs], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @Comments, getdate(), @CurrentUserId, getdate(), @CurrentUserId);

	if @@error <> 0
		return 1;
	set @Id = scope_identity();

	insert into [dbo].[EstimatesTemplateSection]
		([EstimatesTemplateId], [OrdinalPosition], [FileAs], [ProductCategoryId], [Comments])
	select
		@Id,
		T.c.value('@OrdinalPosition', 'int'),
		T.c.value('@FileAs', 'TName'),
		T.c.value('@ProductCategoryId', 'TIdentifier'),
		T.c.value('@Comments', 'nvarchar(1024)')
	from
		@xml.nodes('EstimatesTemplate/Sections/EstimatesTemplateSection') as T(c)
	if @@error <> 0
		return 1;

	return 0;
end
