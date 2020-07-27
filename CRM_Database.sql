create database if not exists crmDB;
GO
use crmDB;
GO
create table if not exists Parent
(
	id int not null unique identity, primary key(id),
	Name varchar(80) not null,
	Phone varchar(15) not null,
	Email varchar(30) not null,
	Note varchar(255)
)
GO
/*
create table if not exists parent
(
	id varchar(36), primary key(id),
	Name varchar(80) not null,
	Phone varchar(15) not null,
	Email varchar(30) not null,
	Note varchar(255)
)*/

create table if not exists Child
(
	id int not null unique identity, primary key(id),
	/*id varchar(36), primary key(id),*/
	Name varchar(80) not null,
	BirthDate date,
	Note varchar(255)
)
GO
create table if not exists Child_Parents
(
	id int not null unique identity, primary key(id),
	ChildId int not null, foreign key(ChildId) references Child(id),
	ParentId int not null, foreign key(ParentId) references Parent(id)
)
GO
/*
create table Child_Parents
(
	id varchar(36), primary key(id),
	ChildId varchar(36), foreign key(ChildId) references Child(id),
	ParentId varchar(36), foreign key(ParentId) references Parent(id)
)*/
create table if not exists Course
(
	id int not null unique identity, primary key(id),
	/*id varchar(36), primary key(id),*/
	Name varchar(80),
	AgeGroup varchar(80),
	DateStarted date,
	DateFinished date,
	AvailablePlaces int,
	Type varchar(50)
)
GO
create table if not exists Registration
(
	id int not null unique identity, primary key(id),
	/*id varchar(36), primary key(id),*/
	ChildId int not null, foreign key(ChildId) references Child(id),
	/*ChildId varchar(36), foreign key(ChildId) references Child(id),*/
	CourseId int not null, foreign key(CourseId) references Course(id),
	Amount float,
	Discount varchar(10),
	RegistrationDate date,
	Note varchar(255)
)
GO
create table if not exists Teacher
(
	id int not null unique identity, primary key(id),
	/*id varchar(36), primary key(id),*/
	Name varchar(80),
	Phone varchar(15),
	Email varchar(30),
	Fee int,
	Note varchar(255)
)
GO
create table if not exists Course_Teacher
(
	id int not null unique identity, primary key(id),
	CourseId int not null, foreign key(CourseId) references Course(id),
	TeacherId int not null, foreign key(TeacherId) references Teacher(id)
)