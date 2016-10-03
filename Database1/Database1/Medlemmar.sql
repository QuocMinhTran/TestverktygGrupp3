CREATE TABLE [dbo].[Medlemmar]
(
	[MedlemId] INT NOT NULL IDENTITY (1,1),
	[MedlemNamn] NVARCHAR (50) NULL,
	[Roll] INT NULL ,	
	PRIMARY KEY CLUSTERED ([MedlemId] ASC)
)
