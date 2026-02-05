-- variables :
-- container for a value
-- select st_age from student
-- function / SP 
-- param - Return

-- Var : 
-- 1- Local 
-- { int X;  }
-- SQL : 
-- 1- local to batch they declared
-- 2- Access var through batch declared in
-- > life time of local var : batch execution 
-- batch ?!
-- highlighted queries : set of queries 
-- 3- @X

-- 1-declare  2-assign(set,select,decalre) 3-use (Display)
-- declare
-- default value : null
declare @x int 
-- Assign
set @x = 56
-- select @x = 34
-- use 
select @x

-- level 02
declare @x int 
select @x=AVG(St_Age) from Student
select @x

declare @x int
update Student 
set @x = St_Age where st_id = 9
select @x

-- level 03
-- assign one value to containers 

-- 1- No value
-- Engine : return last value assigned
-- null
declare @x varchar(50) = 'ali'
select @x=St_Fname from Student where St_Id = 98796
select @x

-- 2- More than one value
-- Engine  : return last of value
declare @x varchar(50)
select @x=St_Fname from Student where St_Address = 'cairo'
select @x

-- var of table : 
-- virtual table - non physical table
-- Runtime table
declare @x table(names varchar(50),ages int)
insert into @x
select St_Fname,St_Age from Student where St_Address = 'cairo'
select * from @X

-- dynamic query >> Exec keyword > self



-- 2- Global 
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

select * from Stu
select @@error

-- local var =  global var
update student
set St_Age-=1
declare @X int 
select @X=@@ROWCOUNT
select @x

------------------------------------------------------

--Flow control >>
-- condition
-- loop 
-- >> SQL

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
	// block executed
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
-- try : queries : once error appeared : catch block 
-- catch : block execution errro appeaered
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

-- control >>
-- Loops
-- while , continue, break >> SQl
declare @x int =10
while (@x<30)
	begin --{
		set @x+=1
			if(@x=12)
				continue --> return to loop condition
			if(@x=15)
				break --> get out of loop
			select @x
	end --}
	-- 11 13 14
	
	----------------------------------------------------------

	-- Function : 
	-- Functionalities >> container >> reuse function
	-- SQl : 
	-- 1- built_in function  
	-- scalar functions >> return one value
	-- 2- User defined functions
	-- build it >> use : business
	-- 3 types : 
	-- specifiy type return type + body Logic

	-- types , structure 
	-- 1- scalar fun >> return one value
	-- 2- inline table >> more than one value >> table
	-- 3- Multi_statement >> retrurn more than one value >> table

	-- function :
	-- Name expressive - Clean
	-- Parameters : optional
	-- return  : have to return 
	-- function have to end with return 

	-- 1- Signature >>
	-- Name - parameters - return 
	-- 2- body >>
	-- only select statement : scalar , inline table
	-- Multi_statement :
	-- Select + Logic + insert based on select 

	-- Scalar 
	-- Businees : 
	-- in : stId 
	-- out : stname 

	-- Dbobject : DDL 
	-- Schema  >>> self
	-- dynamic
	-- have to write schema name : scalar 
	-- local var : 
	-- local to batch they declared
	-- local to function 
	-- or SP 

	create or alter function GetStuNameById( @StId int )
	returns varchar(50) -- signature

	begin
		declare @x varchar(50)
		select @x=St_Fname
		from Student
		where St_Id = @StId
		return @x
	end

	select dbo.GetStuNameById(3)



	------------------------------------------------


	-- in : dept _ id 
	-- out : Ins data in dept_id

	-- return More than one value :
	-- Inline / Multi statement 

	-- only select >>  Inline
	
	create function GetInsDataByDeptId(@dept_id int)
	returns table -- signature

	as 
		return 
		(
			select Ins_Id,Ins_Name,Salary * 12 as [Annual Salary]
			from Instructor
			where Dept_Id = @dept_id
		)

		
	select * from GetInsDataByDeptId(20)

	-----------------------------------------------

	-- in : pattern 
	-- out : based on : id of std , name of student 
	/*
	first  >>  id ,  fname
	last   >>  id ,  lname
	full   >>  id ,  full name
	*/

	-- more than value 
	-- body : select + logic 

	-- Multi_statement 

	create or alter function GetStuDataById(@pattern varchAR(50))
	returns @t table (id int ,ReqName varchar(50) ) -- siganture

	as 
		begin
			if @pattern = 'first'
				insert into @t
				select st_id,St_Fname from Student
			else if @pattern = 'last'
				insert into @t
				select st_id,St_Lname from Student
			else if @pattern = 'full'
				insert into @t
				select st_id,St_Fname + ' ' + St_Lname from Student as fullName
			return
		end

	select * from GetStuDataById('full')

	-----------------------------------------------

	-- transaction :
	-- T-SQL : ANsI sql 
	-- MS : T-SQL : tyransaction : operation on Db
	-- transaction :
	-- insert , update , delete >> transaction 

	-- Engine : 
	-- by default :
	-- DML :
	-- Delete frorm department where dept_id = 40

	-- 1- Logging
	-- Log first  data later 

	-- check .Mdf >> delete
	-- Delete on hard disk : commit transaction 

	-- error : No delete : rollback transaction

	-- DML : .ldf -->  .mdf 
	-- why 
	-- data recovery -> server physical : fail

	-- transcation : 
	-- begin tran 
	-- DML 
	-- commit / rollback 

	-- insert / update / delete  
	
	-- 1- implicit transaction 
	--> backups >> DBA --> delete 
	--> restore data >> self

	-- control transaction : business needs
	-- 2- explicit transaction 
	-- 1- withdraw -500 
	-- 2- deposit  +500
	-- practices : 
	-- Atomicity : set of DML queries >> as single unit of work 
	-- ACID >> self

	-- TCL : tran control lang
	-- begin tran 
	-- Commit 
	-- rollback

	-- lock >> self
	-- dirty page >> self
	-- Clean page, quick, Ram >> self

	----------------------------------------------

	-------------------------- Transaction -------------------------
-- 1. Implicit Transaction (DML Query [Insert, Update, Delete])

Insert Into Student(St_Id, St_Fname) Values (100, 'Ahmed'), (101, 'Amr')

Update Student set St_Age = 30 where St_Age = 20


-- 2. Explicit Transaction (Set Of Implicit Transactions as single unit of work)
use DepiG01
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

begin tran
	insert into Child values(4, 1)
	insert into Child values(5, 10) --> error(logical,physical error(lights went out, server fails))
	insert into Child values(6, 2)
	-- Commit   //  rollback
commit tran


begin transaction
	insert into Child values(7, 1)
	insert into Child values(8, 1)
	insert into Child values(9, 2)
rollback tran

-- jandle error

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



-- save points >> partial rollback >> self
begin try
	begin transaction
		insert into Child values(7, 1) -- bill record
		save transaction p01
		insert into Child values(8, 3) -- withdraw
		insert into Child values(9, 10) -- deposit  -->error : server fail
		-- insert into Child values(10, 2)
	commit tran
end try
begin catch
	rollback tran p01
end catch

-- check points >> lazy writer  >> self


