﻿CREATE TABLE [dbo].[VATRate]
(
	[Id] TIdentifier not null primary key identity, 
	[State] TState not null,
	[FileAs] TName not null,
	[Value] TPercent not null,
    [Comments] NVARCHAR(MAX) NULL, 
    [Created] DATETIME NOT NULL, 
    [CreatedBy] INT NOT NULL, 
    [Modified] DATETIME NOT NULL, 
    [ModifiedBy] INT NOT NULL, 
    [RowVersion] rowversion NOT NULL
)
