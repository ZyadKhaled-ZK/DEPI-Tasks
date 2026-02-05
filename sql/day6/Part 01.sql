-- 1. Returns the month name (e.g., January, February) for a given date
CREATE FUNCTION GetMonthName (@Date DATE)
RETURNS VARCHAR(20)
AS
BEGIN
    RETURN DATENAME(MONTH, @Date)  -- Extracts the month name from the input date
END
#####################

-- 2. Returns a table of integer values between @Start and @End (exclusive)
CREATE FUNCTION GetValuesBetween (@Start INT, @End INT)
RETURNS @Results TABLE (Value INT)
AS
BEGIN
    DECLARE @Counter INT = @Start + 1  -- Start counting from the next integer after @Start
    WHILE @Counter < @End
    BEGIN
        INSERT INTO @Results VALUES (@Counter)  -- Insert the current counter value into result table
        SET @Counter += 1  -- Increment counter by 1
    END
    RETURN
END
#####################

-- 3. Returns a table with the full name of a student and their department name for a given student ID
CREATE FUNCTION GetStudentDeptInfo (@St_Id INT)
RETURNS TABLE
AS
RETURN (
    SELECT 
        ISNULL(S.St_Fname, '') + ' ' + ISNULL(S.St_Lname, '') AS [Full Name],  -- Concatenate first and last name
        D.Dept_Name  -- Department name
    FROM Student S 
    JOIN Department D ON S.Dept_Id = D.Dept_Id
    WHERE S.St_Id = @St_Id  -- Filter by given student ID
)
#####################

-- 4. Checks whether the first and last names of a student are NULL, and returns a message accordingly
CREATE FUNCTION CheckStudentNames (@St_Id INT)
RETURNS VARCHAR(50)
AS
BEGIN
    DECLARE @Msg VARCHAR(50)
    SELECT @Msg = 
        CASE 
            WHEN St_Fname IS NULL AND St_Lname IS NULL THEN 'First name & last name are null'
            WHEN St_Fname IS NULL THEN 'first name is null'
            WHEN St_Lname IS NULL THEN 'last name is null'
            ELSE 'First name & last name are not null'
        END
    FROM Student
    WHERE St_Id = @St_Id
    RETURN @Msg  -- Return the message describing the name status
END
#####################

-- 5. Returns a table listing department names, manager names, and the manager's hire date formatted according to @FormatID
CREATE FUNCTION GetMgrHireDateFormatted (@FormatID INT)
RETURNS TABLE
AS
RETURN (
    SELECT 
        D.Dept_Name,
        I.Ins_Name AS Manager_Name,
        CONVERT(VARCHAR(50), D.Manager_hiredate, @FormatID) AS Formatted_Date  -- Format the date based on the style code
    FROM Department D
    LEFT JOIN Instructor I ON D.Dept_Manager = I.Ins_Id
)
#####################

-- 6. Returns a table of student names based on the specified type ('first name', 'last name', or 'full name')
CREATE FUNCTION GetStudentNameByType (@Type VARCHAR(20))
RETURNS @Result TABLE (StudentName VARCHAR(100))
AS
BEGIN
    IF @Type = 'first name'
        INSERT INTO @Result SELECT St_Fname FROM Student
    ELSE IF @Type = 'last name'
        INSERT INTO @Result SELECT St_Lname FROM Student
    ELSE IF @Type = 'full name'
        INSERT INTO @Result 
        SELECT ISNULL(St_Fname, '') + ' ' + ISNULL(St_Lname, '') FROM Student
    
    RETURN  -- Return the resulting table
END
#####################

-- MyCompany DB: Returns a list of employees and the hours they worked on a specific project number
CREATE FUNCTION GetEmployeesByProject (@ProjectNo INT)
RETURNS TABLE
AS
RETURN (
    SELECT 
        E.Fname + ' ' + E.Lname AS [Employee Name],  -- Concatenate employee first and last name
        W.Hours AS [Hours Worked]  -- Number of hours worked on the project
    FROM Employee E
    JOIN Works_for W ON E.SSN = W.ESSn
    WHERE W.Pno = @ProjectNo  -- Filter by project number
)
