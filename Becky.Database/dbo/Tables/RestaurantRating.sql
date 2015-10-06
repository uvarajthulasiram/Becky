CREATE TABLE [dbo].[RestaurantRating]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[RestaurantBranchId] INT NOT NULL,
	[Rating] NUMERIC NOT NULL,
    [CreatedBy] NVARCHAR(128) NOT NULL,
	[CreatedOn] SMALLDATETIME NOT NULL,
    [ModifiedBy] NVARCHAR(128) NULL,
	[ModifiedOn] SMALLDATETIME NULL,

	CONSTRAINT [PK_RestaurantRating] PRIMARY KEY CLUSTERED ([Id]),

	CONSTRAINT [FK_RestaurantRatingAspNetUsersCreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES dbo.[AspNetUsers] ([Id]),
	CONSTRAINT [FK_RestaurantRatingAspNetUsersModifiedBy] FOREIGN KEY ([ModifiedBy]) REFERENCES dbo.[AspNetUsers] ([Id]),	
	CONSTRAINT [FK_RestaurantRatingRestaurantBranch] FOREIGN KEY ([RestaurantBranchId]) REFERENCES dbo.[RestaurantBranch] ([Id]),
		
	CONSTRAINT [CK_RestaurantRatingRating] CHECK ([Rating] BETWEEN 1 AND 5)
)
