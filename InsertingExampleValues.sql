INSERT INTO Account VALUES
('tomek2212','tomek2212','Tomasz','Logisz','ZAWODNIK'),
('trener1','trener1','Trener','NTrener','TRENER')


INSERT INTO TrainingDay VALUES
('Poniedzia³ek'),
('Wtorek'),
('Œroda'),
('Czwartek'),
('Pi¹tek')

INSERT INTO Exercise VALUES
('Squat'),
('Bench Press'),
('Poliquin step up'),
('Staggered stance deadlift'),
('Chest supported DB rows'),
('DB rainbows'),
('Contralateral plank'),
('Snatch grip barbell overhead hold'),
('Deadlift'),
('Leg curls slide'),
('Inverted rows'),
('Farmers walk')

 INSERT INTO PlanSet VALUES
 (4,null,null),
 (5,10,100),
 (3,12,20)



 SELECT * FROM dbo.Account;
 SELECT * FROM Exercise ORDER BY Id;
 SELECT * FROM TrainingDay ORDER BY Id
 SELECT * FROM PlanSet ORDER BY Id;
 


 INSERT INTO TrainingPlan
 VALUES
 --(id,idCompetitior,IdCoach,IdTrainingDay,IdExercise,IdPlanSet,Comment)
 (1,2,1,1,1,null),
 (1,2,1,2,1,null),
 (1,2,1,3,1,null),
 (1,2,1,4,2,null),
 (1,2,1,5,3,'Komentarz1'),
 (1,2,1,6,1,'Komentarz2'),
 (1,2,1,7,2,null),
 (1,2,2,8,1,null),
 (1,2,2,9,1,null),
 (1,2,2,2,2,null),
 (1,2,2,10,2,null),
 (1,2,2,11,3,'Komentarz3'),
 (1,2,2,12,3,'Komenatrz4')
 

 --Odczyt planu

 SELECT
 acc.Surname as 'Zawodnik',
 acc_2.Surname as 'Trener',
 td.Name as 'Dzieñ',
 ex.Name as 'Æwiczenie',
 ps.NumberOfSeries as 'Ilosc serii',
 ps.NumberOfRepetitions as 'Ilosc powtorzen',
 ps.Weight as 'Obciazenie'
 --tp.Comment 
 FROM dbo.TrainingPlan tp
 JOIN dbo.Account acc ON tp.IdCompetitor = acc.Id
 JOIN dbo.Account acc_2 ON tp.IdCoach = acc_2.Id
 JOIN dbo.TrainingDay td ON tp.IdTrainingDay = td.Id
 JOIN dbo.Exercise ex ON tp.IdExercise = ex.Id
 JOIN dbo.PlanSet ps ON tp.IdPlanSet = ps.Id

SELECT * FROM dbo.TrainingPlan


-- isActive do planu
-- ukrywanie danych do statystyk


INSERT INTO Training 
VALUES
('2022-03-21',1),
('2022-03-19',8)


INSERT INTO RealTraining
VALUES
(1,1,1,9,109),
(1,1,2,11,111),
(1,1,3,10,100),
(1,1,4,10,100)


--sroda bench 1 seria 2 powt 120kg

--INSERT INTO Training
--VALUES
--(3,'2022-03-15',


--INSERT INTO RealTraining
--VALUES
--(



--)

SELECT tr.TrainingData,
tp.Comment as 'Komenatrz',
acc.Name as 'Imie',
acc.Surname as 'Nazwisko',
ex.Name as 'Cwiczenie',
ps.NumberOfSeries as 'Zalozone serie',
ps.NumberOfRepetitions as 'Zalozone powtorzenia',
ps.Weight as 'Zalozony ciezar',
rt.RealRepetitions as 'Realne powtorzenia',
rt.RealSetNumber as 'Realne powtorzenia',
rt.RealWeight as 'Realna waga'
FROM RealTraining rt
JOIN Training tr ON rt.IdTreining = tr.Id
JOIN PlanSet ps ON rt.IdPlanSet = ps.Id
JOIN TrainingPlan tp ON tr.IdTrainingPlan = tp.Id
JOIN Account acc ON tp.IdCompetitor = acc.Id
JOIN Exercise ex ON tp.IdExercise = ex.Id