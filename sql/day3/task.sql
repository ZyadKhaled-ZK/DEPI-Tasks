-- 1. Inserting a new student record into the Student table
INSERT INTO Student (St_Id, St_Fname, St_Lname, St_Address, St_Age, Dept_Id)
VALUES (101, 'Zyad', 'Khaled', 'Shabin', 20, 30);

-- Inserting a new instructor record into the Instructor table
INSERT INTO Instructor (Ins_Id, Ins_Name, Ins_Degree, Salary, Dept_Id)
VALUES (501, 'Omar Ali', 'MSc', 4000, 30);

-- Increasing salary of all instructors by 20%
UPDATE Instructor
SET Salary = Salary * 1.20;

==============================================================================
-- 2. Selecting all columns from Employee table
SELECT * FROM Employee;

-- Selecting first name, last name, salary, and department number from Employee table
SELECT Fname, Lname, Salary, Dno
FROM Employee;

-- Selecting project name, location, and department number from Project table
SELECT Pname, Plocation, Dnum
FROM Project;

-- Selecting full name of employee and their annual commission (10% of annual salary)
SELECT Fname + ' ' + Lname AS [Full Name], 
       (Salary * 12) * 0.10 AS [ANNUAL COMM]
FROM Employee;

-- Selecting SSN and full name of employees with salary greater than 1000
SELECT SSN, Fname + ' ' + Lname AS Name
FROM Employee
WHERE Salary > 1000;

-- Selecting SSN and full name of employees with annual salary greater than 10,000
SELECT SSN, Fname + ' ' + Lname AS Name
FROM Employee
WHERE (Salary * 12) > 10000;

-- Selecting full name and salary of female employees
SELECT Fname + ' ' + Lname AS Name, Salary
FROM Employee
WHERE Sex = 'F';

-- Selecting department number and name where manager's SSN is 968574
SELECT Dnum, Dname
FROM Departments
WHERE MGRSSN = 968574;

-- Selecting project number, name, and location where department number is 10
SELECT Pnumber, Pname, Plocation
FROM Project
WHERE Dnum = 10;

==============================================================================
-- 3. Counting the total number of students by counting their age entries
SELECT COUNT(St_Age) AS StudentCount
FROM Student;

-- Selecting unique instructor names (no duplicates)
SELECT DISTINCT Ins_Name
FROM Instructor;

-- Selecting instructor names and their corresponding department names using LEFT JOIN
SELECT I.Ins_Name, D.Dept_Name
FROM Instructor I 
LEFT OUTER JOIN Department D ON D.Dept_Id = I.Dept_Id;

-- Selecting full student names and the courses they have grades for (non-null grades)
SELECT S.St_Fname + ' ' + S.St_Lname AS FullName, C.Crs_Name
FROM Student S
JOIN Stud_Course SC ON S.St_Id = SC.St_Id
JOIN Course C ON C.Crs_Id = SC.Crs_Id
WHERE SC.Grade IS NOT NULL;

-- Selecting topic names and the number of courses under each topic (including topics with zero courses)
SELECT T.Top_Name, COUNT(C.Crs_Id) AS CourseCount
FROM Topic T
LEFT JOIN Course C ON T.Top_Id = C.Top_Id
GROUP BY T.Top_Name;

-- Selecting students and their supervisors by joining Student table with itself on supervisor ID
SELECT S.St_Fname AS StudentName, Super.*
FROM Student S
JOIN Student Super ON Super.St_Id = S.St_super;
