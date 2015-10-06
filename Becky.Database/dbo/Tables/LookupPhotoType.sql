CREATE TABLE [dbo].[LookupPhotoType]
(
	[Id] INT NOT NULL,
	[Type] VARCHAR(20) NOT NULL,
	[Description] VARCHAR(100),

	CONSTRAINT [PK_LookupPhotoType] PRIMARY KEY CLUSTERED ([Id])
)
