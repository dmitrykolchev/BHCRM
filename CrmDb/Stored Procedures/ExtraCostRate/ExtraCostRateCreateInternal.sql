create procedure [dbo].[ExtraCostRateCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@Value TPercent,
			@IsDefault bit,
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@Value = T.c.value('@Value', 'TPercent'),
		@IsDefault = T.c.value('@IsDefault', 'bit'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('ExtraCostRate') as T(c);

	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[ExtraCostRate]
		([State], [FileAs], [Value], [IsDefault], [Comments], [Created], [CreatedBy], [Modified],
		[ModifiedBy])
	values
		(1, @FileAs, @Value, @IsDefault, @Comments, getdate(), @CurrentUserId, getdate(), @CurrentUserId);

	if @@error <> 0
		return 1;
	set @Id = scope_identity();

	return 0;
end
