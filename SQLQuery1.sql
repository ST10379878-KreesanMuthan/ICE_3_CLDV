use SMSDB --tells management system to switch from master to DB we want to use

-- the queries line (2-6) work if there is an existing db, hence highlight Create DATABASE, then unhighlight it and run file 
-- use this as bases when creating database


-- TABLE CREATION SECTION
     --    TableName  
CREATE TABLE Student (
--Attributes  IDENTITY ALLOWS US TO AUTOINCREMENT, will start at 1 and increment by 1 automatically
StudentID INT IDENTITY(1,1) PRIMARY KEY NOT NULL, -- NOT NULL means it has to be filled in - required
              --()= domain= amount we are storing
STNumber VARCHAR(10) NOT NULL, -- VARCHAR ALLOWS US TO STORE ALPHANUMERIC = STRING
[Name] VARCHAR(150) NOT NULL, -- place in [] as if not Name is a key word in sql,hence we put it in [] to change it to a normal text to keep consisitency 
Surname VARCHAR(150) NOT NULL,-- doesnt need comma as its last attribute
--Adding a placeholder for the url of an image
ProfilePicture VARCHAR(MAX) NOT NULL
); 

CREATE TABLE Module(
ModuleID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Code VARCHAR(8) NOT NULL,
[Name] VARCHAR(150) NOT NULL
);

CREATE TABLE ENROLLMENT(
EnrollmentID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
                                    --Table  Attribute we want
StudentID INT FOREIGN KEY REFERENCES Student(StudentID) NOT NULL, -- getting from another table
ModuleID INT FOREIGN KEY REFERENCES Module(ModuleID),
[Status] VARCHAR(60) NOT NULL,
Semester INT NOT NULL -- does not need a domain -()  as it is an INT,would block other ints
);


-- TABLE INSERTION SECTION
--without IDENTITY
--Student(StudentID,STNumber,[Name],Surname) --has to be in order we defined it earlier
--VALUES (1,'ST103798','Kreesan','Muthan') -- Inserting Student one by one 

INSERT INTO Student(STNumber,[Name],Surname,ProfilePicture) --has to be in order we defined it earlier
VALUES ('ST103798','Kreesan','Muthan','https://cdn.vectorstock.com/i/500p/21/23/avatar-photo-default-user-icon-person-image-vector-47852123.jpg'),
('ST105678','Nowhere','Somewhere','https://cdn.vectorstock.com/i/500p/21/23/avatar-photo-default-user-icon-person-image-vector-47852123.jpg')-- Inserting Multiple Students



INSERT INTO Module(Code,[Name])
VALUES('CLDV6211','Cloud developement'),
('PROG6211','Programming 1A')

INSERT INTO Enrollment(StudentID,ModuleID,[Status],Semester)
VALUES(1,1,'Pending',3)
--TABLE ALTERATION SECTION

-- TABLE MANIPULATION SECTION
SELECT * FROM Student
SELECT * FROM Module
SELECT * FROM Enrollment

--STORED PROCEDURES



-- Main notes:
-- CAPATALISE ALL SQL CODE (BLUE IN COLOUR)
-- double clicking on an error msg takes you to the line
-- Control R removes messages box