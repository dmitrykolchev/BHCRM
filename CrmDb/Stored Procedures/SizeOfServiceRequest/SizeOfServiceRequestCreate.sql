﻿create procedure [dbo].[SizeOfServiceRequestCreate] @xml xml
as
begin
	set nocount on;

	declare @Id TIdentifier, @result int;

	exec @result = [dbo].[SizeOfServiceRequestCreateInternal] @xml, @Id out;

	exec @result = [dbo].[SizeOfServiceRequestGet] @Id;

	return 0;
end
