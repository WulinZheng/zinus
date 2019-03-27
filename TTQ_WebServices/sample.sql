﻿Create Table tblStudents
(
 ID int identity primary key,
 Name nvarchar(50),
 Gender nvarchar(20),
 TotalMarks int
)

Insert into tblStudents values('Mark Hastings','Male',900)
Insert into tblStudents values('Pam Nicholas','Female',760)
Insert into tblStudents values('John Stenson','Male',980)
Insert into tblStudents values('Ram Gerald','Male',990)
Insert into tblStudents values('Ron Simpson','Male',440)
Insert into tblStudents values('Able Wicht','Male',320)
Insert into tblStudents values('Steve Thompson','Male',983)
Insert into tblStudents values('James Bynes','Male',720)
Insert into tblStudents values('Mary Ward','Female',870)
Insert into tblStudents values('Nick Niron','Male',680)
go
Create Proc spGetStudentByID
@ID int
as
Begin
 Select ID, Name, Gender, TotalMarks
 from tblStudents where ID = @ID
End
select * from tblStudents