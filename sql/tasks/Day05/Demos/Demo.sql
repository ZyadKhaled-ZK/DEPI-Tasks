-- DDL : Structure / Database
-- Create / alter / drop 
create database DepiG02
use DepiG02
Create table Employees(
fname varchar(50) not null,
lname varchar(50) not null,
Id int primary Key identity, --(1,1)
Bdate date,
Address varchar(50) default'cairo', -- reserved keyword
Gender char(1), -- M F
Dno int --references Departments(Dnumber) -- relationship
) 
create table Departments(
Dname varchar(50),
Dnumber int primary key identity(10,10),
MgrId int references Employees(Id),
MgrStaerdate Date default getdate() -- current date
)
Create table Dept_Locations(
Dnumber int references [dbo].[Departments]([Dnumber]),
Dlocation varchar(50),
primary key(Dnumber,Dlocation)
)
-- Script 
---------------------------------------
-- Alter (Add,update,drop)
alter Table Employees 
add Test int

alter table Employees
Alter Column Test bigint
-- int >> Char : Same category
-- int >> tiny int : from smaller to bigger

alter table Employees 
drop Column Test

alter table Employees
add foreign Key (Dno) references Departments(Dnumber)
-- built_in stored procedures

-- drop 
drop database DepiG02
drop table Employees
---------------------------------------------------------------
-- DMl : (insert  -  update  - delete)
-- 1- simple insert (only one row) --id disabled >> engine not me
-- must null be written
insert into Employees
values('Abdo','shaban','08-12-1990',default,null,null,6400)

insert into Employees (fname,lname,Salary)
values('taha','tarek',7600)
--- the rest of columns must one of three:
-- Must : 
--1- allow null
--2- default value >> cairo
--3- identity constraint >> engine

-- 2- row constructor (insert constructor)(more than one raw)
insert into employees 
values 
('Abdo','shaban','08-12-1990',default,null,null,6789),
('samir','hany','08-12-1999',default,null,null,6780),
('fayroz','sami','08-12-2002',default,null,null,2325)

alter table Employees
add Salary money
-- update
-- catch all employees
-- where >> condition on one record
update Employees 
set Salary=8500,Gender='M' -- MAny Column
where id=4
-- ,    and >> HHH   or>>right
update Employees 
set salary = 8500,Gender='M'
--where id=4 and id=5
--where id=4 or id = 5

update Employees 
set salary +=1000
------------------------------------------
-- Delete 
use DepiG02
Delete from Employees
where Salary>2000

-- Delete address data for all Employees

--delete from Employees
--where

update Employees
set address = null
--------------------------------------------------
--DQL : Retreival 
--Select : not change DB 
-- resultset >> Runtime
use iti
--1
Select *
from Student
--2
select St_Fname
from Student
--3
select St_Fname,St_Lname
from Student
--4
-- concat 
-- alias name __ Dala3
select St_Fname+' '+St_Lname as [Full Name]
from Student

--5
-- filter 
select *
from Student
where St_Age >=23
--6
select *
from Student
where St_Age >=23 and St_Age <= 30
--7
-- between operator : range of values
select *
from Student
where St_Age between 23 and 30

--8
select *
from Student
where St_Address='cAiro' or St_Address='Alex' or St_Address='tanta'
--9 
-- in operator : Set of values\
select *
from Student
where St_Address not in('cAiro','Alex','tanta')

--10
select *
from student
where st_super is not null
-- logical error : = null

--11 Regular expressions : 
-- reserved Characters :
--  _ : one character
--  % :0 or more characters
-- '_a%'


select St_Fname
from student
where St_Fname like '_a%'


/*
'a%h' => 
'%a_' =>
'[ahm]%' =>a or h or m
'[^ahm]%' => not .....
'[a-h]%' => a leeter of this range
'[^a-h]%' => not ...
'[346]%' =>
'%[%]' => ends with %
'%[_]%'  jgj_hjjhj
'[_]%[_]' __
*/ 
-- to express the value of % or _
select *
from student
where st_fname like '%[%]'

-- distinct : unique + ordering
select st_fname
from student
select distinct st_fname
from student


-- ordering
select st_fname
from student
order by st_fname -- Asc

