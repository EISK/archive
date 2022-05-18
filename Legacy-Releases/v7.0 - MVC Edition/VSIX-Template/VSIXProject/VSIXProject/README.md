Explore cool new features as available in Visual Studio, ASP.NET MVC & Entity Framework with best coding practices based on a simple database entity “Employee”.

**Key Technology Areas**
* C# 
* .NET Framework 4.5
* ASP.NET MVC 5.0
* Entity Framework 6.0
* Sql Server Localdb
* Visual Studio 2013 - 2022

**Architectural Overview**
* Overall architecture is based on <a href="http://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93controller" target="_blank">Model-View-Controller (MVC) design pattern</a> 
* Support for desktop &amp; mobile browsers. 
* Usage of Data Annotations in <em>Model (Entity) classes</em> to centralize basic validation mechanism that facilitates DRY principle 
* Usage of IValidatableObject interface in <em>Model (Entity) classes</em> that isolates custom <em>Business Logic</em> from application layer 
* Usage of OOP inheritance and Value <a href="http://weblogs.asp.net/ashraful/archive/2012/02/19/design-patterns-for-model.aspx">Object design pattern</a> in <a href="http://weblogs.asp.net/ashraful/archive/2012/02/19/design-patterns-for-model.aspx">Model (Entity)</a> classes that provides reusability in application architecture 
* Usage of <a href="http://weblogs.asp.net/ashraful/archive/2012/02/19/design-patterns-for-model.aspx">View Model, Editor Model design pattern</a> that provides mechanism for testable view rendering logic 
* Usage of <a href="http://martinfowler.com/eaaCatalog/domainModel.html" target="_blank">Domain Model</a>, <a href="http://martinfowler.com/eaaCatalog/repository.html" target="_blank">Repository</a> and <a href="http://martinfowler.com/eaaCatalog/unitOfWork.html" target="_blank">Unit of Work</a> design <em>pattern</em> from <a href="http://en.wikipedia.org/wiki/Domain-driven_design" target="_blank">Domain-driven Design (DDD)</a> approach 
* Usage of <a href="http://martinfowler.com/eaaCatalog/dataMapper.html" target="_blank">Data Mapper design pattern</a> for <em>Data Access Layer</em> using Entity Framework &ndash; <em>Code First Approach</em> 
* Several reusable helper classes and extension methods for <em>Cross Cutting Concerns</em> (i.e. logging etc)&nbsp; and other repetitive functionalities. 

**Sample Use Case**
* Creating a new employee record
* Read existing employee records
* Update an existing employee record
* Delete existing employee records
* Role based security model


**Getting Started**
* Download and install latest EISK MVC from [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=AshrafulAlam.EmployeeInfoStarterKitEISK-MVC).
* Once installed enjoy creating EISK projects by going File –> New Project –> Installed –> Templates –> Visual C# –> Web –> Eisk.MVC. Select a location.
* Once the project is loaded in the visual studio, hit F5 to start the project.

Checkout EISK's [GitHub]( https://github.com/eisk) url for more frequent updates.

**New EISK Visual Studio 2022 Extension Available!**

Been an EISK fan? Good news! New [EISK Visual Studio 2022 Extension](https://marketplace.visualstudio.com/items?itemName=AshrafulAlam.Eisk&ssr=false#overview) to enable you building high scale RESTful API using .NET 6.0 and Visual Studio 2022!

