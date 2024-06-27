# LoginFormProject

create database CRUD

use CRUD

Create table  UserEntity(
Id int IDENTITY(1,1) NOT NULL primary key,
Name varchar(20) NOT NULL,
PhoneNumber varchar(10) NOT NULL,
Email varchar(30) NOT NULL,
Gender varchar(6) NOT NULL
)

--To insert an UserEntity Record:

Create procedure spAddUserEntity
(
@Name VARCHAR(20),
@PhoneNumber VARCHAR(10),
@Email VARCHAR(30),
@Gender VARCHAR(6)
)
as
Begin
Insert into UserEntity (Name,PhoneNumber,Email, Gender)
Values (@Name,@PhoneNumber,@Email, @Gender)
End


--To update an UserEntity Record:

Create procedure spUpdateUserEntity
(
@UEId INTEGER ,
@Name VARCHAR(20),
@PhoneNumber VARCHAR(10),
@Email VARCHAR(30),
@Gender VARCHAR(6)
)
as
begin
Update  UserEntity 
set Name=@Name,
PhoneNumber=@PhoneNumber,
Email=@Email,
Gender=@Gender
where Id=@UEId
End

--To delete an UserEntity  Record:

Create procedure spDeleteUserEntity
(
@UEId int
)
as
begin
Delete from UserEntity  where Id=@UEId
End

--To view all  UserEntity  Records:

Create procedure spGetAllUserEntity
as
Begin
select *
from UserEntity
End

--To view a UserEntity by id Record:

Create procedure spGetUserEntityById
(
@UEId int
)
as
begin
select * from UserEntity  where Id=@UEId
End