select st_fname
from student
order by st_fname desc

select st_fname,St_Lname
from student
order by st_fname,St_Lname -- Asc

select st_fname,St_Lname,St_Age
from student
order by 1,2
select *
from student
order by 2,3

----------------------------------------------------------
-- Join : 
-- 1- Cartesian product (ANSI)
select St_Fname,Dept_Name
from Student,Department --19 * 7 = 133
-- Cross Join 
select St_Fname,Dept_Name
from Student cross join Department
--  fake data
--  business case we need cross join?

select Count(*)
from Student -- 19
select Count(*)
from Department -- 7

-- 2- Equi Join : ANSI
-- الطلبة اللي ف الاقسام او الاقسام الللي فيها طلبة
select S.St_Fname,D.Dept_Name
from Student S,Department D
-- where PK = FK
where S.Dept_Id=D.Dept_Id
-- Inner join MS
select S.St_Fname,D.Dept_Name
from Student S inner join Department D
on S.Dept_Id=D.Dept_Id
--14 

-- 3- outer join 
-- inner join + left Out
-- الطلبة ف الاقسام + الطلبة مش ف اقسام
select S.St_Fname,D.Dept_Name
from Student S left outer join Department D
on S.Dept_Id=D.Dept_Id
--19
-- 5

-- inner join + right Out
-- الاقسام ال فيها طلبة + الاقسام اللي مفيهاش طلبة 
select S.St_Fname,D.Dept_Name
from Student S right outer join Department D
on S.Dept_Id=D.Dept_Id
--17 
-- 3

select S.St_Fname,D.Dept_Name
from Student S full outer join Department D
on S.Dept_Id=D.Dept_Id
--22 
-- 14 + 5 + 3
-----------------------------------------------
-- Multi join
-- Equi join
select S.St_Fname,C.Crs_Name,Sc.Grade
from Student S,Stud_Course SC,Course C
where s.St_Id=sc.St_Id and C.Crs_Id=SC.Crs_Id

-- MS : inner join
select S.St_Fname,C.Crs_Name,Sc.Grade
from Student S inner join Stud_Course SC
on s.St_Id=sc.St_Id
inner join Course C 
on C.Crs_Id=SC.Crs_Id
-----------------------------------------------
-- Self join
-- article >> sense of humor
select BB.St_Fname as StudentName,CC.St_Fname as SupervisorName
from student CC , Student BB
where CC.St_Id = BB.St_super
order by SupervisorName
-------------------------------------------
-- Join + DML ?
-- update grades of cairo students
update SC
set grade += 10
from Stud_Course SC,Student S
where S.St_Id=SC.St_Id and St_Address='cairo'
-- Delete grades of cairo students
delete SC
from Stud_Course SC,student S
where S.st_id=SC.st_id and s.st_address = 'cairo'
-- insert + Join -- Self
-- Self >> M : M -- self
-- Normalization ? 
-------------------------------------------
-- return one value (scalar functions)
-- this value not exists in DB
-- five : count,sum,Avg,Max,Min
select count(St_Id) as [Students Count]  -- real count of students
from Student -- * or PK --19
select count(St_Age)   -- real count of students
from Student  -- 14

-- Numeric
select Sum(Salary) as SalarySum
from Instructor
select Avg(Salary) as SalarySum -- Sum/Count
from Instructor
select Sum(Salary)/Count(*)
from Instructor
select Sum(Salary)/Count(Salary)
from Instructor

select Max(Salary) MaxSalary,Min(Salary) MinSalary
from Instructor
select Max(Ins_Name) MaxSalary,Min(Ins_Name) MinSalary
from Instructor
--> Self : Encoding Characters 
--------------------------------------
-- Min Ins Salary for each dep 
select Ins_Id,Min(Salary)
from Instructor
group by Ins_Id
select Dept_Id,Min(Salary)
from Instructor
group by Dept_Id
-- Group by column 
-- Group by *  invalid
-- Group by PK >> MeANINGLESS
-- Group by Repeated Column
-- u must groupby columns beside aggregate
-- Syntax / Logic

