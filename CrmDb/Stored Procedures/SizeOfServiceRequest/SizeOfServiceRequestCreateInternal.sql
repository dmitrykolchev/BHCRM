create procedure [dbo].[SizeOfServiceRequestCreateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@MinimumValue TAmount,
			@MaximumValue TAmount,
			@Comments nvarchar(max);
	select
		@FileAs = T.c.value('@FileAs', 'TName'),
		@MinimumValue = T.c.value('@MinimumValue', 'TAmount'),
		@MaximumValue = T.c.value('@MaximumValue', 'TAmount'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('SizeOfServiceRequest') as T(c);

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[SizeOfServiceRequest]
		([State], [FileAs], [MinimumValue], [MaximumValue], [Comments], [Created], [CreatedBy], [Modified],
		[ModifiedBy])
	values
		(1, @FileAs, @MinimumValue, @MaximumValue, @Comments, getdate(), @UserId, getdate(), @UserId);

	set @Id = scope_identity();

	return 0;
end
