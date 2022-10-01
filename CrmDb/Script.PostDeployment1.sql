/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
:r .\GrantRights.sql
:r .\UpdateMetadata.sql
:r .\CreateSystemTriggers.sql
:r .\PresentationNodeInitialize.sql

delete [CalculationStatementTotal];

with [T] ([CalculationStatementId], [TotalPrice], [TotalCost]) as
(
	select
		[CalculationStatement].[Id],
		sum([Amount] * isnull(datediff(minute, [StartTime], [EndTime]), 60) / cast(60 as decimal(8,2)) * [Price]),
		sum([Amount] * isnull(datediff(minute, [StartTime], [EndTime]), 60) / cast(60 as decimal(8,2)) * [Cost])
	from	
		[CalculationStatement] left outer join [CalculationStatementLine]
			on ([CalculationStatement].[Id] = [CalculationStatementLine].[CalculationStatementId])
	group by
		[CalculationStatement].[Id]
)
insert into [CalculationStatementTotal]
	([CalculationStatementId], [TotalCost], [TotalPrice])
select
	[CalculationStatementId],
	case when [CalculationStatement].[ExpenseBudgetItemId] is not null then [TotalCost] else null end,
	case when [CalculationStatement].[IncomeBudgetItemId] is not null then [TotalPrice] else null end
from
	[T] inner join [CalculationStatement]
		on ([T].[CalculationStatementId] = [CalculationStatement].[Id]);

go

:setvar TableName "MoneyOperationType"

