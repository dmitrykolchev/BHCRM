create procedure [dbo].[PresentationNodeDelete] @Id TIdentifier
as
begin
	set nocount on;

	begin transaction;
	declare @NodeType int;

	delete [PresentationNodeApplicationRole] where [PresentationNodeId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	update [dbo].[PresentationNode] set @NodeType = [NodeType], [DefaultViewId] = null where [Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end
	if @NodeType = 2 -- PresentationSet
	begin
		delete [dbo].[PresentationNode] where [ParentId] = @Id;
		if @@error <> 0
		begin
			rollback transaction;
			return 1;
		end
	end

	delete [dbo].[PresentationNode] where [Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction

	return 0;
end
