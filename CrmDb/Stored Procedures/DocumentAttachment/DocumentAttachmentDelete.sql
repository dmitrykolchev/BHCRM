create procedure [dbo].[DocumentAttachmentDelete]
	@Id int
as
	set nocount on;
	
	delete [dbo].[DocumentAttachment]
	where
		[Id] = @Id;

	return 0;
