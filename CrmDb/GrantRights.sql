declare cDocuments cursor local fast_forward read_only for select [ClassName] from [DocumentType] order by [ClassName];

open cDocuments;

declare @ClassName varchar(256), @sql nvarchar(max), @procName nvarchar(256);

fetch next from cDocuments into @ClassName;

while @@fetch_status = 0
begin
	set @procName = '[dbo].[' + @ClassName + 'Browse]';
	if  exists (select * from sys.objects where object_id = object_id(@procName) AND type in (N'P', N'PC'))
	begin
		set @sql = 'grant execute on ' + @procName + ' to public;';
		exec [sp_executesql] @sql;
	end;
	set @procName = '[dbo].[' + @ClassName + 'List]';
	if  exists (select * from sys.objects where object_id = object_id(@procName) AND type in (N'P', N'PC'))
	begin
		set @sql = 'grant execute on ' + @procName + ' to public;';
		exec [sp_executesql] @sql;
	end;
	set @procName = '[dbo].[' + @ClassName + 'Get]';
	if  exists (select * from sys.objects where object_id = object_id(@procName) AND type in (N'P', N'PC'))
	begin
		set @sql = 'grant execute on ' + @procName + ' to public;';
		exec [sp_executesql] @sql;
	end;
	set @procName = '[dbo].[' + @ClassName + 'Create]';
	if  exists (select * from sys.objects where object_id = object_id(@procName) AND type in (N'P', N'PC'))
	begin
		set @sql = 'grant execute on ' + @procName + ' to public;';
		exec [sp_executesql] @sql;
	end;
	set @procName = '[dbo].[' + @ClassName + 'Update]';
	if  exists (select * from sys.objects where object_id = object_id(@procName) AND type in (N'P', N'PC'))
	begin
		set @sql = 'grant execute on ' + @procName + ' to public;';
		exec [sp_executesql] @sql;
	end;
	set @procName = '[dbo].[' + @ClassName + 'ChangeState]';
	if  exists (select * from sys.objects where object_id = object_id(@procName) AND type in (N'P', N'PC'))
	begin
		set @sql = 'grant execute on ' + @procName + ' to public;';
		exec [sp_executesql] @sql;
	end;
	set @procName = '[dbo].[' + @ClassName + 'Delete]';
	if  exists (select * from sys.objects where object_id = object_id(@procName) AND type in (N'P', N'PC'))
	begin
		set @sql = 'grant execute on ' + @procName + ' to public;';
		exec [sp_executesql] @sql;
	end;
	fetch next from cDocuments into @ClassName;
end

close cDocuments;
deallocate cDocuments;

declare cViews cursor local fast_forward read_only for select [ViewName] from [DocumentView] where [ClassName] <> 'Virtual' order by [ViewName];
open cViews;
declare @ViewName varchar(256);
fetch next from cViews into @ViewName;

while @@fetch_status = 0
begin
	set @procName = '[dbo].[' + @ViewName + 'Browse]';
	if  exists (select * from sys.objects where object_id = object_id(@procName) AND type in (N'P', N'PC'))
	begin
		set @sql = 'grant execute on ' + @procName + ' to public;';
		exec [sp_executesql] @sql;
	end;
	set @procName = '[dbo].[' + @ViewName + 'List]';
	if  exists (select * from sys.objects where object_id = object_id(@procName) AND type in (N'P', N'PC'))
	begin
		set @sql = 'grant execute on ' + @procName + ' to public;';
		exec [sp_executesql] @sql;
	end;
	fetch next from cViews into @ViewName;
end

close cViews;
deallocate cViews;
go
