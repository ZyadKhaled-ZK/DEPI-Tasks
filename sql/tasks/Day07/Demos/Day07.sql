-- Reusable code 
-- simplify structure
-- dynamic query
select *
from
[dbo].[GetDeptInsByDepId](20)
-- dnamic
-- filter result
select *
from GetDeptInsByDepId(10)
where [annual Salry]>100000

create or alter function getstuNumberDep(@depId int)
returns int
begin
	declare @Num int
	select @Num=Count(*)
	from Student
	where Dept_Id=@depId
	return @Num
end

CREATE PROCEDURE GetStudentCountByDepartment
    @depId INT,
    @Count INT OUTPUT
AS
BEGIN
    SELECT @Count = COUNT(*)
    FROM Student
    WHERE Dept_Id = @depId;
END
DECLARE @Result INT;
EXEC GetStudentCountByDepartment 20, @Result OUTPUT;
select @Result;

/*You cannot directly use a stored procedure in a WHERE clause or a SELECT statement like a scalar fun
Why?
Scalar functions return a value that can be used inline in SQL.
Stored procedures do not return values directly — they return result sets or output parameters.*/

-- dep stu > 2
select Dept_Id,Dept_Name
from Department
where dbo.getstuNumberDep(Dept_Id)>3
--alternative
CREATE OR ALTER PROCEDURE GetDepartmentsWithManyStudents @number int
AS
BEGIN
    SELECT Dept_Id, Dept_Name
    FROM Department
    WHERE dbo.getstuNumberDep(Dept_Id) > @number;
END
GetDepartmentsWithManyStudents 2

-- compare btw two dep
select 'Department A' as deptName,dbo.getstuNumberDep(30) as StuCount
union all
select 'Department B' as deptName,dbo.getstuNumberDep(20) as StuCount
---------------------------------------------------------------------
-- stored proc > ???? ???? Db object
-- No01
use ITI
	select *
	from Student
	where St_Id=1

create proc SP_GetStuById @stId int
 as
	select *
	from Student
	where St_Id=@stId

SP_GetStuById 2
exec SP_GetStuById 1
--> calling Proc only
declare @X int =2
exec SP_GetStuById @x
--> SP +code
--> EXec  have to
--> Procedure cache >> cold cache > Self

--No 02
create schema Hr
alter schema Hr
transfer SP_GetStuById
alter schema dbo 
transfer Hr.SP_GetStuById

-- No 03
-- Body >> Select + DML  : : CRUD operations
--- DML >> Error potential  >> not fail app >> damage
--- Handle errors
delete 
from Topic
where Top_Id=1

create or alter PROC sp_deLETEtoPIC @id int
with encryption
as 
begin try
		delete 
		from Topic
		where Top_Id=@id
end try
begin caTCH
		select 'Error'
END catch
	
sp_deLETEtoPIC 1


-- SP >> Built_in SP
Sp_helptext 'sp_deLETEtoPIC'


create proc SP_GetStuDataByAddress @address varchar(50)
with encryption
as
	select St_Id,St_Fname,St_Address
	from Student
	where St_Address=@address
-- resultset >> table >> insert based on select
-- insert based on select/execute
create table test(id int,name varchar(50),address varchar(50))
-- var of table 

insert into test 
execute SP_GetStuDataByAddress 'cairo'
select * from test

--------------------------------------------------------------
-- Fun must return 
-- SP >> May return 
-- SP >> return int only >> return statement >> int
-->> SP >> functionality >> SP behavior >> int
--> self

-- return of SP --may return --return numeric only 
/* The RETURN statement in a stored procedure can only return an integer value.
-- If you need to return non-integer types (like VARCHAR or DECIMAL),
you must use an OUTPUT parameter or convert to a scalar-valued function.*/
--> number indicate SP behavior --- self study
create proc test02 @id int
as
	begin
	declare @age int
	select @age=St_Age
	from Student
	where St_Id=@id
	return @age
	end

declare @x int 
exec @x=test02 1
select @x

--------------------------------------------------------------

-- sum str and num
create or alter proc Sp_sumData @x int=3,@y varchar(20)='7'
as
	select @x+@y  -- plus operator convert to numeric if available

SP_SumData 3,'7'		-- Passing Parameters by Position/order
SP_SumData 3,'ali' -- error
SP_SumData @y='7',@x=3    -- Passing Parameters by name
SP_SumData 3			-- Default Values
SP_SumData			-- Default Values
-- any language --> in C# will learn it again
--------------------------------------------------------
-- Fun >> return one value or table (range of values)
-- >> return more than one value
-- SP >> Parameteres >> return more than one value 
-- >> parameters (input parameter, output parameter,input output param)
---> in >> input paramater , empty dish >> output parameter >> full >> select/print

