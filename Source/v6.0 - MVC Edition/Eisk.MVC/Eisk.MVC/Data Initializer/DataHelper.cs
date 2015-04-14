/****************** Copyright Notice *****************
 
This code is licensed under Microsoft Public License (Ms-PL). 
You are free to use, modify and distribute any portion of this code. 
The only requirement to do that, you need to keep the developer name, as provided below to recognize and encourage original work:

=======================================================
   
Architecture Designed and Implemented By:
Mohammad Ashraful Alam
Microsoft Most Valuable Professional, ASP.NET 2007 – 2013
Twitter: http://twitter.com/AshrafulAlam | Blog: http://blog.ashraful.net | Portfolio: http://www.ashraful.net
   
*******************************************************/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Xml.Linq;
using Eisk.DataAccess;
using Eisk.Helpers;
using Eisk.Models;

namespace Eisk
{
    public static class TestDataHelper
    {
        public static Employee CreateEmployeeWithValidData(int id = 0)
        {
            return new Employee
            {
                Id = id,
                LastName = "Alam",
                FirstName = "Ashraful",
                Title = "Chief Architect",
                TitleOfCourtesy = "Mr.",
                BirthDate = new DateTime(1983, 1, 23),
                HireDate = new DateTime(2007, 5, 16),
                Address = new Address
                {
                    AddressLine = "103 Banani",
                    City = "Dhaka",
                    Region = "N/A",
                    PostalCode = "1207",
                    Country = "USA"
                },
                Phone = "3901-2420-9334",
                Extension = "123",
                Photo = null,
                Notes = "Coding geek.",
                ReportsTo = null

            };
        }

        public static void InitializeSchemaAndData(string filePath)
        {
            Database.Delete("DatabaseContext");
            var initializer = new DatabaseContextInitializer(filePath);
            Database.SetInitializer(initializer);
            initializer.InitializeDatabase(DependencyHelper.GetInstance<DatabaseContext>());
        }

        public static List<Employee> GetEmployeeDataFromXml(string filePath)
        {
            XDocument xDoc = XDocument.Load(filePath);
            return (from xElement in xDoc.Descendants("Employees")
                    select new Employee
                    {
                        //Id = int.Parse(e.Element("Id").Value),
                        LastName = xElement.GetStringValue("LastName"),
                        FirstName = xElement.GetStringValue("FirstName"),
                        Title = xElement.GetStringValue("Title"),
                        TitleOfCourtesy = xElement.GetStringValue("TitleOfCourtesy"),
                        BirthDate = xElement.GetDateTimeValue("BirthDate"),
                        HireDate = (DateTime)xElement.GetDateTimeValue("HireDate"),
                        Address = new Address
                        {
                            AddressLine = xElement.GetStringValue("Address"),
                            City = xElement.GetStringValue("City"),
                            Region = xElement.GetStringValue("Region"),
                            PostalCode = xElement.GetStringValue("PostalCode"),
                            Country = xElement.GetStringValue("Country"),
                        },
                        Phone = xElement.GetStringValue("Phone"),
                        Extension = xElement.GetStringValue("Extension"),
                        Photo = xElement.GetByteArrayValue("Photo"),
                        Notes = xElement.GetStringValue("Notes"),
                        ReportsTo = xElement.GetIntValue("ReportsTo")
                    }).ToList();
        }
    }
}

