CREATE TABLE [dbo].[PokemonTypes] (
    [Id]     INT NOT NULL,
    [DexNum] INT NULL,
    [TypeId] INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([DexNum]) REFERENCES [dbo].[Pokemon] ([DexNum]),
    FOREIGN KEY ([TypeId]) REFERENCES [dbo].[Types] ([Id])
);

