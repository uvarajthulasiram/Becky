CREATE TABLE [dbo].[RestaurantReview]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[RestaurantBranchId] INT NOT NULL,
	[AspNetUserId] NVARCHAR(128) NOT NULL,
	[ReviewTitle] NVARCHAR(128) NOT NULL,
	[ReviewText] NVARCHAR(500) NOT NULL,
	[IsSpam] BIT NOT NULL DEFAULT(0),
    [CreatedBy] NVARCHAR(128) NOT NULL,
	[CreatedOn] SMALLDATETIME NOT NULL,
    [ModifiedBy] NVARCHAR(128) NULL,
	[ModifiedOn] SMALLDATETIME NULL,

	CONSTRAINT [PK_RestaurantReview] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_RestaurantReviewRestaurantBranch] FOREIGN KEY ([RestaurantBranchId]) REFERENCES dbo.[RestaurantBranch] ([Id]),
	CONSTRAINT [FK_RestaurantReviewAspNetUsers] FOREIGN KEY ([AspNetUserId]) REFERENCES dbo.[AspNetUsers] ([Id]),
	
	CONSTRAINT [FK_ReviewAspNetUsersCreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES dbo.[AspNetUsers] ([Id]),
	CONSTRAINT [FK_ReviewAspNetUsersModifiedBy] FOREIGN KEY ([ModifiedBy]) REFERENCES dbo.[AspNetUsers] ([Id])
)
