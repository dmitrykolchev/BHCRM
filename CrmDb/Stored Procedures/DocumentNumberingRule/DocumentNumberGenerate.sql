create procedure [dbo].[DocumentNumberGenerate] @ClassName varchar(256), @OrganizationId TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int, @DocumentNumberingRuleId TIdentifier, @Today date, @DocumentNumber int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = @ClassName;
	set @Today = getdate();

	select 
		@DocumentNumberingRuleId = [Id] 
	from 
		[DocumentNumberingRule] 
	where
		[DocumentTypeId] = @DocumentTypeId 
	and 
		[OrganizationId] = @OrganizationId 
	and 
		[State] = 1 
	and 
		(@Today >= [PeriodStart] and ([PeriodEnd] is null or @Today <= [PeriodEnd]));

	update [DocumentNumberingRule]
	set
		[Value] = [Value] + [Increment],
		@DocumentNumber = [Value]
	where	
		[Id] = @DocumentNumberingRuleId;
		
	select
		@DocumentNumber as [Number],
		[FormatString],
		[FileAsFormatString]
	from
		[DocumentNumberingRule]
	where
		[Id] = @DocumentNumberingRuleId;

	return 0;
end
go

grant execute on [dbo].[DocumentNumberGenerate] to [public];
go