set identity_insert [$(TableName)] on;

	declare @MoneyOperationType table (
		[Id] int not null, 
		[State] tinyint not null, 
		[FileAs] nvarchar(256) not null, 
		[Created] datetime not null default(getdate()), 
		[CreatedBy] int not null default(1), 
		[Modified] datetime not null default(getdate()), 
		[ModifiedBy] int not null default(1));

	delete @MoneyOperationType;

	insert into @MoneyOperationType
		([Id], [State], [FileAs])
	values
		(1, 1, 'Начальное сальдо/коррекция'),
		(2, 1, 'Оплата поставщику товаров/услуг'),
		(3, 1, 'Поступление ДС от клиентов'),
		(4, 1, 'Выдача ДС под отчет'),
		(5, 1, 'Перевод ДС'),
		(6, 1, 'Получение кредита/ссуды'),
		(7, 1, 'Расчеты с персоналом'),
		(8, 1, 'Возврат в кассу'),
		(9, 1, 'Расчеты к кредиторами'),
		(10, 1, 'Выдача кредита'),
		(11, 1, 'Расчеты с заемщиками');

	merge [$(TableName)] as [target]
	using(select [Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy] from @MoneyOperationType) as [source]
		([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
		on ([target].[Id] = [source].[Id])
	when matched then
		update
		set
			[State] = [source].[State],
			[FileAs] = [source].[FileAs],
			[Modified] = [source].[Modified],
			[ModifiedBy] = [source].[ModifiedBy]
	when not matched then
		insert
			([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
		values
			([source].[Id], [source].[State], [source].[FileAs], [source].[Created], [source].[CreatedBy], [source].[Modified], [source].[ModifiedBy]);

set identity_insert [$(TableName)] off;
go


:setvar TableName "TaxRate"

set identity_insert [$(TableName)] on;
if not exists(select * from [$(TableName)])
begin
	insert into [$(TableName)] 
		([Id], [State], [FileAs], [Value], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 1, 'Подоходный налог', 0.13, getdate(), 1, getdate(), 1),
		(2, 1, 'ЕСН', 0.30, getdate(), 1, getdate(), 1);
end
else
begin
	if exists(select * from [$(TableName)] where [Id] = 1)
		update [$(TableName)] set [FileAs] = 'Подоходный налог', [Value] = 0.13 where [Id]  = 1;
	else
		insert into [$(TableName)] ([Id], [State], [FileAs], [Value], [Created], [CreatedBy], [Modified], [ModifiedBy]) values (1, 1, 'Подоходный налог', 0.13, getdate(), 1, getdate(), 1);
	if exists(select * from [$(TableName)] where [Id] = 2)
		update [$(TableName)] set [FileAs] = 'ЕСН', [Value] = 0.30 where [Id]  = 2;
	else
		insert into [$(TableName)] ([Id], [State], [FileAs], [Value], [Created], [CreatedBy], [Modified], [ModifiedBy]) values (2, 1, 'ЕСН', 0.30, getdate(), 1, getdate(), 1);
end

set identity_insert [$(TableName)] off;
go

:setvar TableName "DocumentAccessControlList"

set identity_insert [$(TableName)] on;
if not exists(select * from [$(TableName)])
begin
	insert into [$(TableName)] 
		([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 1, 'Права доступа к документам', getdate(), 1, getdate(), 1);
end

set identity_insert [$(TableName)] off;
go

:setvar TableName "ExtraCostRate"

set identity_insert [$(TableName)] on;
if not exists(select * from [$(TableName)])
begin
	insert into [$(TableName)] 
		([Id], [State], [FileAs], [Value], [IsDefault], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 1, 'Ставка 7.5%', 0.075, 1, getdate(), 1, getdate(), 1),
		(2, 1, 'Ставка 9%', 0.09, 0, getdate(), 1, getdate(), 1);
end
else
begin
	if exists(select * from [$(TableName)] where [Id] = 1)
		update [$(TableName)] set [FileAs] = 'Ставка 7.5%', [Value] = 0.075, [IsDefault] = 1 where [Id]  = 1;
	else
		insert into [$(TableName)] ([Id], [State], [FileAs], [Value], [IsDefault], [Created], [CreatedBy], [Modified], [ModifiedBy]) values (1, 1, 'Ставка 7.5%', 0.075, 1, getdate(), 1, getdate(), 1);
	if exists(select * from [$(TableName)] where [Id] = 2)
		update [$(TableName)] set [FileAs] = 'Ставка 9%', [Value] = 0.09, [IsDefault] = 0 where [Id]  = 2;
	else
		insert into [$(TableName)] ([Id], [State], [FileAs], [Value], [IsDefault], [Created], [CreatedBy], [Modified], [ModifiedBy]) values (1, 1, 'Ставка 9%', 0.09, 0, getdate(), 1, getdate(), 1);
end

set identity_insert [$(TableName)] off;
go


:setvar TableName "VATRate"

set identity_insert [$(TableName)] on;
if not exists(select * from [$(TableName)])
begin
	insert into [$(TableName)] 
		([Id], [State], [FileAs], [Value], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 1, 'Без НДС', 0, getdate(), 1, getdate(), 1),
		(2, 1, 'НДС 18%', 0.18, getdate(), 1, getdate(), 1);
end
else
begin
	if exists(select * from [$(TableName)] where [Id] = 1)
		update [$(TableName)] set [FileAs] = 'Без НДС', [Value] = 0 where [Id]  = 1;
	else
		insert into [$(TableName)] ([Id], [State], [FileAs], [Value], [Created], [CreatedBy], [Modified], [ModifiedBy]) values (1, 1, 'Без НДС', 0, getdate(), 1, getdate(), 1);
	if exists(select * from [$(TableName)] where [Id] = 2)
		update [$(TableName)] set [FileAs] = 'НДС 18%', [Value] = 0.18 where [Id]  = 2;
	else
		insert into [$(TableName)] ([Id], [State], [FileAs], [Value], [Created], [CreatedBy], [Modified], [ModifiedBy]) values (2, 1, 'НДС 18%', 0.18, getdate(), 1, getdate(), 1);
end

set identity_insert [$(TableName)] off;
go


:setvar TableName "Importance"

set identity_insert [$(TableName)] on;
if not exists(select * from [$(TableName)])
begin
	insert into [$(TableName)] 
		([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 1, 'Низкая', getdate(), 1, getdate(), 1),
		(2, 1, 'Обычная', getdate(), 1, getdate(), 1),
		(3, 1, 'Высокая', getdate(), 1, getdate(), 1);
end
else
begin
	if exists(select * from [$(TableName)] where [Id] = 1)
		update [$(TableName)] set [FileAs] = 'Низкая' where [Id]  = 1;
	else
		insert into [$(TableName)] ([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy]) values (1, 1, 'Низкая', getdate(), 1, getdate(), 1);
	if exists(select * from [$(TableName)] where [Id] = 2)
		update [$(TableName)] set [FileAs] = 'Обычная' where [Id]  = 2;
	else
		insert into [$(TableName)] ([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy]) values (2, 1, 'Обычная', getdate(), 1, getdate(), 1);
	if exists(select * from [$(TableName)] where [Id] = 3)
		update [$(TableName)] set [FileAs] = 'Высокая' where [Id]  = 3;
	else
		insert into [$(TableName)] ([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy]) values (3, 1, 'Высокая', getdate(), 1, getdate(), 1);
end

set identity_insert [$(TableName)] off;
go

:setvar TableName "ProjectMemberRole"

set identity_insert [$(TableName)] on;
if not exists(select * from [$(TableName)])
begin
	insert into [$(TableName)] 
		([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 1, 'Руководитель проекта', getdate(), 1, getdate(), 1),
		(2, 1, 'Ответственный за продажу', getdate(), 1, getdate(), 1),
		(3, 1, 'Ответственный за подготовку', getdate(), 1, getdate(), 1),
		(4, 1, 'Ответственный за проведение', getdate(), 1, getdate(), 1),
		(5, 1, 'Ответственный за поиск', getdate(), 1, getdate(), 1);
end
else
begin
	--if exists(select * from [$(TableName)] where [Id] = 1)
	--	update [$(TableName)] set [FileAs] = 'Руководитель проекта' where [Id]  = 1;
	--else
	--	insert into [$(TableName)] ([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy]) values (1, 1, 'Руководитель проекта', getdate(), 1, getdate(), 1);
	--if exists(select * from [$(TableName)] where [Id] = 2)
	--	update [$(TableName)] set [FileAs] = 'Ответственный за продажу' where [Id]  = 2;
	--else
	--	insert into [$(TableName)] ([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy]) values (2, 1, 'Ответственный за продажу', getdate(), 1, getdate(), 1);
	--if exists(select * from [$(TableName)] where [Id] = 3)
	--	update [$(TableName)] set [FileAs] = 'Ответственный за подготовку' where [Id]  = 3;
	--else
	--	insert into [$(TableName)] ([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy]) values (3, 1, 'Ответственный за подготовку', getdate(), 1, getdate(), 1);
	--if exists(select * from [$(TableName)] where [Id] = 4)
	--	update [$(TableName)] set [FileAs] = 'Ответственный за проведение' where [Id]  = 4;
	--else
	--	insert into [$(TableName)] ([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy]) values (4, 1, 'Ответственный за проведение', getdate(), 1, getdate(), 1);
	--if exists(select * from [$(TableName)] where [Id] = 5)
	--	update [$(TableName)] set [FileAs] = 'Ответственный за поиск' where [Id]  = 5;
	--else
	--	insert into [$(TableName)] ([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy]) values (5, 1, 'Ответственный за поиск', getdate(), 1, getdate(), 1);
	if exists(select * from [$(TableName)] where [Id] = 1)
		update [$(TableName)] set [FileAs] = 'Лоббист' where [Id] = 1;
	else
		insert into [$(TableName)] ([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy]) values (1, 1, 'Лоббист', getdate(), 1, getdate(), 1);
	if exists(select * from [$(TableName)] where [Id] = 2)
		update [$(TableName)] set [FileAs] = 'Account Manager' where [Id] = 2;
	else
		insert into [$(TableName)] ([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy]) values (2, 1, 'Account Manager', getdate(), 1, getdate(), 1);
	if exists(select * from [$(TableName)] where [Id] = 3)
		update [$(TableName)] set [FileAs] = 'Project Assistant' where [Id] = 3;
	else
		insert into [$(TableName)] ([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy]) values (3, 1, 'Project Assistant', getdate(), 1, getdate(), 1);
	if exists(select * from [$(TableName)] where [Id] = 4)
		update [$(TableName)] set [FileAs] = 'Project Manager' where [Id] = 4;
	else
		insert into [$(TableName)] ([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy]) values (4, 1, 'Project Manager', getdate(), 1, getdate(), 1);
	if exists(select * from [$(TableName)] where [Id] = 5)
		update [$(TableName)] set [FileAs] = 'Account Assistant' where [Id] = 5;
	else
		insert into [$(TableName)] ([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy]) values (5, 1, 'Account Assistant', getdate(), 1, getdate(), 1);
	if exists(select * from [$(TableName)] where [Id] = 6)
		update [$(TableName)] set [FileAs] = 'Traffic Manager' where [Id] = 6;
	else
		insert into [$(TableName)] ([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy]) values (6, 1, 'Traffic Manager', getdate(), 1, getdate(), 1);
end

set identity_insert [$(TableName)] off;
go

:setvar TableName "SecurityScheme"

set identity_insert [$(TableName)] on;
if not exists(select * from [$(TableName)])
begin
	insert into [$(TableName)] 
		([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 1, 'Стандартная система прав доступа', getdate(), 1, getdate(), 1);
end

set identity_insert [$(TableName)] off;
go

:setvar TableName "PriceMargin"

set identity_insert [$(TableName)] on;
if not exists(select * from [$(TableName)])
begin
	insert into [$(TableName)] 
		([Id], [State], [FileAs], [Margin], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 1, 'Устанавливается индивидуально', 0, getdate(), 1, getdate(), 1);
end

set identity_insert [$(TableName)] off;
go

:setvar TableName "ContactRole"

set identity_insert [$(TableName)] on;
if not exists(select * from [$(TableName)])
begin
	insert into [$(TableName)] 
		([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 1, 'Принимает решение', getdate(), 1, getdate(), 1),
		(2, 1, 'Формирует мнение', getdate(), 1, getdate(), 1),
		(3, 1, 'Собирает информацию', getdate(), 1, getdate(), 1),
		(4, 1, 'Дополнительный', getdate(), 1, getdate(), 1);
end
else
begin
	if exists(select * from [$(TableName)] where [Id] = 1)
		update [$(TableName)] set [FileAs] = 'Принимает решение' where [Id]  = 1;
	else
		insert into [$(TableName)] ([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy]) values (1, 1, 'Принимает решение', getdate(), 1, getdate(), 1);
	if exists(select * from [$(TableName)] where [Id] = 2)
		update [$(TableName)] set [FileAs] = 'Формирует мнение' where [Id]  = 2;
	else
		insert into [$(TableName)] ([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy]) values (2, 1, 'Формирует мнение', getdate(), 1, getdate(), 1);
	if exists(select * from [$(TableName)] where [Id] = 3)
		update [$(TableName)] set [FileAs] = 'Собирает информацию' where [Id]  = 3;
	else
		insert into [$(TableName)] ([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy]) values (3, 1, 'Собирает информацию', getdate(), 1, getdate(), 1);
	if exists(select * from [$(TableName)] where [Id] = 4)
		update [$(TableName)] set [FileAs] = 'Дополнительный' where [Id]  = 4;
	else
		insert into [$(TableName)] ([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy]) values (4, 1, 'Дополнительный', getdate(), 1, getdate(), 1);
end
set identity_insert [$(TableName)] off;
go


:setvar TableName "Season"

set identity_insert [$(TableName)] on;
if not exists(select * from [$(TableName)])
begin
	insert into [$(TableName)] 
		([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 1, 'Зима', getdate(), 1, getdate(), 1),
		(2, 1, 'Весна', getdate(), 1, getdate(), 1),
		(3, 1, 'Лето', getdate(), 1, getdate(), 1),
		(4, 1, 'Осень', getdate(), 1, getdate(), 1);
end
else
begin
	if exists(select * from [$(TableName)] where [Id] = 1)
		update [$(TableName)] set [FileAs] = 'Зима' where [Id]  = 1;
	else
		insert into [$(TableName)] ([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy]) values (1, 1, 'Зима', getdate(), 1, getdate(), 1);
	if exists(select * from [$(TableName)] where [Id] = 2)
		update [$(TableName)] set [FileAs] = 'Весна' where [Id]  = 2;
	else
		insert into [$(TableName)] ([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy]) values (2, 1, 'Весна', getdate(), 1, getdate(), 1);
	if exists(select * from [$(TableName)] where [Id] = 3)
		update [$(TableName)] set [FileAs] = 'Лето' where [Id]  = 3;
	else
		insert into [$(TableName)] ([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy]) values (3, 1, 'Лето', getdate(), 1, getdate(), 1);
	if exists(select * from [$(TableName)] where [Id] = 4)
		update [$(TableName)] set [FileAs] = 'Осень' where [Id]  = 4;
	else
		insert into [$(TableName)] ([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy]) values (4, 1, 'Осень', getdate(), 1, getdate(), 1);
end
set identity_insert [$(TableName)] off;
go


:setvar TableName "CalculationStage"

set identity_insert [$(TableName)] on;
if not exists(select * from [$(TableName)])
begin
	insert into [$(TableName)] 
		([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 1, 'Норматив', getdate(), 1, getdate(), 1),
		(2, 1, 'План', getdate(), 1, getdate(), 1),
		(3, 1, 'Факт', getdate(), 1, getdate(), 1);
end

set identity_insert [$(TableName)] off;
go

:setvar TableName "BudgetItemGroup"

set identity_insert [$(TableName)] on;
if not exists(select * from [$(TableName)])
begin
	insert into [$(TableName)] 
		([Id], [State], [Code], [FileAs], [BudgetItemGroupType], [IsExpenseGroup], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 1, '0100', 'Доходы по ОВД', 1, 0, getdate(), 1, getdate(), 1),
		(2, 1, '0200', 'Расходы по ОВД', 1, 1, getdate(), 1, getdate(), 1),
		(3, 1, '0300', 'Прочие доходы', 1, 0, getdate(), 1, getdate(), 1),
		(4, 1, '0400', 'Прочие расходы', 1, 1, getdate(), 1, getdate(), 1);
end

set identity_insert [$(TableName)] off;
go

:setvar TableName "BudgetItem"

set identity_insert [$(TableName)] on;

	declare @BudgetItem table (
		[Id] int not null, 
		[State] tinyint not null, 
		[BudgetItemGroupId] int not null, 
		[Code] varchar(32) not null, 
		[FileAs] nvarchar(256) not null, 
		[Created] datetime not null default(getdate()), 
		[CreatedBy] int not null default(1), 
		[Modified] datetime not null default(getdate()), 
		[ModifiedBy] int not null default(1));

	delete @BudgetItem;

	insert into @BudgetItem
		([Id], [State], [BudgetItemGroupId], [Code], [FileAs])
	values
		(1, 1, 1, '0100', 'Меню'),
		(2, 1, 1, '0200', 'Напитки безалкогольные'),
		(3, 1, 1, '0300', 'Напитки алкогольные'),
		(4, 1, 1, '0400', 'Пробка'),
		(5, 1, 1, '0500', 'Персонал'),
		(6, 1, 1, '0600', 'Транспорт'),
		(7, 1, 1, '0700', 'Наценка'),
		(8, 1, 1, '0800', 'НДС'),
		(49, 1, 1, '0650', 'Прочие доходы'),

		(9, 1, 2, '2000', 'Продукты'),
		(10, 1, 2, '2100', 'Напитки безалкогольные'),
		(11, 1, 2, '2200', 'Напитки алкогольные'),
		(12, 1, 2, '2310', 'Персонал (Склад)'),
		(13, 1, 2, '2320', 'Персонал (Производство)'),
		(14, 1, 2, '2330', 'Персонал (Проведение)'),
		(15, 1, 2, '2400', 'Транспорт'),
		(39, 1, 2, '2450', 'Прачечная'),
		(16, 1, 2, '2500', 'Расходные материалы'),
		(17, 1, 2, '2600', 'Потери и бой'),
		(18, 1, 2, '2700', 'Комплексные обеды'),
		(19, 1, 2, '2800', 'Аренда оборудования'),
		(20, 1, 2, '2900', 'Такси'),
		(21, 1, 2, '3000', 'Конвертация'),
		(22, 1, 2, '3100', 'Прочие расходы'),
		(23, 1, 2, '3200', 'Комиссия посреднику'),
		(24, 1, 2, '3300', 'НДС'),

		(25, 1, 3, '5100', 'Дополнительные услуги РВО'),
		(26, 1, 3, '5200', 'Дополнительные услуги Event'),
		(27, 1, 3, '5300', 'Транзитные платежи'),
		(28, 1, 3, '5400', 'Агентские от подрядчика'),
		(29, 1, 3, '5500', 'Наценка'),
		(30, 1, 3, '5600', 'Прочее'),
		(31, 1, 3, '5700', 'НДС'),

		(32, 1, 4, '6100', 'Дополнительные услуги РВО'),
		(33, 1, 4, '6200', 'Дополнительные услуги Event'),
		(34, 1, 4, '6300', 'Транзитные платежи'),
		(35, 1, 4, '6400', 'Комиссия посреднику'),
		(36, 1, 4, '6500', 'Наценка'),
		(37, 1, 4, '6600', 'Прочее'),
		(38, 1, 4, '6700', 'НДС');

	--merge [$(TableName)] as [target]
	--using(select [Id], [State], [BudgetItemGroupId], [Code], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy] from @BudgetItem) as [source]
	--	([Id], [State], [BudgetItemGroupId], [Code], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
	--	on ([target].[Id] = [source].[Id])
	--when matched then
	--	update
	--	set
	--		[FileAs] = [source].[FileAs],
	--		[Created] = [source].[Created],
	--		[CreatedBy] = [source].[CreatedBy],
	--		[Modified] = [source].[Modified],
	--		[ModifiedBy] = [source].[ModifiedBy]
	--when not matched then
	--	insert
	--		([Id], [State], [BudgetItemGroupId], [Code], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
	--	values
	--		([source].[Id], [source].[State], [source].[BudgetItemGroupId], [source].[Code], [source].[FileAs], 
	--		[source].[Created], [source].[CreatedBy], [source].[Modified], [source].[ModifiedBy]);

	--delete [BudgetItem] where [Id] not in (select [Id] from @BudgetItem);

set identity_insert [$(TableName)] off;
go

:setvar TableName "AccountEventType"

set identity_insert [$(TableName)] on;
if not exists(select * from [$(TableName)])
begin
	insert into [$(TableName)] 
		([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 1, 'Телефонный звонок', getdate(), 1, getdate(), 1),
		(2, 1, 'Встреча', getdate(), 1, getdate(), 1),
		(3, 1, 'E-mail', getdate(), 1, getdate(), 1);
end

set identity_insert [$(TableName)] off;
go

:setvar TableName "AccountEventDirection"

set identity_insert [$(TableName)] on;
if not exists(select * from [$(TableName)])
begin
	insert into [$(TableName)] 
		([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 1, 'Исходящее', getdate(), 1, getdate(), 1),
		(2, 1, 'Входящее', getdate(), 1, getdate(), 1);
end

set identity_insert [$(TableName)] off;
go

:setvar TableName "DocumentAccessType"

set identity_insert [$(TableName)] on;
if not exists(select * from [$(TableName)])
begin
	insert into [$(TableName)] 
		([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 1, 'Основной', getdate(), 1, getdate(), 1),
		(2, 1, 'Дополнительный', getdate(), 1, getdate(), 1),
		(3, 1, 'Временный', getdate(), 1, getdate(), 1);
end

set identity_insert [$(TableName)] off;
go


:setvar TableName "GLAccount"

set identity_insert [$(TableName)] on;
if not exists(select * from [$(TableName)])
begin
	insert into [$(TableName)] 
		([Id], [State], [Code], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 1, '10000',	'Материалы', getdate(), 1, getdate(), 1),
		(2, 1, '10010', 'Сырье и материалы', getdate(), 1, getdate(), 1),
		(3, 1, '10020', 'Напитки', getdate(), 1, getdate(), 1),
		(4, 1, '10030', 'Сопутствующие товары', getdate(), 1, getdate(), 1),
		(5, 1, '10090', 'Инвентарь и хозяйственные принадлежности', getdate(), 1, getdate(), 1),
		(6, 1, '20000', 'Основное производство', getdate(), 1, getdate(), 1),
		(7, 1, '20010', 'Основное производство', getdate(), 1, getdate(), 1),
		(8, 1, '20011', 'Основное производство (по деятельности, не облагаемой ЕНВД)', getdate(), 1, getdate(), 1),
		(9, 1, '26000', 'Общехозяйственные расходы', getdate(), 1, getdate(), 1),
		(10, 1, '26010', 'Общехозяйственные расходы (по деятельности, не облагаемой ЕНВД)', getdate(), 1, getdate(), 1),
		(11, 1, '50000', 'Касса', getdate(), 1, getdate(), 1),
		(12, 1, '50010', 'Касса организации', getdate(), 1, getdate(), 1),
		(13, 1, '50020', 'Операционная касса', getdate(), 1, getdate(), 1),
		(14, 1, '50030', 'Денежные документы', getdate(), 1, getdate(), 1),
		(15, 1, '50210', 'Касса организации (в валюте)', getdate(), 1, getdate(), 1),
		(16, 1, '50230', 'Денежные документы (в валюте)', getdate(), 1, getdate(), 1),
		(17, 1, '51000', 'Расчетные счета', getdate(), 1, getdate(), 1),
		(18, 1, '52000', 'Валютные счета', getdate(), 1, getdate(), 1),
		(19, 1, '57000', 'Переводы в пути', getdate(), 1, getdate(), 1),
		(20, 1, '57100', 'Переводы в пути', getdate(), 1, getdate(), 1),
		(21, 1, '57200', 'Переводы в пути (в валюте)', getdate(), 1, getdate(), 1),
		(22, 1, '57110', 'Покупка иностранной валюты', getdate(), 1, getdate(), 1),
		(23, 1, '57220', 'Продажа иностранной валюты', getdate(), 1, getdate(), 1),
		(24, 1, '58000', 'Финансовые вложения', getdate(), 1, getdate(), 1),
		(25, 1, '58010', 'ВНЕШНИЙ', getdate(), 1, getdate(), 1),
		(26, 1, '58011', 'ВНЕШНИИ', getdate(), 1, getdate(), 1),
		(27, 1, '58020', 'ВНУТРЕННИЙ', getdate(), 1, getdate(), 1),
		(28, 1, '60000', 'Расчеты с поставщиками и подрядчиками', getdate(), 1, getdate(), 1),
		(29, 1, '60010', 'Расчеты с поставщиками и подрядчиками', getdate(), 1, getdate(), 1),
		(30, 1, '60011', 'Поставщики по ПРС (пассив)', getdate(), 1, getdate(), 1),
		(31, 1, '60012', 'Поставщики по операционным расходам (пассив)', getdate(), 1, getdate(), 1),
		(32, 1, '60020', 'Расчеты по авансам выданным', getdate(), 1, getdate(), 1),
		(33, 1, '60021', 'Поставщики по  ПРС (актив)', getdate(), 1, getdate(), 1),
		(34, 1, '60022', 'Поставщики по операционным расходам (актив)', getdate(), 1, getdate(), 1),
		(35, 1, '62000', 'Расчеты с покупателями и заказчиками', getdate(), 1, getdate(), 1),
		(36, 1, '62010', 'Расчеты с покупателями и заказчиками', getdate(), 1, getdate(), 1),
		(37, 1, '62020', 'Расчеты по авансам полученным', getdate(), 1, getdate(), 1),
		(38, 1, '66000', 'Расчеты по краткосрочным кредитам и займам', getdate(), 1, getdate(), 1),
		(39, 1, '66010', 'ВНЕШНИЙ', getdate(), 1, getdate(), 1),
		(40, 1, '66020', 'ВНУТРЕННИЙ', getdate(), 1, getdate(), 1),
		(41, 1, '70000', 'Расчеты с персоналом по оплате труда', getdate(), 1, getdate(), 1),
		(42, 1, '70010', 'Заработная плата', getdate(), 1, getdate(), 1),
		(43, 1, '70020', 'Бонусы', getdate(), 1, getdate(), 1),
		(44, 1, '71000', 'Расчеты с подотчетными лицами', getdate(), 1, getdate(), 1),
		(45, 1, '71010', 'Расчеты с подотчетными лицами', getdate(), 1, getdate(), 1),
		(46, 1, '80000', 'Уставный капитал', getdate(), 1, getdate(), 1),
		(47, 1, '80010', 'Обыкновенные акции', getdate(), 1, getdate(), 1),
		(48, 1, '80020', 'Привилегированные акции', getdate(), 1, getdate(), 1),
		(49, 1, '80090', 'Прочий капитал', getdate(), 1, getdate(), 1),
		(50, 1, '84000', 'Нераспределенная прибыль (непокрытый убыток)', getdate(), 1, getdate(), 1),
		(51, 1, '84010', 'Прибыль, подлежащая распределению', getdate(), 1, getdate(), 1),
		(52, 1, '84020', 'Убыток, подлежащий покрытию', getdate(), 1, getdate(), 1),
		(53, 1, '84030', 'Нераспределенная прибыль в обращении', getdate(), 1, getdate(), 1),
		(54, 1, '84040', 'Нераспределенная прибыль использованная', getdate(), 1, getdate(), 1),
		(55, 1, '90000', 'Продажи', getdate(), 1, getdate(), 1),
		(56, 1, '90010', 'Выручка', getdate(), 1, getdate(), 1),
		(57, 1, '90011', 'Выручка (по деятельности, не облагаемой ЕНВД)', getdate(), 1, getdate(), 1),
		(58, 1, '90012', 'Выручка (по деятельности, облагаемой ЕНВД)', getdate(), 1, getdate(), 1),
		(59, 1, '90020', 'Себестоимость продаж', getdate(), 1, getdate(), 1),
		(60, 1, '90021', 'Себестоимость продаж (по деятельности, не облагаемой ЕНВД)', getdate(), 1, getdate(), 1),
		(61, 1, '90022', 'Себестоимость продаж (по деятельности, облагаемой ЕНВД)', getdate(), 1, getdate(), 1),
		(62, 1, '90030', 'Налог на добавленную стоимость', getdate(), 1, getdate(), 1),
		(63, 1, '90040', 'Акцизы', getdate(), 1, getdate(), 1),
		(64, 1, '90050', 'Экспортные пошлины', getdate(), 1, getdate(), 1),
		(65, 1, '90070', 'Расходы на продажу', getdate(), 1, getdate(), 1),
		(66, 1, '90071', 'Расходы на продажу (по деятельности, не облагаемой ЕНВД)', getdate(), 1, getdate(), 1),
		(67, 1, '90072', 'Расходы на продажу (по деятельности, облагаемой ЕНВД)', getdate(), 1, getdate(), 1),
		(68, 1, '90080', 'Управленческие расходы', getdate(), 1, getdate(), 1),
		(69, 1, '90081', 'Управленческие расходы (по деятельности, не облагаемой ЕНВД)', getdate(), 1, getdate(), 1),
		(70, 1, '90082', 'Управленческие расходы (по деятельности, облагаемой ЕНВД)', getdate(), 1, getdate(), 1),
		(71, 1, '90090', 'Прибыль / убыток от продаж', getdate(), 1, getdate(), 1),
		(72, 1, '99000', 'Прибыли и убытки', getdate(), 1, getdate(), 1),
		(73, 1, '99010', 'Прибыли и убытки (за исключением налога на прибыль)', getdate(), 1, getdate(), 1),
		(74, 1, '99011', 'Прибыли и убытки (по деятельности, не облагаемой ЕНВД)', getdate(), 1, getdate(), 1),
		(75, 1, '99012', 'Прибыли и убытки (по деятельности облагаемой ЕНВД)', getdate(), 1, getdate(), 1),
		(76, 1, '99020', 'Налог на прибыль', getdate(), 1, getdate(), 1),
		(77, 1, '99021', 'Условный расход по налогу на прибыль', getdate(), 1, getdate(), 1),
		(78, 1, '99022', 'Условный доход по налогу на прибыль', getdate(), 1, getdate(), 1),
		(79, 1, '99023', 'Постоянное налоговое обязательство', getdate(), 1, getdate(), 1),
		(80, 1, '99024', 'Пересчет отложенных налоговых активов и обязательств', getdate(), 1, getdate(), 1);
end;
set identity_insert [$(TableName)] off;
go

:setvar TableName "ReasonType"

set identity_insert [$(TableName)] on;

if not exists(select * from [$(TableName)] where [Id] = 1)
	insert into [$(TableName)] 
		([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 1, 'Основной', getdate(), 1, getdate(), 1),
		(2, 1, 'Дополнительный', getdate(), 1, getdate(), 1);

set identity_insert [$(TableName)] off;
go

:setvar TableName "ProductType"

set identity_insert [$(TableName)] on;

if not exists(select * from [$(TableName)] where [Id] = 1)
	insert into [$(TableName)] 
		([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 1, 'Складируемый', getdate(), 1, getdate(), 1),
		(2, 1, 'Услуга', getdate(), 1, getdate(), 1),
		(3, 1, 'Основные средства', getdate(), 1, getdate(), 1),
		(4, 1, 'Производство', getdate(), 1, getdate(), 1);

if not exists(select * from [$(TableName)] where [Id] = 4)
	insert into [$(TableName)] 
		([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(4, 1, 'Производство', getdate(), 1, getdate(), 1);

set identity_insert [$(TableName)] off;
go

:setvar TableName "User"

set identity_insert [$(TableName)] on;

if not exists(select * from [$(TableName)] where [Id] = 1)
	insert into [$(TableName)] 
		([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 1, 'Администратор', getdate(), 1, getdate(), 1)

set identity_insert [$(TableName)] off;
go

:setvar TableName "ServiceLevel"

set identity_insert [$(TableName)] on;

if not exists(select * from [$(TableName)] where [Id] = 1)
	insert into [$(TableName)] 
		([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 1, 'Эконом', getdate(), 1, getdate(), 1),
		(2, 1, 'Стандарт', getdate(), 1, getdate(), 1),
		(3, 1, 'VIP', getdate(), 1, getdate(), 1)

set identity_insert [$(TableName)] off;
go

:setvar TableName "AccountType"

set identity_insert [$(TableName)] on;

declare @AccountType table (
	[Id] int not null, 
	[FileAs] nvarchar(256) not null);

delete @AccountType;

insert into @AccountType
	([Id], [FileAs])
values
	(1, 'Собственная организация'),
	(2, 'Поставщик'),
	(3, 'Покупатель'),
	(4, 'Сотрудник'),
	(5, 'Площадка');

merge [$(TableName)] as [target]
using(select [Id], [FileAs] from @AccountType) as [source] ([Id], [FileAs])
	on ([target].[Id] = [source].[Id])
when matched then
	update
	set
		[State] = 1,
		[FileAs] = [source].[FileAs],
		[Created] = getdate(),
		[CreatedBy] = 1,
		[Modified] = getdate(),
		[ModifiedBy] = 1
when not matched then
	insert
		([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		([source].[Id], 1, [source].[FileAs], getdate(), 1, getdate(), 1);

set identity_insert [$(TableName)] off;
go

:setvar TableName "OpportunityType"

set identity_insert [$(TableName)] on;

if not exists(select * from [$(TableName)])
	insert into [$(TableName)] 
		([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 1, 'Новый бизнес', getdate(), 1, getdate(), 1),
		(2, 1, 'Существующий бизнес', getdate(), 1, getdate(), 1);

set identity_insert [$(TableName)] off;
go

:setvar TableName "ServiceRequestType"

set identity_insert [$(TableName)] on;

if not exists(select * from [$(TableName)])
	insert into [$(TableName)] 
		([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 1, 'Аренда оборудования', getdate(), 1, getdate(), 1),
		(2, 1, 'Банкет', getdate(), 1, getdate(), 1),
		(3, 1, 'Барбекю', getdate(), 1, getdate(), 1),
		(4, 1, 'Гала-ужин', getdate(), 1, getdate(), 1),
		(5, 1, 'Коктейль', getdate(), 1, getdate(), 1),
		(6, 1, 'Кофе-брейк', getdate(), 1, getdate(), 1),
		(7, 1, 'Ланч', getdate(), 1, getdate(), 1),
		(8, 1, 'Фуршет', getdate(), 1, getdate(), 1),
		(9, 1, 'Шведский стол', getdate(), 1, getdate(), 1);

set identity_insert [$(TableName)] off;
go

:setvar TableName "ProjectType"

set identity_insert [$(TableName)] on;

if not exists(select * from [$(TableName)])
	insert into [$(TableName)] 
		([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 1, 'Административный', getdate(), 1, getdate(), 1),
		(2, 1, 'Коммерческий', getdate(), 1, getdate(), 1),
		(3, 1, 'Внутренний', getdate(), 1, getdate(), 1);

set identity_insert [$(TableName)] off;
go

:setvar TableName "LeadSource"

set identity_insert [$(TableName)] on;

if not exists(select * from [$(TableName)])
	insert into [$(TableName)] 
		([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 1, 'Холодный звонок', getdate(), 1, getdate(), 1),
		(2, 1, 'Существующий клиент', getdate(), 1, getdate(), 1),
		(3, 1, 'Сотрудник', getdate(), 1, getdate(), 1),
		(4, 1, 'Партнер', getdate(), 1, getdate(), 1),
		(5, 1, 'PR', getdate(), 1, getdate(), 1),
		(6, 1, 'Почтовая рассылка', getdate(), 1, getdate(), 1),
		(7, 1, 'Конференция', getdate(), 1, getdate(), 1),
		(8, 1, 'Выставка', getdate(), 1, getdate(), 1),
		(9, 1, 'Веб сайт', getdate(), 1, getdate(), 1),
		(10, 1, 'Email', getdate(), 1, getdate(), 1),
		(11, 1, 'Рекламная кампания', getdate(), 1, getdate(), 1);

set identity_insert [$(TableName)] off;
go

:setvar TableName "Reason"

set identity_insert [$(TableName)] on;

if not exists(select * from [$(TableName)])
	insert into [$(TableName)] 
		([Id], [State], [FileAs], [ReasonTypeId], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 1, 'Новогоднее мероприятие', 1, getdate(), 1, getdate(), 1),
		(2, 1, 'День рождения компании', 1, getdate(), 1, getdate(), 1),
		(3, 1, 'Выставочное мероприятие', 1, getdate(), 1, getdate(), 1),
		(4, 1, 'Деловое мероприятие', 1, getdate(), 1, getdate(), 1),
		(5, 1, 'День рождения руководства', 1, getdate(), 1, getdate(), 1),
		(6, 1, 'Календарное мероприятие', 1, getdate(), 1, getdate(), 1),
		(7, 1, 'Клиентское мероприятие', 1, getdate(), 1, getdate(), 1),
		(8, 1, 'Летнее мероприятие', 1, getdate(), 1, getdate(), 1),
		(9, 1, 'Отраслевое мероприятие', 1, getdate(), 1, getdate(), 1),
		(10, 1, 'Событийное мероприятие', 1, getdate(), 1, getdate(), 1),
		(11, 1, 'Частное мероприятие', 1, getdate(), 1, getdate(), 1),
		(12, 1, 'Повод не известен', 2, getdate(), 1, getdate(), 1),
		(13, 1, 'Прочее', 2, getdate(), 1, getdate(), 1);

set identity_insert [$(TableName)] off;
go

:setvar TableName "UnitOfMeasureClass"

set identity_insert [$(TableName)] on;

if not exists(select * from [$(TableName)])
	insert into [$(TableName)] 
		([Id], [State], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 1, 'Прочее', getdate(), 1, getdate(), 1),
		(2, 1, 'Вес', getdate(), 1, getdate(), 1),
		(3, 1, 'Объем', getdate(), 1, getdate(), 1),
		(4, 1, 'Длина', getdate(), 1, getdate(), 1),
		(5, 1, 'Мощность', getdate(), 1, getdate(), 1),
		(6, 1, 'Время', getdate(), 1, getdate(), 1)

set identity_insert [$(TableName)] off;
go

:setvar TableName "UnitOfMeasure"

set identity_insert [$(TableName)] on;

if not exists(select * from [$(TableName)])
	insert into [$(TableName)] 
		([Id], [State], [UnitOfMeasureClassId], [Code], [FileAs], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, 1, 2, 'кг', 'килограмм', getdate(), 1, getdate(), 1),
		(2, 1, 2, 'г', 'грамм', getdate(), 1, getdate(), 1),
		(3, 1, 1, 'шт', 'штуки', getdate(), 1, getdate(), 1),
		(4, 1, 1, 'уп', 'упаковка', getdate(), 1, getdate(), 1),
		(5, 1, 3, 'мл', 'миллилитр', getdate(), 1, getdate(), 1),
		(6, 1, 3, 'л', 'литр', getdate(), 1, getdate(), 1),
		(7, 1, 3, 'дал', 'декалитр', getdate(), 1, getdate(), 1),
		(8, 1, 4, 'см', 'сантиметр', getdate(), 1, getdate(), 1),
		(9, 1, 4, 'м', 'метр', getdate(), 1, getdate(), 1),
		(10, 1, 4, 'км', 'километр', getdate(), 1, getdate(), 1),
		(11, 1, 4, 'мм', 'миллиметр', getdate(), 1, getdate(), 1),
		(12, 1, 1, 'коробка', 'коробка', getdate(), 1, getdate(), 1),
		(13, 1, 1, 'рулон', 'рулон', getdate(), 1, getdate(), 1),
		(14, 1, 1, 'пара', 'пара', getdate(), 1, getdate(), 1),
		(15, 1, 1, 'чел', 'человек', getdate(), 1, getdate(), 1),
		(16, 1, 1, 'чел/ч', 'человеко-час', getdate(), 1, getdate(), 1),
		(17, 1, 6, 'ч', 'час', getdate(), 1, getdate(), 1),
		(18, 1, 6, 'мин', 'минута', getdate(), 1, getdate(), 1)

set identity_insert [$(TableName)] off;
go

declare employees cursor local forward_only read_only for
	select [Id] from [dbo].[Employee] where [EmployeeAccountId] is null and [IsEmployee] = 1;
open employees;

declare @Id TIdentifier, @EmployeeAccountId TIdentifier;

fetch next from employees into @Id;
while @@fetch_status = 0
begin
	begin transaction;

	insert into [dbo].[Account]
		([State], [FileAs], [AccountTypeId], [TradeMarkId], [Phone], [OtherPhone], [Email], [OtherEmail], [Comments],
		[Created], [CreatedBy], [Modified], [ModifiedBy])
	select
		[State], [FileAs], 0x08, [TradeMarkId], [BusinessPhone], [MobilePhone], [Email], [OtherEmail], [Comments], 
		[Created], [CreatedBy], [Modified], [ModifiedBy]
	from
		[Employee]
	where
		[Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		goto handle_error;
	end

	set @EmployeeAccountId = scope_identity();

	update [Employee]
	set
		[EmployeeAccountId] = @EmployeeAccountId
	where
		[Id] = @Id;
	if @@error <> 0
	begin
		rollback transaction;
		goto handle_error;
	end

	commit transaction;

	fetch next from employees into @Id;
end

handle_error:
	close employees;
	deallocate employees;

go