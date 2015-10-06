CREATE TABLE [dbo].[RestaurantPhoto]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[RestaurantBranchId] INT NOT NULL,
	[PhotoTypeId] INT NOT NULL,
	[PhotoSource] VARCHAR(100) NOT NULL,
    [CreatedBy] NVARCHAR(128) NOT NULL,
	[CreatedOn] SMALLDATETIME NOT NULL,
    [ModifiedBy] NVARCHAR(128) NULL,
	[ModifiedOn] SMALLDATETIME NULL,

	CONSTRAINT [PK_RestaurantPhoto] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_RestaurantPhotoRestaurantBranch] FOREIGN KEY ([RestaurantBranchId]) REFERENCES dbo.[RestaurantBranch] ([Id]),
	CONSTRAINT [FK_RestaurantPhotoLookupPhotoType] FOREIGN KEY ([PhotoTypeId]) REFERENCES dbo.[LookupPhotoType] ([Id]),
	
	CONSTRAINT [FK_RestaurantPhotoCreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES dbo.[AspNetUsers] ([Id]),
	CONSTRAINT [FK_RestaurantPhotoModifiedBy] FOREIGN KEY ([ModifiedBy]) REFERENCES dbo.[AspNetUsers] ([Id])
)