-- no 01
create proc SP_GetstuName @id int
with encryption
as 
	select St_Fname
	from Student
	where St_Id=@id
execute SP_GetstuName 3

create function GetstuName (@id int)
returns varchar(50)
begin
	declare @Name varchar(50)
	select @Name=St_Fname
	from Student
	where St_Id=@id
	return @Name
end
select dbo.GetstuName(3)

-- no 02
create proc SP_GetstuName02 @id int,@name varchar(50) output
with encryption
as 
	select @name=St_Fname
	from Student
	where St_Id=@id
declare @namee varchar(50)
execute SP_GetstuName02 3 ,@namee output
select @namee

-- no 03 
create proc SP_GetstuData03 @id int,@name varchar(50) output,@age int output
with encryption
as 
	select @name=St_Fname,@age=St_Age
	from Student
	where St_Id=@id
declare @namee varchar(50),@agee int
execute SP_GetstuData03 2,@namee output ,@agee output
select @namee as Name,@agee as Age

-- no 04
-- input  output parameter
create or alter proc SP_GetstuData02 @data int output,@name varchar(50) output
with encryption -->call by ref
as 
	select @name=St_Fname,@data=St_Age --output
	from Student
	where St_Id=@data -- input
declare @namee varchar(50),@data int = 2
execute SP_GetstuData02 @data output,@namee output
select @namee as Name,@data as Age


--passing by value
-- passing by ref/out >> Csharp 
-- Self :
/*
	Input output poarameter
	triggers >> special type od SP
	dynamic query >> SP with dynamic query >> merits of this + demirts
	passing param >> order.name,default value
*/


--------------------------------------------------------------


--SP with dynamic Query --> self study
alter proc SP_GetData @Table varchar(20),@col varchar(20)
as
	--select @col from @Table
	execute ('select'+@col+'from '+@table) --function+query(string)
	SP_GetData 'student' , '*'
-- concat , Security
--------------------------------------------------------------









--------------------------------------------------------------

