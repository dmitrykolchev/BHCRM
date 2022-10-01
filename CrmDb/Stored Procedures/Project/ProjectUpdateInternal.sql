create procedure [dbo].[ProjectUpdateInternal] @xml xml, @Id TIdentifier out
as
begin
	set nocount on;

	declare	@Code TCode,
			@FileAs TName,
			@ProjectTypeId TIdentifier,
			@OpportunityId TIdentifier,
			@OrganizationId TIdentifier,
			@ProjectManagerId TIdentifier,
			@AccountId TIdentifier,
			@ResponsibleContactId TIdentifier,
			@ContractId TIdentifier,
			@StartDate date,
			@EndDate date,
			@Comments nvarchar(max),
			@RowVersion binary(8);
	select
		@Id = T.c.value('@Id', 'TIdentifier'),
		@Code = T.c.value('@Code', 'TCode'),
		@FileAs = T.c.value('@FileAs', 'TName'),
		@ProjectTypeId = T.c.value('@ProjectTypeId', 'TIdentifier'),
		@OpportunityId = T.c.value('@OpportunityId', 'TIdentifier'),
		@OrganizationId = T.c.value('@OrganizationId', 'TIdentifier'),
		@ProjectManagerId = T.c.value('@ProjectManagerId', 'TIdentifier'),
		@AccountId = T.c.value('@AccountId', 'TIdentifier'),
		@ResponsibleContactId = T.c.value('@ResponsibleContactId', 'TIdentifier'),
		@ContractId = T.c.value('@ContractId', 'TIdentifier'),
		@StartDate = T.c.value('@StartDate', 'date'),
		@EndDate = T.c.value('@EndDate', 'date'),
		@Comments = T.c.value('@Comments', 'nvarchar(max)'),
		@RowVersion = T.c.value('@RowVersion', 'binary(8)')
	from
		@xml.nodes('Project') as T(c);
	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	update [dbo].[Project]
	set
		[Code] = @Code,
		[FileAs] = @FileAs,
		[ProjectTypeId] = @ProjectTypeId,
		[OpportunityId] = @OpportunityId,
		[OrganizationId] = @OrganizationId,
		[AccountId] = @AccountId,
		[ContractId] = @ContractId,
		[StartDate] = @StartDate,
		[EndDate] = @EndDate,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @CurrentUserId
	where
		[Id] = @Id;

	if @@error <> 0
		return 1;

	update [dbo].[ProjectMember]
	set
		[EmployeeId] = @ProjectManagerId,
		[Modified] = getdate(),
		[ModifiedBy] = @CurrentUserId
	where
		[ProjectId] = @Id and [ProjectMemberRoleId] = 1;
	if @@error <> 0
		return 1;

	update [dbo].[ProjectTask]
	set
		[AssignedToEmployeeId] = @ProjectManagerId
	where
		[ProjectMemberRoleId] = 1
	and
		[State] in (1, 2);
	if @@error <> 0
		return 1;

	return 0;
end
