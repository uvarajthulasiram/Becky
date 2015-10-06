CREATE TABLE [dbo].[Restaurant]
(
	[Id] INT NOT NULL IDENTITY (1,1),
	[Name] VARCHAR(100) NOT NULL,
	[LookupRestaurantTypeId] INT,
    [CreatedBy] NVARCHAR(128) NOT NULL,
	[CreatedOn] SMALLDATETIME NOT NULL,
    [ModifiedBy] NVARCHAR(128) NULL,
	[ModifiedOn] SMALLDATETIME NULL,
	
	CONSTRAINT [PK_Restaurant] PRIMARY KEY CLUSTERED([Id]),
	CONSTRAINT [FK_RestaurantLookupRestaurantType] FOREIGN KEY ([LookupRestaurantTypeId]) REFERENCES dbo.[LookupRestaurantType] ([Id]),
	
	CONSTRAINT [FK_RestaurantCreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES dbo.[AspNetUsers] ([Id]),
	CONSTRAINT [FK_RestaurantModifiedBy] FOREIGN KEY ([ModifiedBy]) REFERENCES dbo.[AspNetUsers] ([Id])
)
