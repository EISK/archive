using System.Collections.Generic;
using System.Data.Entity;
using Eisk.DataAccess;
using Eisk.Models;

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
namespace Eisk
{
    public class DatabaseContextInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        string _testDataFilePath;
        public DatabaseContextInitializer(string testDataFilePath)
        {
            _testDataFilePath = testDataFilePath;
        }

        protected override void Seed(DatabaseContext context)
        {
            List<Employee> employees = TestDataHelper.GetEmployeeDataFromXml(_testDataFilePath);
            employees.ForEach(d => context.EmployeeRepository.Add(d));
        }
    }
}