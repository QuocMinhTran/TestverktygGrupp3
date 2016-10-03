CREATE TABLE [dbo].[Medvekan]
(
	[MedverkanId] INT NOT NULL IDENTITY (1,1),
	[Mål] INT NULL,
	[MedlemId] INT NOT NULL,
	[MatchId] INT NOT NULL,
	PRIMARY KEY CLUSTERED ([MedverkanID] ASC),
    CONSTRAINT [FK_dbo.Medverkan_dbo.Match_MatchID] FOREIGN KEY ([MatchId]) 
        REFERENCES [dbo].[Matcher] ([MatchId]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Medverkan_dbo.Medlemmar_MedlemID] FOREIGN KEY ([MedlemId]) 
        REFERENCES [dbo].[Medlemmar] ([MedlemId]) ON DELETE CASCADE
)
