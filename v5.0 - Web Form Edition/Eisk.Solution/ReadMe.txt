==============================================================================
Employee Info Starter Kit (v5.0.0)

Architecture Designed and Implemented By:
Mohammad Ashraful Alam
Microsoft Most Valuable Professional, ASP.NET 2007 – 2011
Twitter: http://twitter.com/AshrafulAlam | Blog: http://blog.ashraful.net | Portfolio: http://www.ashraful.net

==============================================================================

This page contains a brief overview of this starter kit. For more information and quick start tutorials, please check: http://eisk.codeplex.com/documentation

==============================================================================

Employee Info Starter Kit is a web application that illustrate a wide range of architectural guidelines and samples to address different types of real world challenges faced by web application developers.

This architecture reference and the starter kit will help you to gain solid understanding and hand on experience to build different application layers, such as presentation layer, business logic layer, data access layer and automated testing framework - using latest ASP.NET, Entity Framework, SQL Server 2008 and Visual Studio based technologies.

*Minimum System Requirements*

* Visual Studio Ultimate Edition
* Sql Server (Express Edition) or higher

*User End Functional Specification*

The user end functionalities of this starter kit are pretty simple and straight forward that are focused in to perform CRUD operation on employee records as described below.

+Creating a new employee record+
The users should be able to create new employee record, one at a single time.
+Read existing employee record+
The users should be able to view the employee records in list style, where maximum 10 records can be visible per page and the list can be filtered out based on their supervisors. The user should also be able to view employee records with details, once at a single time and can print it in a printable format.
+Update an existing employee record+
The users should be able to update an existing employee record, one at a single time.
+Delete existing employee records+
The users should be able to delete single or multiple employees at a time while viewing employee records in list style.

*Architectural Overview*

* Simple 3 layer architecture (user interface, business and data access layer) with 1 optional cache layer
* ASP.NET Web Form based user interface
* Custom Entity Data Container implemented
* Data Mapper Design Pattern based Data Access Layer, implemented in C# and Entity Framework
* Domain Model Design Pattern based Business Logic Layer, implemented in C#
* Sql Server Stored Procedure to perform actual CRUD operation
* Standard infrastructure (architecture, helper utility) for automated integration (bottom up manner) and unit testing

*Technology Utilized*

+Programming Languages/Scripts+
* Browser side: JavaScript
* Web server side: C#
* Database server side: T-SQL

+.NET Framework Components+

* .NET Entity Framework
* .NET Optional/Named Parameters
* .NET Tuple
* .NET Extension Method
* .NET Lambda Expressions 
* .NET Aanonymous Type
* .NET Query Expressions
* .NET Automatically Implemented Properties
* .NET LINQ
* .NET  Partial Classes
* .NET Generic Type
* .NET Nullable Type
* ASP.NET Meta Description and Keyword Support
* ASP.NET Routing
* ASP.NET Grid View (CSS support for sorting)
* ASP.NET List View
* ASP.NET Data Pager
* ASP.NET  Form View
* ASP.NET Skin
* ASP.NET Theme
* ASP.NET Master Page
* ASP.NET Object Data Source
* ASP.NET 1.0+ Role Based Security

+Visual Studio Features+

* Visual Studio CodedUI Test
* Visual Studio Layer Diagram 
* Visual Studio Sequence Diagram 
* Visual Studio Directed Graph 
* Visual Studio+ Database Unit Test
* Visual Studio+ Unit Test
* Visual Studio+ Web Test
* Visual Studio+ Load Test

+Sql Server Features+

* Sql Server Stored Procedure
* Sql Server Xml type
* Sql Server Paging support

==============================================================================