select Dept_id,St_Address,Count(*) NoOfStudents
from Student
group by Dept_id -- Group by How ?
-- why we have to group by these columns beside aggregate
-------------------------------------------------------
-- Get numbers of students for each dep
select Dept_Id,Count(*)
from Student
group by Dept_Id

select S.Dept_Id,Count(*)
from Student S, Department D
where S.Dept_Id=D.Dept_Id
group by S.Dept_Id

select Dept_Id,Count(*)
from Student
where Dept_Id is not null
group by Dept_Id

-- Condition on groups ?
select Dept_Id,Count(*)
from Student
group by Dept_Id
having Dept_Id is not null

----------------------------
-- Get numbers of students for each dep that has more than 3 students
select S.Dept_Id,Count(*)
from Student S, Department D
where S.Dept_Id=D.Dept_Id 
group by S.Dept_Id
having Count(*) > 3

select Dept_Id,Count(*)
from Student
where Dept_Id is not null
group by Dept_Id
having Count(*) > 3

select Dept_Id,Count(*)
from Student
group by Dept_Id
having Dept_Id is not null and Count(*) > 3
----------------------------
-- having ?
-- 1- Conditioning on groups >> group by
-- 2- selct just only agg functions >> without group by
select Sum(Salary)
from Instructor
having Count(Ins_Id)<100
----------------------------
-- Execution order 
select *
from Student
where St_Id=1

select St_Fname+' '+St_Lname as fullname
from Student
where St_Fname+' '+St_Lname='Ahmed Hassan'

select St_Fname+' '+St_Lname as fullname
from Student
order by fullname

/*
from 
join
on
where
group by
Having
select
Order by
Top
*/
----------------------------
-- Query inside Query
-- SubQuery 
-- Performance (Slow)
-- display for students whose Age > avg
select *
from Student
where St_Age>(Select Avg(St_Age) from Student)

-- inner query 
-- outer query
-- inner query >> outer query
-- input of Outer query is output inner query
--where St_Age>Avg(St_Age)
--having St_Age>Avg(St_Age)

-- 6 / 20 > 7 / 20
select st_id,Count(*)
from Student

select st_id,(select Count(*) from Student)
from Student

-- SubQuery   VS   Join
-- Get DepNames that have students
select distinct D.Dept_Name
from Student S,Department D
where S.Dept_Id=D.Dept_Id

select Dept_Name
from Department
where Dept_Id in (
select distinct Dept_Id
from Student
where Dept_Id is not null
)

-- delete cairo students grades
delete SC
from Stud_Course SC,student S
where S.st_id=SC.st_id and s.st_address = 'cairo'

-- Self study make same using subquery
------------------------------------------------
--union family (union)
-- query resultSet union/union all/intersect/except query resultSet  =   one resultSet
select St_Fname from Student --19
Except
select Ins_Name from Instructor --15
-- conditions 
-- 1- of same datatype
-- 2- same no of columns
------------------------------------------------------
-- get max 3 salaries from instructors 
-- get max 3 salaries >> Instructors data of max 3 salaries ?
-- max Salary
select max(Salary)
from Instructor
union all
-- max second salary
select max(Salary)
from Instructor
where Salary != (
select max(Salary)
from Instructor
)
union all
-- max third salary
select max(Salary)
from Instructor
where Salary not in
(
(select max(Salary)
from Instructor),
(select max(Salary)
from Instructor
where Salary != (
select max(Salary)
from Instructor
))
)

-- Top , Ranking
-- First 5 students 
select top(5) *
from Student
select top(5) St_Fname,St_Lname
from Student
-- last 5 students
select top(5) *
from Student
order by St_Id desc

-- get max 3 salaries >> Instructors data of max 3 salaries ?
select top(3) *
from Instructor
order by Salary desc

-- third salary 
-- virtual table
select top(1)*
from
(select top(3) Salary
from Instructor
order by Salary desc) as NewTable  -- virtual table -- Runtime table
order by Salary

-- Logic Concept
select St_Age
from Student
where St_Age is not null
order by St_Age desc

select top(7) St_Age
from Student
order by St_Age desc
select  top(7) with ties St_Age
from Student
order by St_Age desc

-- composite >> Make our own pk
-- id : int 
-- Guid : gloabal unique identifier
-- 32 digits : unique for the whole server
select newid()

