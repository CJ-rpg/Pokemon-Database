CREATE TABLE [dbo].[Pokemon] (
    [DexNum]     INT           NOT NULL,
    [Name]       NVARCHAR (64) NOT NULL,
    [CategoryId] INT           NOT NULL,
    [Height(m)]  FLOAT		   NOT NULL,
	[Weight(kg)] FLOAT		   NOT NULL,
    PRIMARY KEY CLUSTERED ([DexNum] ASC),
    FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id])
);

