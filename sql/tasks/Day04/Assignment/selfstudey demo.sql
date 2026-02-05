------------------------------------------------------------
---------------------- 2. Null Functions -------------------
------- 1. IsNull
select st_Fname
from Student

select st_Fname
from Student
where St_Fname is not null

select isnull(st_Fname, '')
from Student

select isnull(st_Fname, 'Student Has No FName')
from Student

select isnull(st_Fname, St_Lname) as NewName
from Student

------- 2. Coalesce
select coalesce(st_Fname, St_Lname, St_Address, 'No Data')
from Student


---------------------------------------------------------
---------------------- 3. Casting Functions ----------------

select St_Fname +' '+ St_Age
from student

------- 1. Convert [Convert From Any DateType To DateType]
select St_Fname +' '+ Convert(varchar(2), St_Age)
from student

select 'Student Name= ' + St_Fname + ' & Age= '+ Convert(varchar(2), St_Age)
from student

select IsNull(St_Fname,'')+' '+ Convert(varchar(2), IsNull(St_Age, 0))
from student

-- Concat => Convert All Values To String Even If Null Values (Empty String)
select Concat(St_Fname, ' ', St_Age)
from student


------- 2. Cast [Convert From Any DateType To DateType]
select cast(getdate() as varchar(50))

-- Convert Take Third Parameter If You Casting From Date To String
-- For Specifying The Date Format You Need
select convert(varchar(50),getdate(),101)
select convert(varchar(50),getdate(),102)
select convert(varchar(50),getdate(),110)
select convert(varchar(50),getdate(),111)

------- 3. Format [Convert From Date To String]

select format(getdate(),'dd-MM-yyyy')
select format(getdate(),'dddd MMMM yyyy')
select format(getdate(),'ddd MMM yy')
select format(getdate(),'dddd')
select format(getdate(),'MMMM')
select format(getdate(),'hh:mm:ss')
select format(getdate(),'hh tt')
select format(getdate(),'HH')
select format(getdate(),'dd MM yyyy hh:mm:ss')
select format(getdate(),'dd MM yyyy hh:mm:ss tt')
select format(getdate(),'dd')

---------------------------------------------------------
------------------- 4. DateTime Functions ---------------

select getdate()
select day(getdate())
select Month(GETDATE())
select eomonth(getdate())
select eomonth('1/1/2000')
select format(eomonth(getdate()),'dd')
select format(eomonth(getdate()),'dddd')

---------------------------------------------------------
------------------- 5. String Functions --------------------

select lower(st_fname),upper(st_lname)
from Student

select substring(st_fname,1,3)
from Student

select len(st_fname),st_fname
from Student

---------------------------------------------------------
--------------------- 6. Math Functions -----------------

select power(2,2)


-- log sin cos tan

---------------------------------------------------------
--------------------- 7. System Functions ---------------

select db_name()

select suser_name()

select @@ServerName