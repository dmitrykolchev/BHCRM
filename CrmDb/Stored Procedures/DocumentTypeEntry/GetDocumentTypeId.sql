create function [dbo].[GetDocumentTypeId] (@ClassName varchar(256))
returns int
as
begin
	return (select [Id] from [dbo].[DocumentType] where [ClassName] = @ClassName);
end
