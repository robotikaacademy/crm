IF DB_ID('crmDB') IS NULL
	create database crmDB;
GO
use crmDB;
IF object_id('Parents') IS NULL
	create table Parents
	(
		ID uniqueidentifier not null, primary key(ID),
		Name varchar(80) not null,
		Phone varchar(15) not null,
		Email varchar(30) not null,
		Note varchar(255)
	)
IF object_id('Children') IS NULL
	create table Children
	(
		ID uniqueidentifier not null, primary key(ID),
		Name varchar(80) not null,
		BirthDate date,
		Note varchar(255)
	)
IF object_id('Child_Parents') IS NULL
	create table Child_Parents
	(
		ID uniqueidentifier not null, primary key(ID),
		ChildId uniqueidentifier not null, foreign key(ChildId) references Children(ID),
		ParentId uniqueidentifier not null, foreign key(ParentId) references Parents(ID)
	)
IF object_id('Courses') IS NULL
	create table Courses
	(
		ID uniqueidentifier not null, primary key(ID),
		Name varchar(80),
		AgeGroup varchar(80),
		DateStarted date,
		DateFinished date,
		AvailablePlaces int,
		Type varchar(50)
	)
IF object_id('Registrations') IS NULL
	create table Registrations
	(
		ID uniqueidentifier not null, primary key(ID),
		ChildID uniqueidentifier not null, foreign key(ChildID) references Children(ID),
		CourseID uniqueidentifier not null, foreign key(CourseID) references Courses(ID),
		Amount float,
		Discount varchar(10),
		RegistrationDate date,
		Note varchar(255)
	)
IF object_id('Teachers') IS NULL
	create table Teachers
	(
		ID uniqueidentifier not null, primary key(ID),
		Name varchar(80),
		Phone varchar(15),
		Email varchar(30),
		Fee int,
		Note varchar(255)
	)
IF object_id('Course_Teachers') IS NULL
	create table Course_Teachers
	(
		ID uniqueidentifier not null, primary key(ID),
		CourseId uniqueidentifier not null, foreign key(CourseId) references Courses(ID),
		TeacherId uniqueidentifier not null, foreign key(TeacherId) references Teachers(ID)
	)