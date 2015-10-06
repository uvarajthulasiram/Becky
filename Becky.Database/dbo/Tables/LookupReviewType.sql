CREATE TABLE [dbo].[LookupReviewType]
(
	[Id] INT NOT NULL,
	[Type] VARCHAR(20) NOT NULL,
	[Description] VARCHAR(100),

	CONSTRAINT [PK_LookupReviewType] PRIMARY KEY CLUSTERED ([Id])
)
