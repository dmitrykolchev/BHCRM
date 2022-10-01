create procedure [dbo].[DocumentNumberingRuleCreate]
	@FileAs TName,
	@OrganizationId TIdentifier,
	@DocumentTypeId TIdentifier,
	@PeriodStart date,
	@PeriodEnd date,
	@Value int,
	@Increment int,
	@FormatString nvarchar(256),
	@FileAsFormatString nvarchar(256),
	@Comments nvarchar(max)
as
begin
	set nocount on;

	declare @Id TIdentifier, @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[DocumentNumberingRule]
		([State], [FileAs], [OrganizationId], [DocumentTypeId], [PeriodStart], [PeriodEnd], [Value],
		[Increment], [FormatString], [FileAsFormatString], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @OrganizationId, @DocumentTypeId, @PeriodStart, @PeriodEnd, @Value, @Increment,
		@FormatString, @FileAsFormatString, @Comments, getdate(), @UserId, getdate(), @UserId);

	set @Id = scope_identity();

	exec [dbo].[DocumentNumberingRuleGet] @Id;

	return 0;
end
