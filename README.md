# GuestBook
Guest Book is a web application which allow to user to add a messages to other people and repley to their messages. 

## Built With:
<ul>
  <li>C# ASP.NET MVC </li>
  <li>HTML</li>
  <li>CSS</li>
  <li>Bootstrap</li>
</ul>

## Getitng started
This is an example of how you may give instructions on setting up your project locally. To get a local copy up and running follow these simple example steps.
## Requirements
 ```
 .Net Framework 4.5.2
 Visual Studio
 SQL Server Manager
  ```
## installation
### 1. Create the database in your SQL server manager</li>
 Excute this query to create the database:<br/>
  ```
  Create Database GuestBook
  
   Create Table [user](
     [UID] integer primary key not null identity(1,1) ,
     [email] nvarchar(20) not null ,
     [UserName] nvarchar(10) not null ,
     [password] nvarchar(20) not null
                       );
                       
  Create Table [message] (
    [MID] integer primary key not null identity(1,1) ,
    [Descreption] nvarchar(200) not null,
    [PID] integer ,
    [User_ID] integer foreign key References [user](UID) ,
                        );
  ```
  
 ### 2. Pull The code and open it on your visual studio
 ``` git pull geramazen/GuestBook```
 ### 3. connect the database with the code
 Do this after change the **source** server in the connection string with your server name.
 ```
 <connectionStrings>
<add name="GuestBookEntities" connectionString="metadata=res://*/Models.Model1.csdl|res://*/Models.Model1.ssdl|res://*/Models.Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=DESKTOP-72C5OHI;initial catalog=GuestBook;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
 </connectionStrings>
  ```
 ### 4. run the code
 



