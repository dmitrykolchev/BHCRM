module [modulename]

define enum [enumname] as
(
	entry1 [= literal],
	entry2 [= literal],
	...
	entryN [= literal]
);

define const [constname] [typename] = literal;


define [ctename](@param1 typename, @param2 typename, ..., @paramN typename) 
returns ([field1], [field2], ..., [fieldN]) as
(
	select statement
)

define [expressionname] (@param1, @param2, @param3) returns [typename] as expression(@param1, @param2, ..., @param3);

define [inlinename] (@param1, @param2, @param3) as
(
	statement1;
	statement2;
	...
	statementN;
)


select
	[A].[Id],
	[tablename].[Id]
from
	[modulename].[ctename](@p1, @p2) as [A] inner join [tablename]
		on ([A].[Id] = [tablename].[Id]);

