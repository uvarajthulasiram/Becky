CREATE TABLE [dbo].[LookupRestaurantType]
(
	[Id] INT NOT NULL,
	[Type] VARCHAR(20) NOT NULL,
	[Description] VARCHAR(100),

	CONSTRAINT [PK_LookupRestaurantType] PRIMARY KEY CLUSTERED ([Id])
)
