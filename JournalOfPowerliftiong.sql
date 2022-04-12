CREATE TABLE Account 
(
	Id int identity(1,1) primary key not null,
	Login nvarchar(255) not null unique,
	Password nvarchar(255) not null,
	Name nvarchar(50) not null,
	Surname nvarchar(50) not null,
	Status nvarchar(50) not null
);

CREATE TABLE TrainingDay 
(
	Id int identity(1,1) primary key not null,
	Name nvarchar(50) not null unique

);

CREATE TABLE Exercise
(
	Id int identity(1,1) primary key not null,
	Name nvarchar(255) not null unique
);

CREATE TABLE PlanSet
(
	Id int identity(1,1) primary key not null,
	NumberOfSeries int not null,
	NumberOfRepetitions int,
	Weight int
);


CREATE TABLE TrainingPlan
(
	Id int identity(1,1) primary key not null,
	IdCompetitor int not null foreign key references Account(Id),
	IdCoach int not null foreign key references Account(Id),
	IdTrainingDay int not null foreign key references TrainingDay(Id),
	IdExercise int not null foreign key references Exercise(Id),
	IdPlanSet int not null foreign key references PlanSet(Id),
	Comment nvarchar(1000)
);

CREATE TABLE Training
(
	Id int identity(1,1) primary key not null,
	TrainingData datetime2 not null,
	IdTrainingPlan int not null foreign key references TrainingPlan(Id)
);

CREATE TABLE RealTraining
(
	Id int identity(1,1) primary key not null,
	IdPlanSet int not null foreign key references PlanSet(Id),
	IdTraining int not null foreign key references Training(Id),
	RealSetNumber int not null,
	RealRepetitions int not null,
	RealWeight int
);	

