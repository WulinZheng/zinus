Create table tblDepartment
(
 Id int primary key identity,
 Name nvarchar(50)
)

Insert into tblDepartment values('IT')
Insert into tblDepartment values('HR')
Insert into tblDepartment values('Payroll')

Create table tblEmployee
(
 EmployeeId int Primary Key Identity(1,1),
 Name nvarchar(50),
 Gender nvarchar(10),
 City nvarchar(50),
 DepartmentId int
)

Alter table tblEmployee
add foreign key (DepartmentId)
references tblDepartment(Id)

Insert into tblEmployee values('Mark','Male','London',1)
Insert into tblEmployee values('John','Male','Chennai',3)
Insert into tblEmployee values('Mary','Female','New York',3)
Insert into tblEmployee values('Mike','Male','Sydeny',2)
Insert into tblEmployee values('Scott','Male','London',1)
Insert into tblEmployee values('Pam','Female','Falls Church',2)
Insert into tblEmployee values('Todd','Male','Sydney',1)
Insert into tblEmployee values('Ben','Male','New Delhi',2)
Insert into tblEmployee values('Sara','Female','London',1)

go
Create procedure spGetAllEmployees
as
Begin
 Select EmployeeId, Name, Gender, City
 from tblEmployee
End
go

Create procedure spAddEmployee  
@Name nvarchar(50),  
@Gender nvarchar(10),  
@City nvarchar(50)
as  
Begin  
 Insert into tblEmployee (Name, Gender, City)  
 Values (@Name, @Gender, @City)  
End
go
	Create procedure spSaveEmployee      
	@Id int,
	@Name nvarchar(50),      
	@Gender nvarchar (10),      
	@City nvarchar (50)    
	as      
	Begin      
	 Update tblEmployee Set
	 Name = @Name,
	 Gender = @Gender,
	 City = @City
	 Where EmployeeId = @Id 
	End
	go
	Create procedure spDeleteEmployee
@Id int
as
Begin
 Delete from tblEmployee 
 where EmployeeId = @Id
End
select * from tblDepartment
select * from tblEmployee

Create Database EmployeeDB
Go

Use EmployeeDB
Go

Create table Employees
(
     ID int primary key identity,
     FirstName nvarchar(50),
     LastName nvarchar(50),
     Gender nvarchar(50),
     Salary int
)
Go

Insert into Employees values ('Mark', 'Hastings', 'Male', 60000)
Insert into Employees values ('Steve', 'Pound', 'Male', 45000)
Insert into Employees values ('Ben', 'Hoskins', 'Male', 70000)
Insert into Employees values ('Philip', 'Hastings', 'Male', 45000)
Insert into Employees values ('Mary', 'Lambeth', 'Female', 30000)
Insert into Employees values ('Valarie', 'Vikings', 'Female', 35000)
Insert into Employees values ('John', 'Stanmore', 'Male', 80000)
Go
select * from tblDepartment
ALTER TABLE tblDepartment
ADD IsSelected BIT
Update tblDepartment Set IsSelected = 1 Where Id = 1

CREATE TABLE tblCity
(
 ID INT IDENTITY PRIMARY KEY,
 Name NVARCHAR(100) NOT NULL,
 IsSelected BIT NOT NULL
)

Insert into tblCity values ('London', 0)
Insert into tblCity values ('New York', 0)
Insert into tblCity values ('Sydney', 1)
Insert into tblCity values ('Mumbai', 0)
Insert into tblCity values ('Cambridge', 0)
select * from tblEmployee

Alter table tblEmployee Add Photo nvarchar(100), AlternateText nvarchar(100)
Update tblEmployee set Photo='~/Photos/JohnSmith.png', 
AlternateText = 'John Smith Photo' where EmployeeId = 1

CREATE TABLE tblComments
(
   Id INT IDENTITY PRIMARY KEY,
   Name NVARCHAR(50),
   Comments NVARCHAR(500)
)

Alter table tblEmployee
Add HireDate Date
set dateformat dmy

Update tblEmployee Set HireDate='20-10-2010' where EmployeeId=1
Update tblEmployee Set HireDate='13-07-2008' where EmployeeId=2
Update tblEmployee Set HireDate='11-11-2005' where EmployeeId=3
Update tblEmployee Set HireDate='23-10-2007' where EmployeeId=4

Create table tblUsers
(
 [Id] int primary key identity,
 [FullName] nvarchar(50),
 [UserName] nvarchar(50),
 [Password] nvarchar(50) 
)


-------------database employeeDB------------------
Create Table Users
(
     Id int identity primary key,
     Username nvarchar(100),
     Password nvarchar(100)
)

Insert into Users values ('male','male')
Insert into Users values ('female','female')