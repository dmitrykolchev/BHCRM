create procedure [dbo].[DocumentStateLogCreateInternal] @DocumentClassName varchar(256), @DocumentId TIdentifier, @NewState TState, @Data xml, @Comments nvarchar(max)
as
begin
	declare @State TState, @DocumentTypeId int, @UserId int;

	select @DocumentTypeId = [dbo].[GetDocumentTypeId](@DocumentClassName);
	select @State = [State] from [dbo].[DocumentLog] where [DocumentTypeId] = @DocumentTypeId and [DocumentId] = @DocumentId;
	select @UserId = [dbo].[GetCurrentUserId]();
	if @NewState is null
		set @NewState = @State;

	insert into [dbo].[DocumentStateLog]
		([DocumentTypeId], [DocumentId], [Data], [FromState], [ToState], [Comments], [Created], [CreatedBy])
	values
		(@DocumentTypeId, @DocumentId, @Data, @State, @NewState, @Comments, getdate(), @UserId);
	if @@error <> 0
		return 1;

	return 0;
end