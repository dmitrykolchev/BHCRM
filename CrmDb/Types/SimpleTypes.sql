create type [dbo].[TIdentifier]	from int not null;
go
create type [dbo].[TState] from tinyint not null;
go
create type [dbo].[TName] from nvarchar(256) not null;
go
create type [dbo].[TSubject] from nvarchar(1024) not null;
go
create type [dbo].[TCode] from varchar(32) not null;
go
create type [dbo].[TPercent] from decimal(8,4) not null;
go
create type [dbo].[TMoney] from decimal(18,6) not null;
go
create type [dbo].[TAmount] from decimal(18,6) not null;
go


