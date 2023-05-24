Create Database LibraryManagement
use LibraryManagement
create Table Login_user(
user_id int identity Primary key,
user_name varchar(30),
user_password varchar(30)
)
drop table Loginuser
select * from Login_user

Create Table Book(
bookId int identity primary key,
bookTitle varchar(30),
authorname varchar(50),
publication varchar(50),
stock int,
price int
)
select * from Book
drop table Book

Create Table Student(
stdId int identity primary key,
stdName varchar(30),
rollno int,
department varchar(50),
email varchar(50),
phoneno bigint
)
drop table Student
select * from Student
insert into Login_user values('kaviya','abc123'),('star','123456'),('king','111111')

--insert into Book values(1,'Mysteries','Doris','Golden Publications',1500,10),(2,'The Rainbow','D.H.Lawrence','Novel Publications',2350,11)

Create Table Book_issue(
bookId int,
stdId int,
issue_date date,
primary key(bookId,stdId)
)
insert into Book_issue values(2,1,getdate())
select * from Book_issue
drop table Book_issue

select * from Book
select * from Student
select * from Book_issue
