﻿CREATE TABLE [dbo].[Matcher]
(
	[MatchId] INT NOT NULL IDENTITY(1,1),
	[Mot] NVARCHAR (50) NULL,
	[Datum] DATE NULL,
	[Resultat] NVARCHAR (50) NULL,
	PRIMARY KEY CLUSTERED ([MatchId] ASC)
)
