create procedure [dbo].[ProjectCreateInternal] @xml xml, @Id TIdentifier out
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
			@Comments nvarchar(max);
	select
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
		@Comments = T.c.value('@Comments', 'nvarchar(max)')
	from
		@xml.nodes('Project') as T(c);

	if @@error <> 0
		return 1;

	declare @CurrentUserId int;

	set @CurrentUserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[Project]
		([State], [Code], [FileAs], [ProjectTypeId], [OpportunityId], [OrganizationId],
		[AccountId], [ResponsibleContactId], [ContractId], [StartDate], [EndDate], [Comments], [Created], [CreatedBy], [Modified],
		[ModifiedBy])
	values
		(1, @Code, @FileAs, @ProjectTypeId, @OpportunityId, @OrganizationId, @AccountId, @ResponsibleContactId,
		@ContractId, @StartDate, @EndDate, @Comments, getdate(), @CurrentUserId, getdate(), @CurrentUserId);

	if @@error <> 0
		return 1;
	set @Id = scope_identity();

	if @ProjectManagerId is not null
	begin
		declare @EmployeeFileAs TName;
		select @EmployeeFileAs = [FileAs] from [dbo].[Employee] where [Id] = @ProjectManagerId;

		insert into [dbo].[ProjectMember]
			([State], [FileAs], [ProjectId], [EmployeeId], [ProjectMemberRoleId], [Created], [CreatedBy], [Modified], [ModifiedBy])
		values
			(1, @EmployeeFileAs, @Id, @ProjectManagerId, 1, getdate(), @CurrentUserId, getdate(), @CurrentUserId);
		if @@error <> 0
			return 1;

		insert into [dbo].[ProjectMember]
			([State], [FileAs], [ProjectId], [EmployeeId], [ProjectMemberRoleId], [Created], [CreatedBy], [Modified], [ModifiedBy])
		select
			1, [FileAs], @Id, null, [Id], getdate(), @CurrentUserId, getdate(), @CurrentUserId
		from
			[ProjectMemberRole]
		where
			[Id] > 1;
		if @@error <> 0
			return 1;
	end
	else
	begin
		insert into [dbo].[ProjectMember]
			([State], [FileAs], [ProjectId], [EmployeeId], [ProjectMemberRoleId], [Created], [CreatedBy], [Modified], [ModifiedBy])
		select
			1, [FileAs], @Id, null, [Id], getdate(), @CurrentUserId, getdate(), @CurrentUserId
		from
			[ProjectMemberRole];
		if @@error <> 0
			return 1;
	end

	return 0;
end
