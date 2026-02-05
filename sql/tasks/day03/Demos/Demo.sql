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

