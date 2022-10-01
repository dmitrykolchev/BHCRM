create procedure [dbo].[DocumentStateLogGet] @Id TIdentifier
as
begin
	set nocount on;

	declare @DocumentTypeId int;

	select @DocumentTypeId = [Id] from [DocumentType] where [ClassName] = 'DocumentStateLog';

	select
		[Id],
		[DocumentTypeId],
		[DocumentId],
		[FromState],
		[ToState],
		[Comments],
		[Data],
		[Created],
		[CreatedBy]
	from
		[dbo].[DocumentStateLog] as [DocumentStateLog]
	where
		[Id] = @Id
		for xml auto, binary base64;

	return 0;
end