-- Randomly select 
-- top + newid

select top(3) *
from students
order by newid()


use DepiG01
alter table employees
add test uniqueidentifier
---------------------------------------------
-- Ranking Functions 
-- 4 functions : 3 + 1
-- 1- Row_Number()
-- 2- Dense-Rank()
-- 3- Rank()

--Rank : 
use ITI
select Ins_Name,Salary,
Row_Number() over (order by salary desc) as RN,
Dense_Rank() over (order by salary desc) as DR,
Rank() over (order by salary desc) as R
from Instructor

-- Get 2 older students 
-- Top Vs Rank
-- Ranking
select St_Fname,St_Age,Dept_Id
from (select St_Fname,St_Age,Dept_Id,
ROW_NUMBER() over (order by st_age desc) as RN
from Student) as NewTable
where RN <=2

-- Top better
select top(2) St_Fname,St_Age,Dept_Id
from Student
order by St_Age desc

-- Get the third as age 
-- Ranking better
select St_Fname,St_Lname
from (select St_Fname,St_Age,St_Lname,
ROW_NUMBER() over (order by st_age desc) as RN
from Student) as NewTable
where RN =3

-- Top
select top(1)  St_Fname,St_Lname
from (select top(3) St_Fname,St_Age,St_Lname
from Student
order by St_Age desc) as NewTable
order by St_Age

-- older student for each department
-- Ranking 
-- Partitions + ordered 
--- Top 
Select  Dept_Id,St_Fname,St_Age
from (select Dept_Id,St_Fname,St_Age,
dense_Rank() over (paRTITION BY Dept_Id order by st_age desc) as RN
from Student
where Dept_Id is not null) as NewTable
where RN = 1

-- 4- NTile()
-- take parameter 
-- Groups ?
--  self
--15/3 >> 5
-- least salary 5 >> first five >> top
-- middle five ?
-- 1000 emp the 7th ? >> subqueries with top
select * 
from
(select Ins_name,Salary,
Ntile(3) over (order by salary) as GN
from Instructor) as newtable
where GN =2

--17/3 >> 6  6   5
-- 15 >>> 16/2 >> 8
-- 8  7
select Ins_name,Salary,
Ntile(2) over (order by salary)
from Instructor

-- We Have 15 Instructors, and We Need to Get The 6th Instructors Who Take the lowest salary
-- self
--------------------------------------------------------------------------
------------------------------ schema -----------------------------------

-- schema : Project --> sub Projects
---> Modules (Registration - payment)
---> container / box (schemas)
---> logical module

-- DB heirarrchy : DB object ID
---> server name > database > schema > Db objects
--(tables-functions-views-SP-triggers)
-- table >> rows  column  Rships

-- schema use !
---> dbo : default schema : database owner
-- any object by default > dbo
-- create table d7k(id int primary key) -> dbo.d7k

select @@SERVERNAME

select *
from Student
select *
from [LAPTOP-K14644JD].iti.dbo.Student

/*
-- server : windows auth (connected)
-- database : using  
-- dbo : default 
*/

select * 
from MyCompany.dbo.Employee

/*
why schema ? 
1- create objects with the same name ?!
Hr.employees    pr.employees
2- logical meaning (container) >> related to each other
>> detection contents (Registration)
3- permission >> security (VIP)
Box (access)  >> schema
*/
--> schema : structure (DB object)
Create schema Hr

alter schema Hr
transfer student

select *
from Hr.student

alter schema dbo
transfer Hr.student

create table d7k(id int primary key)
create table Hr.d7k(id int primary key)

------------------------------------------------------------------
-- DDL [Create, Alter, Drop, Select Into]    
-- Select Into : Create Physical Table, copy and make a new table
-- Select : Create Runtime Table >> virtual table(Rank,top)
-- same structure + data + no constraints + no rships

create database test

select * into NewEmployees
from MyCompany.dbo.Employee


-- Create Just The Structure Without Data
Select * into NewProjects
From MyCompany.Dbo.Project
Where 1 = 2 -- any condition not achieved


