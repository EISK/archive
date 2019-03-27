/****************** Copyright Notice *****************
 
This code is licensed under Microsoft Public License (Ms-PL). 
You are free to use, modify and distribute any portion of this code. 
The only requirement to do that, you need to keep the developer name, as provided below to recognize and encourage original work:

=======================================================
   
Architecture Designed and Implemented By:
Mohammad Ashraful Alam
Microsoft Most Valuable Professional, ASP.NET 2007 – 2011
Twitter: http://twitter.com/AshrafulAlam | Blog: http://blog.ashraful.net | Portfolio: http://www.ashraful.net
   
*******************************************************/

using System;
using Eisk.BusinessEntities;

namespace Eisk.TestHelpers
{
    public sealed class TestDataFactory
    {
        public static Employee CreateNewObjectWithValidNewEmployeeData()
        {

            Employee employee = new Employee
            {

                EmployeeId = 0,
                LastName = "Alam",
                FirstName = "Ashraful",
                Title = "Mr.",
                TitleOfCourtesy = "MVP",
                BirthDate = new DateTime(1983, 1, 23),
                HireDate = new DateTime(2007, 5, 16),
                Address = "103 Banani",
                City = "Dhaka",
                Region = "N/A",
                PostalCode = "1207",
                Country = "Bangladesh",
                HomePhone = "3901-2420-9334",
                Extension = "123",
                Photo = new byte[1] { 0 },
                Notes = "Nice person.",
                ReportsTo = null

            };

            return employee;
        }

        public static Employee CreateNewObjectWithValidExistingEmployeeData()
        {
            Employee employee = CreateNewObjectWithValidNewEmployeeData();
            employee.EmployeeId = 1;
            return employee;
        }
    }

}