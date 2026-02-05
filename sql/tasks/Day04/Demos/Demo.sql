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