-- Take Just The Data Without Table Structure, 
-- but 2 tables must have same structure (Insert Based On Select)
insert into NewProjects
--values()
select * from MyCompany.Dbo.Project

--- Delete   Vs truncate 
-- who is faster ?
-- logging : insert , update ,delete

delete from Student
-- Condition
--where St_Address= 'Alex'
-- logging first 
-- Soft delete

truncate table Student
--where St_Address= 'Alex'
--hard delete
-- faster
------------------------------------------------------------------
------------------------------ constraints -----------------------------------
-- table >> rows(Records) , Column (Domain) , Rships(FK)
-- collection of data >> Constraints + Rules >> RDB
--create database Test
use Test

create table Departments
(
Dname varchar(max),
Dnumber int Primary Key identity(10,10),
Mgrstartdate date default getdate() -- current system date
)
drop table employees
drop database test
create table employees
(
-- 1- Column
-- Data Qulaity >> Data type > type + Range
-- not null   null   
-- default 
-- Check ?
-- 2- Rows (Records) >> duplication
-- PK 
-- unique ?? not PK >> allow null >> one null
-- 3- Rship >> integrity + consistent
-- FK
-- > Reset identity : self
fname varchar(50) not null, -- req 
lname varchar(50) not null, --req
Id int primary key Identity, -- (1,1)--default
-- Engine >> Identity
Age int unique check(Age>18),
address varchar(50) default 'cairo',-- reserverd keyword
-- default : cairo
gender char(1) Check(gender in ('M','F')),-- M   F >> one letter
-- H   I
salary Money,
DNo int references Departments(Dnumber)
on delete set null on update cascade,
)

CREATE TABLE employees
(
    -- 1- Column Definitions
    fname    VARCHAR(50) NOT NULL,                            -- Required
    lname    VARCHAR(50) NOT NULL,                            -- Required
    Id       INT CONSTRAINT C1 PRIMARY KEY IDENTITY(1,1),     -- Engine-generated
    Age      INT CONSTRAINT C2 UNIQUE 
                   CONSTRAINT C3 CHECK (Age > 18),            -- Unique and > 18
    address  VARCHAR(50) CONSTRAINT C4 DEFAULT 'cairo',       -- Default value
    gender   CHAR(1) CONSTRAINT C5 CHECK (gender IN ('M','F')), -- One letter: M or F
    salary   MONEY,
    DNo      INT CONSTRAINT C6 REFERENCES Departments(Dnumber) -- FK
			 on delete set null on update cascade
);

CREATE TABLE employees
(
    -- 1- Column Definitions
    fname    VARCHAR(50) NOT NULL,                            
    lname    VARCHAR(50) NOT NULL,                            
    Id       INT IDENTITY(1,1),                               
    Age      INT,                                             
    address  VARCHAR(50) CONSTRAINT C4 DEFAULT 'cairo',                     
    gender   CHAR(1),                                         
    salary   MONEY,
    DNo      INT,

    -- 2- Constraints
    CONSTRAINT C1 PRIMARY KEY (Id),
    CONSTRAINT C2 UNIQUE (Age),
    CONSTRAINT C3 CHECK (Age > 18),
    --CONSTRAINT C4 DEFAULT 'cairo' FOR [address],
    CONSTRAINT C5 CHECK (gender IN ('M', 'F')),
    CONSTRAINT C6 FOREIGN KEY (DNo) REFERENCES Departments(Dnumber)
	--on delete set null on update cascade
);

alter table Employees
drop constraint C6

alter table employees
add constraint C6
FOREIGN KEY (DNo)
REFERENCES Departments(Dnumber)
on delete set null 
on update cascade


-----------------------------------------------------------------------
--------------- Relationships Rules -----------------------
use ITI
Delete from Department where Dept_Id=40
-- students , instructors
-- transfere students to another department
update Student
set Dept_Id = 10
where Dept_Id=40
-- transfere students to null
update Instructor
set Dept_Id = null
where Dept_Id=40
-- delete students in dep 40
delete from Student
where Dept_Id=40

--> wizard  
-- control behavior of fk
--Custom rship Rule
-- No action : get error
-- cascade : delete all childs
-- set null : set null value
-- set default : set default or null
-- code
-----------------------------------------------------------------------