CREATE TABLE [dbo].[RestaurantBranch] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [RestaurantId] INT           NOT NULL,
    [AddressLine1] VARCHAR (100) NOT NULL,
    [AddressLine2] VARCHAR (100) NULL,
    [PostalCode]   VARCHAR (10)  NULL,
    [City]         VARCHAR (50)  NOT NULL,
    [Province]     VARCHAR (5)   NOT NULL,
    [Country]      VARCHAR (50)  NOT NULL,
    [Website]      VARCHAR (100) NULL,
    [Phone]        VARCHAR (15)  NULL,
    [IsActive]     BIT           NOT NULL,
    [CreatedBy] NVARCHAR(128) NOT NULL,
	[CreatedOn] SMALLDATETIME NOT NULL,
    [ModifiedBy] NVARCHAR(128) NULL,
	[ModifiedOn] SMALLDATETIME NULL,

    CONSTRAINT [PK_RestaurantBranch] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_RestaurantBranchRestaurant] FOREIGN KEY ([RestaurantId]) REFERENCES dbo.[Restaurant] ([Id]),

	CONSTRAINT [FK_RestaurantBranchCreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES dbo.[AspNetUsers] ([Id]),
	CONSTRAINT [FK_RestaurantBranchModifiedBy] FOREIGN KEY ([ModifiedBy]) REFERENCES dbo.[AspNetUsers] ([Id])
);