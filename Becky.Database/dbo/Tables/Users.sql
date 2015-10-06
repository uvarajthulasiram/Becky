﻿CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL IDENTITY(1, 1),
	[FirstName] VARCHAR(100) NOT NULL,
	[LastName] VARCHAR(100) NOT NULL

	CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id])
)