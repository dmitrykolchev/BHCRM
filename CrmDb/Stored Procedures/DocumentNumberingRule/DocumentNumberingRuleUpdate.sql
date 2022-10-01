create procedure [dbo].[DocumentNumberingRuleUpdate]
	@Id TIdentifier,
	@FileAs TName,
	@OrganizationId TIdentifier,
	@DocumentTypeId TIdentifier,
	@PeriodStart date,
	@PeriodEnd date,
	@Value int,
	@Increment int,
	@FormatString nvarchar(256),
	@FileAsFormatString nvarchar(256),
	@Comments nvarchar(max),
	@RowVersion timestamp
as
begin
	set nocount on;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[DocumentNumberingRule]
	set
		[FileAs] = @FileAs,
		[OrganizationId] = @OrganizationId,
		[DocumentTypeId] = @DocumentTypeId,
		[PeriodStart] = @PeriodStart,
		[PeriodEnd] = @PeriodEnd,
		[Value] = @Value,
		[Increment] = @Increment,
		[FormatString] = @FormatString,
		[FileAsFormatString] = @FileAsFormatString,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

	exec [dbo].[DocumentNumberingRuleGet] @Id;

	return 0;
end
