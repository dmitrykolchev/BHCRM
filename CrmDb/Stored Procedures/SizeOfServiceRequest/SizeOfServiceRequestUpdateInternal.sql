create procedure [dbo].[SizeOfServiceRequestUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@FileAs TName,
			@MinimumValue TAmount,
			@MaximumValue TAmount,
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@MinimumValue = T.c.value('@MinimumValue', 'TAmount'),
		@MaximumValue = T.c.value('@MaximumValue', 'TAmount'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('SizeOfServiceRequest') as T(c);
	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[SizeOfServiceRequest]
	set
		[FileAs] = @FileAs,
		[MinimumValue] = @MinimumValue,
		[MaximumValue] = @MaximumValue,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

	return 0;
end