--getstuNumberDep(@depId
CREATE OR ALTER FUNCTION GetStudCountByDeptID (@DeptID INT)
RETURNS INT
	BEGIN
		DECLARE @Count INT
		SELECT @Count= COUNT(Dept_Id)
		FROM Student
		WHERE Dept_Id = 10

		RETURN @Count
	END

SELECT dbo.GetStudCountByDeptID(10)

--------------------------------------------------------------
-- Views 
--1- statndard view Contains only one select statement
select *
from Student
--layer / gateway / view

create View StudentsView
as 
	select *
	from Student

select * from StudentsView
-- executed again ? -- Cached 


create View StudentsCairo
as
	select *
	from StudentsView
	where St_Address='cairo'
select * from StudentsCairo

create View StudentsAlex
as
	select *
	from StudentsView
	where St_Address='Alex'

select * from StudentsAlex

--2

-- Student table >> Students, StudentsCiro, StudentAlex
-- alias 
create view StudentsCairoNew(stId,FirstName,StudentAddress)
as
	select St_Id,St_Fname,St_Address
	from StudentsView
	where St_Address='cairo'

select * from StudentsCairoNew

create View StudentsAlexNew(stId,FirstName,StudentAddress)
as
	select St_Id,St_Fname,St_Address
	from StudentsView
	where St_Address='Alex'

select * from StudentsAlexNew

------------------------------------------------
-- 2- Partitioned View >> More than one select
-- 3
create view cairoAlexStudents
as
	select * from StudentsCairoNew
	union
	select * from StudentsAlexNew

select * from cairoAlexStudents
------------------------------------------------
-- 4
-- Hierarchy Of Database?
/*
 Server Level	=> Databases
 Database Level	=> Schemas
 Schema Level	=> Database Objects (Table, View, SP, and etc)
 Table Level	=> Columns, Constraints
*/

create schema Hr
Alter Schema Hr
Transfer cairoAlexStudents
Alter Schema dbo
Transfer Hr.cairoAlexStudents

-- 5 encrypt source code 
create or alter view StudepDataView(stID,stName,deptId,DeptName)
With Encryption
as
	select St_Id,St_Fname,D.Dept_Id,Dept_Name
	from Student S Join Department D
	on S.Dept_Id=D.Dept_Id

select * from StudepDataView

SP_helptext 'StudepDataView'
------------------------------------------------
-- 6 complex query
Create View StudentGradesView (StdName, CrsName, StdGrade)
With Encryption
as
	Select S.St_FName, C.Crs_Name, SC.Grade
	from Student S, Stud_Course SC, Course C
	where S.St_Id = SC.St_Id and C.Crs_Id = SC.Crs_Id

Select * from StudentGradesView

------------------------------------------------
-- 7
-- View + DML 
-- View >> one table
-- same deal with table
-- base table (one)
insert into StudentsCairoNew -- > table student 
values (11111,'Ali','Cairo')
select * from StudentsCairoNew
select * from Student
-- allow null, identity , default

delete from StudentsCairoNew
where stId=5656

-- View >> more than one base tables
create view StudepDataView(stID,stName,deptId,DeptName)
with encryption 
as
	select St_Id,St_Fname,D.Dept_Id,Dept_Name
	from Student S Join Department D
	on S.Dept_Id=D.Dept_Id
select * from StudepDataView
select * from Student
select * from Department
-- Delete >>> No  --- why?
delete from StudepDataView
where stID=1
--View or function 'StudepDataView' is not updatable because the modification affects multiple base tables.

-- insert / updte >> detect which base table >> Rules
insert into StudepDataView
values(567,'ali',10,'SD')
insert into StudepDataView (stID,stName)
values(567,'ali')
insert into StudepDataView (deptId,DeptName)
values(100,'Test')
-- Ali Last >> in our view ? Self

-- Modify :
create View StudepDataViewNew(StdId, StdName, FK_DeptId, DeptId, DeptName)
With Encryption
as
	Select St_Id, St_FName, S.Dept_Id, D.Dept_Id, D.Dept_Name
	from Student S inner join Department D
	on D.Dept_Id = S.Dept_Id

insert into StudepDataViewNew (StdId,StdName,FK_DeptId)
values(55555,'ali',10)
------------------------------------------------
-- 9 
create or alter View StudentsCairoNew(stId,FirstName,StudentAddress)
as
	select St_Id,St_Fname,St_Address
	from StudentsView
	where St_Address='cairo'
	with check option
select * from StudentsCairoNew
select * from Student
	
-- base table >> one >> student
insert into StudentsCairoNew
values(99999,'ali','Mansoura') 
--qualify under the CHECK OPTION constraint.
insert into StudentsCairoNew
values(99999,'ali','cairo')
------------------------------------------------

--------------------------- DCL ---------------------------------
-- [Login]          Server (Abdo)
-- [User]           DB iti (Abdo)
-- [Schema]         HR   [Department, Instructor]
-- Permissions      Grant [select,insert]    Deny [delete Update]
use DepiG01
Create Schema HR

alter schema HR
transfer Department

alter schema HR
transfer Instructor


-- Step 1: Create a SQL Server login
CREATE LOGIN TestUser WITH PASSWORD = 'StrongP@ssword123';
drop LOGIN TestUser;
-- Step 2: Create a demo database and use it
CREATE DATABASE CompanyDB;
GO
USE CompanyDB;
GO

-- Step 3: Create a schema
CREATE SCHEMA HR;
GO
-- Step 4: Create database user mapped to the login
CREATE USER TestUser FOR LOGIN TestUser;
--drop USER TestUser ;
-- Step 5: Create a table in the HR schema
CREATE TABLE HR.Employees (
    Id INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Position NVARCHAR(50)
);

-- Step 6: Insert some demo data
INSERT INTO HR.Employees VALUES (1, 'Alice Ahmed', 'Manager'), (2, 'Omar Khaled', 'Engineer');

-- Step 7: Create a stored procedure for data access
CREATE or alter PROCEDURE HR.GetEmployees
AS
    SELECT * FROM HR.Employees;

-- Step 8: Create a custom role
CREATE ROLE HR_ReadOnly;

-- Step 9: Grant read permissions to the role
GRANT SELECT ON HR.Employees TO HR_ReadOnly;
GRANT EXECUTE ON HR.GetEmployees TO HR_ReadOnly;
GRANT EXECUTE ON SCHEMA::HR TO HR_ReadOnly;

-- Step 10: Add TestUser to the role
EXEC sp_addrolemember 'HR_ReadOnly', 'TestUser';

-- Step 11: Deny delete to enforce read-only behavior (extra safety)
DENY DELETE ON HR.Employees TO TestUser;

select *
from HR.Employees
HR.GetEmployees

DELETE from HR.Employees where Id=1