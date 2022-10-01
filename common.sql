declare
	@AllStates bit,
	@Presentation varchar(256),
	@PeriodStart date, 
	@PeriodEnd date, 
	@OrganizationId TIdentifier


select
    @Id = T.c.value('Id[1]', 'TIdentifier'),
    @Presentation = T.c.value('Presentation[1]', 'varchar(256)'),
    @PeriodStart = T.c.value('PeriodStart[1]', 'date'),
    @PeriodEnd = T.c.value('PeriodEnd[1]', 'date'),
    @AllStates = T.c.value('AllStates[1]', 'bit')
from
    @filter.nodes('/Filter') as T(c)
where
    (@AllStates = 1 or [Budget].[State] in (select T.c.value('.[1]', 'tinyint') from @filter.nodes('Filter/State') as T(c)))


if @PeriodStart is null
    set @PeriodStart = '2000-01-01';
if @PeriodEnd is null
    set @PeriodEnd = '3000-01-01';
