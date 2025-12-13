Create Database LoginSystem

Create table Users 
( id int identity(1,1),
Username varchar(250),
Password varchar(250),
Email varchar(100),
Role varchar(250))

Drop table Users

Insert into Users (Username , Password , Email , Role) Values
('Admin' , 'xyz123' , 'admin@gmail.com' , 'Admin' ),
('Admin123' , 'xyz' , 'admin1@gmail.com' , 'Admin' ),
('Abc' , 'xyz3' , 'admin2@gmail.com' , 'Editor' ),
('Saleha' , 'abc' , 'user@gmail.com' , 'User' )

Select * from Users