# ZemogaBlog_MVC
MVC App for Zemoga technical test

Created for .NET developer Zemoga technical test.
Creation Date: 22/12/2019

TECHNOLOGIES:
- .NET Core 2.2 (use this vesion to skip Azure v 3.0 deployment restrictions)
- SQL Server (DB deployed to azure)
- Linq2DB as ORM 
- Web API
- Repository Pattern for Data Access
- DI

KNOW ISSUES:
- The registration logic work but it redirects to no welcome page yet. 
- The API is user authentication agnostic. 
  It just performs List / Approve/Reject operations regardless if the user is Editor (this logic is fully implemented in MVC application)
  

CREDENTIALS:
Not needed for common users, since you can use registration feature.

Anyway, here you can find some credentials for created users, as well as credentials for Editor users:

UserName	    Password	Role
-------------------------------
aleksortizr	  password	User

editor	      editor	  Editor

aortizr	      password	User

aleksortizr1	password	User

agortiz	      agortiz	  User

admin	        admin	    Editor
  
