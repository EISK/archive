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

using Eisk.DataAccessLayer;

namespace Eisk.TestHelpers
{

    /// <summary>
    /// Design and Architecture: Mohammad Ashraful Alam [http://www.ashraful.net]
    /// </summary>
    public sealed class TestDataHelper
    {
        TestDataHelper(){}

        static string srciptRoot = @"..\..\..\..\Eisk.Web\App_Data\SQL\";

        public static void CreateDatabaseIfDoesNotExist()
        {
            using (DatabaseContext _DatabaseContext = new DatabaseContext())
            {
                if (!_DatabaseContext.DatabaseExists())
                    _DatabaseContext.CreateDatabase();
            }
        }

        public static void DeleteDatabaseIfExists()
        {
            using (DatabaseContext _DatabaseContext = new DatabaseContext())
            {
                if (_DatabaseContext.DatabaseExists())
                    _DatabaseContext.DeleteDatabase();
            }
        }

        public static void CreateSchema()
        {
            SqlScriptRunner.RunScript(srciptRoot + "Schema\\Create-Schema.sql");
        }

        public static void CleanSchema()
        {
            SqlScriptRunner.RunScript(srciptRoot + "Schema\\Clean-Schema.sql");
        }

        public static void GenerateTestData()
        {
            SqlScriptRunner.RunScript(srciptRoot + "Data\\Create-Data.sql");
        }

        public static void CleanTestData()
        {
            SqlScriptRunner.RunScript(srciptRoot + "Data\\Clean-Data.sql");
        }

    }

}