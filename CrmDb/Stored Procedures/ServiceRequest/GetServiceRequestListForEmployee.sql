create function [dbo].[GetServiceRequestListForEmployee]
(
	@EmployeeId TIdentifier
)
returns @returntable table
(
	[Id] TIdentifier
)
as
begin
	insert into @returntable
	select 
		[Id]
	from 
		[ServiceRequest] 
	where
		[ServiceRequest].[ProjectId] in (
			select [ProjectId] from [ProjectMember] where [EmployeeId] = @EmployeeId and [State] = 1)
	return
end
