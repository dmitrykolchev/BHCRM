create procedure [dbo].[ProjectDelete] @Id TIdentifier
as
begin
	set nocount on;

	if exists(select * from [dbo].[ServiceRequest] where [ProjectId] = @Id)
		throw 50489, '���������� ������� ������. ���������� ����� ����������, ��������� � ���� ��������.', 1;

	begin transaction;

	delete [dbo].[ProjectMember] where [ProjectId] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	delete [dbo].[Project] where [Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		return 1;
	end

	commit transaction

	return 0;
end
