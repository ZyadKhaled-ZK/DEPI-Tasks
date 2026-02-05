-- transaction 
-- MS :  T-SQL
-- DML (insert - update -delete) : Data
-- transactions ?
-- Engine : Data recovery
-- insert - update -delete >> Logging in ldf
-- logging ?  Automatic rollback
-- insert - delete ...
-- error : 
-- insert  >>   ldf as transaction
-- Mdf     >>  ok  >>  commit transaction
-- MDf     >>  not ok  >>  rollback transaction

-- Server / Engine 
-- insert-update- delete : implicit transaction
-- why engine ?  
-- Recovery --  Self >> DBA

-- Explicit : 
-- Bank transfer 
-- withdraw   -- deposit -- Error (physical error - Logical error)
-- make sure : two operations : execute together
-- set of queries >> as single unit of work
-- withdraw   -- deposit >> commit , rollback

--SQL : TCL
-- transactions : management / Control 
-- begin transaction
--  set of queries as single unit of work
-- Commit // rollback

-------------------------- Transaction -------------------------
-- 1. Implicit Transaction (DML Query [Insert, Update, Delete])

Insert Into Student(St_Id, St_Fname) Values (100, 'Ahmed'), (101, 'Amr')

Update Student set St_Age = 30 where St_Age = 20


-- 2. Explicit Transaction (Set Of Implicit Transactions as single unit of work)
create table Parent
(
ParentId int primary key
)
create table Child
(
ChildId int primary key,
ParentId_FK int references Parent(ParentId)
)

-- batch : highlighted query : queries not related to each other
insert into Parent values(1)
insert into Parent values(2)
insert into Parent values(3)


insert into Child values(1,1)
insert into Child values(2,10) -- error
insert into Child values(3,2)

select* from child
--commit tran

begin transaction
insert into Child values(4, 1)
insert into Child values(5, 10) --> error(logical,physical error(lights went out, server fails))
insert into Child values(6, 2)
-- Commit   //  rollback
commit tran


begin transaction
insert into Child values(7, 1)
insert into Child values(8, 10) -- error
insert into Child values(9, 2)
rollback tran



begin try
	begin transaction
		insert into Child values(7, 1)
		insert into Child values(8, 3)
		insert into Child values(9, 10)--error
		insert into Child values(10, 2)
	commit tran
end try
begin catch
	rollback tran 
end catch

select * from child

-- save points >> partial rollback
begin try
	begin transaction
		insert into Child values(7, 1)
		save transaction p01
		insert into Child values(8, 3)
		insert into Child values(9, 10)
		insert into Child values(10, 2)
	commit tran
end try
begin catch
	rollback tran p01
end catch
--------------------------------------------------------------
-- variables : 
-- separate queries >> Containers  >> Function / SP/ Views
-- functions : 
-- var  control statement
-- local   global 
-- { int X;  }  X  : local var 
-- SQL ? 
-- local var : 
-- 1- @X  2- local to batch they declared in
-- lifetime : they exist during batch execution
-- batch  :  highlite >> access in batch in declare

-- 1- decalre  2- assign value(4)  3- use(display)
declare @x int  --@X ? -- default value in sql  >> null
set @x = 10
select @x

declare @x int =10 --@X ? -- default value in sql  >> null
--set @x = 10
select @x

declare @x int  --@X ? -- default value in sql  >> null
select @x = 15
select @x

use iti
declare @x int 
select @x=Avg(St_Age) from Student
select @x

-- update + select 
-- one trip rather tahn two_round trips
declare @x int
update Student set @x=st_age where st_id =9
select @x

declare @x int
update Student set @x=st_age,St_Fname='Ali' where st_id =9
select @x

-- Possibilities
-- return one value
declare @x int 
select @x=Avg(St_Age) from Student
select @x

-- return no value :
-- return last value assigned
declare @X varchar(max)='ali'
select @X=St_Fname from Student where st_id=99898
select @X

-- return more than one value :
-- return last value
declare @X varchar(max)
select @X=St_Fname from Student where St_Address='cairo'
select @X

-- query more than  one value
-- var of table (runtime table)
declare @X table (name varchar(50), Ages int)
--insert based on select
insert into @X
select St_Fname,St_Age from Student where St_Address='cairo'
select * from @x

