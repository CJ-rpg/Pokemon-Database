CREATE TABLE [dbo].[PossibleAbilities] (
    [Id]            INT NOT NULL,
    [DexNum]        INT NOT NULL,
    [AbilityId]     INT NOT NULL,
    [Hidden]        BIT NOT NULL,
    [HiddenDisplay] AS  (case when [Hidden]=(1) then 'True' when [Hidden]=(0) then 'False'  end),
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([AbilityId]) REFERENCES [dbo].[Abilities] ([Id]),
    FOREIGN KEY ([DexNum]) REFERENCES [dbo].[Pokemon] ([DexNum]) 
);

