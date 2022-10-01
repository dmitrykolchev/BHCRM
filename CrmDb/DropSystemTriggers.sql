declare cDocuments cursor local fast_forward read_only 
for 
	select 
		[ClassName], [TableName] 
	from 
		[DocumentType] 
	where 
		[ClassName] not in('Virtual', 'DocumentEmployeeAccessRight', 'DocumentStateLog') 
	order by 
		[ClassName];

open cDocuments;

declare @ClassName varchar(256), @sql nvarchar(max), @procName nvarchar(256), @TableName nvarchar(128);

fetch next from cDocuments into @ClassName, @TableName;
while @@fetch_status = 0
begin
	declare @table nvarchar(256);
	set @table = '[dbo].[' + @ClassName + ']';
	if exists(select * from sys.objects where object_id = object_id(@table) and type = 'U')
	begin
		set @sql = 'if exists(select * from sys.objects where object_id = object_id(''[dbo].[sys{0}TriggerInsert]'') and type=''TR'') drop trigger [dbo].[sys{0}TriggerInsert]';
		set @sql = replace(@sql, '{0}', @ClassName);
		exec [sp_executesql] @sql;
		set @sql = 'if exists(select * from sys.objects where object_id = object_id(''[dbo].[sys{0}TriggerUpdate]'') and type=''TR'') drop trigger [dbo].[sys{0}TriggerUpdate]';
		set @sql = replace(@sql, '{0}', @ClassName);
		exec [sp_executesql] @sql;
		set @sql = 'if exists(select * from sys.objects where object_id = object_id(''[dbo].[sys{0}TriggerDelete]'') and type=''TR'') drop trigger [dbo].[sys{0}TriggerDelete]';
		set @sql = replace(@sql, '{0}', @ClassName);
		exec [sp_executesql] @sql;
	end
	fetch next from cDocuments into @ClassName, @TableName;
end

close cDocuments;
deallocate cDocuments;
go