-- dynamic query >> Execute keyword -- self
--------------------------------------------------------------
-- global var >> lang >> SQL
-- not decalre   not assign  Use it only
-- built_in
-- @X >> local    @@serverName
select @@servername --> server name >> ur engine
select @@Version --> sql server engine
select @@Rowcount --> last query (no of rows affected)
select @@error --> last query (No errors > 0,error >> error Number)

update student
set St_Age+=1
select @@ROWCOUNT
select @@error

select * from stu
select @@error

-- local var =  global var
update student
set St_Age-=1
declare @X int 
select @X=@@ROWCOUNT
select @x

------------------------------------------------------
--Flow control >> condition
-- loop >> SQL
/*
if - begin - end
if exists - if not exists
while - continue - break
case - iif - wait for - choose >> self
*/

-- Conditional :
/*
if(X>1)  >> ( ) >> optional
{  >>  begin >> {} >> optional >> single Line
	block executed
}  >> end
*/


update student
set St_Age+=1
declare @X int
select @X=@@ROWCOUNT

if @X>1
	begin
		select 'multi lines affected'
	end
else
	select 'zero lines affected'

--------------- error -----------------------
-- DB >> crash app >> defensive query >> avoid error
-- potential for problems
-- try >>  catch  >> can't Detect problem
begin try
-- DML : potential problems : Insert,update,delete
	Delete from Department where Dept_Id=40
end try
begin catch
	select 'error' 
	select ERROR_LINE(),ERROR_NUMBER(),ERROR_MESSAGE()
end catch

-- can detect error
if not exists(select Dept_Id from Student where Dept_Id=40)
and
not exists(select Dept_Id from Instructor where Dept_Id=40)
	Delete from Department where Dept_Id=40
else 
	select 'table has rships'

-- self 
---> what's between two approaches >> logging , performance level

-- control >> Loops
-- while , continue, break >> SQl
declare @x int =10
while @x<30
	begin --{
		set @x+=1
			if(@x=12)
				continue --> return to loop condition
			if(@x=15)
				break --> get out of loop
			select @x
	end --}

	-- 11 13 14
	---------------------------------------------------
	-- function >> functionality >> container
	-- reuse function
	-- built in -- user Defined >> 3 types
	-- have to return value >> built_in >> one value >> scalar
	-- 3 types of user defined functions
	-- specify fun type>>  based on return 
	-------------------------------user defined fun --------------------
	-- structure , types

	--> Scalar >> one value
	--> Inline table >> table 
	--> Multi statement >> table 

	--  clean  :  expressive
	--> 1- signature (Name,parameters,return type)
	--> 2- body > only select statemnt >> scalar,Inline table
	--          > logic+select+insert based on select >> Multi statement
	-- function : have to end with return

	-- 1- scalar 
	-- DB object (structure)
	-- local : limited to batch declared + function + SP 
	-- built_in function >> scalar
	-- Engine : built_in 
	create function GetStudentNameById (@stId int)
	returns varchar(max)  -- signature
	begin
		declare @name varchar(max)
		select @name=St_Fname
		from Student
		where St_Id=@stId
		return @name
	end

	select dbo.GetStudentNameById(8)
	-- have to write schema name
	
	---------------------------------------------------
	-- 2- Inline table >> table > only select statement >> no logic
	-- return table -- business
	-- Id of dept >> Ins data based on dep
	-- only select  +   No logic
	-- Inline table 
	create or alter function GetDeptInsDataByDeptId(@deptId int)
	returns table
	as 
		return
		(
			select Ins_Id,Ins_Name,Dept_Id,Salary*6 as [Mid_Annual Salary]
			from Instructor
			where Dept_Id=@deptId
		)

	select * from GetDeptInsDataByDeptId(20)
	---------------------------------------------------
	-- 3- Multi statement : select , Insert based on select , Logic
	-- business : Logic , insert based on select ?
	-- flow control >> Logic
	/*
	pattern in >> based on it >> output
	-- first >> id , fname
	-- last >> id , lname
	-- full >> id , fulname
	*/
	
	create function GetStuDataByPattern(@pattern varchar(20))
	returns @t table 
	(
		id int,
		stuNAme varchar(max)
	)

	as 
		begin
			if @pattern = 'first'
			insert into @t
			select st_id,St_Fname
			from Student
			else if @pattern = 'last'
			insert into @t
			select st_id,St_Lname
			from Student
			else if @pattern = 'full'
			insert into @t
			select st_id,St_Fname+' '+St_Lname
			from Student
			return
		end

select * from GetStuDataByPattern('full')
---------------------------------------------------
