/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
MERGE INTO Matcher AS Target 
USING (VALUES 
        (1, 'Economics', '2012-05-05','3-3'), 
        (2, 'Literature', '2012-05-07','3-4'), 
        (3, 'Chemistry', '2012-07-05','5-3')
) 
AS Source (MatchId, Mot, Datum, Resultat) 
ON Target.MatchID = Source.MatchId 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (Mot, Datum, Resultat) 
VALUES (Mot, Datum, Resultat);


MERGE INTO Medlemmar AS Target
USING (VALUES 
        (1, 'Tibbetts Donnie', 1), 
        (2, 'Guzman Liza', 2), 
	(3, 'Catlett Phil', 3)
)
AS Source (MedlemId, MedlemNamn, Roll)
ON Target.MedlemId = Source.MedlemId
WHEN NOT MATCHED BY TARGET THEN
INSERT (MedlemNamn, Roll)
VALUES (MedlemNamn, Roll);


MERGE INTO Medvekan AS Target
USING (VALUES 
	(1, 2, 1, 1),
	(2, 0, 1, 2),
	(3, 0, 2, 3),
	(4, 1, 2, 1),
	(5, 3, 3, 1),
	(6, 0, 3, 2)
)
AS Source (MedverkanId, Mål, MedlemID, MatchId)
ON Target.MedverkanId = Source.MedverkanId
WHEN NOT MATCHED BY TARGET THEN
INSERT (Mål, MedlemId, MatchId)
VALUES (Mål, MedlemId, MatchId);