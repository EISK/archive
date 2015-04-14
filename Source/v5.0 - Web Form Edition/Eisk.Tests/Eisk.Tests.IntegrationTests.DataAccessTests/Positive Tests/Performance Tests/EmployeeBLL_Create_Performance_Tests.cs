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
using System.Diagnostics;
using Eisk.BusinessLogicLayer;
using Eisk.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eisk.Tests.IntegrationTests.DataAccessTests.PositiveTests
{
    [TestClass]
    public class EmployeeBLL_Create_Performance_Tests : DataAccessLayerBaseTest
    {
        [TestMethod]
        public void CreateNewEmployee_1NewEmployeesCreated_ShouldBeExecutedInLessThan1Sec()
        {
            //---------------------------------- ARRANGE -------------------------------------
            
            //expected loading time is 1 second
            TimeSpan EXPECTED_EXECUTION_DURATION = TimeSpan.FromSeconds(1);
            
            Stopwatch stopwatch = new Stopwatch();

            //string the stopwatch
            stopwatch.Start();

            //---------------------------------- ACT -------------------------------------

            //test method goes here
            EmployeeBLL.CreateNewEmployee(TestDataFactory.CreateNewObjectWithValidNewEmployeeData());

            //---------------------------------- ASSERT -------------------------------------

            //stopping the stopwatch
            stopwatch.Stop();

            TimeSpan ACTUAL_EXECUTION_DURATION = stopwatch.Elapsed;
            
            Console.WriteLine("Method executed in toal seconds : " + ACTUAL_EXECUTION_DURATION.TotalSeconds);

             Assert.IsTrue(stopwatch.Elapsed < EXPECTED_EXECUTION_DURATION,
                string.Format(System.Globalization.CultureInfo.CurrentCulture, 
                "Loading time ({0:#,##0.0} seconds) exceed the expected time ({1:#,##0.0} seconds).",
                ACTUAL_EXECUTION_DURATION.TotalSeconds, EXPECTED_EXECUTION_DURATION.TotalSeconds));

        }

        [TestMethod]
        public void CreateNewEmployee_100NewEmployeesCreated_ShouldBeExecutedInLessThan5Sec()
        {
            //---------------------------------- ARRANGE -------------------------------------

            //expected loading time is 5 seconds
            TimeSpan EXPECTED_EXECUTION_DURATION = TimeSpan.FromSeconds(5);

            Stopwatch stopwatch = new Stopwatch();

            //string the stopwatch
            stopwatch.Start();

            //---------------------------------- ACT -------------------------------------

            //test method goes here
            for (int i = 0; i< 100; i++)
                EmployeeBLL.CreateNewEmployee(TestDataFactory.CreateNewObjectWithValidNewEmployeeData());

            //---------------------------------- ASSERT -------------------------------------

            //stopping the stopwatch
            stopwatch.Stop();

            TimeSpan ACTUAL_EXECUTION_DURATION = stopwatch.Elapsed;

            Console.WriteLine("Method executed in toal seconds : " + ACTUAL_EXECUTION_DURATION.TotalSeconds);

            Assert.IsTrue(stopwatch.Elapsed < EXPECTED_EXECUTION_DURATION,
               string.Format(System.Globalization.CultureInfo.CurrentCulture,
               "Loading time ({0:#,##0.0} seconds) exceed the expected time ({1:#,##0.0} seconds).",
               ACTUAL_EXECUTION_DURATION.TotalSeconds, EXPECTED_EXECUTION_DURATION.TotalSeconds));

        }

        [TestMethod]
        public void CreateNewEmployee_1000NewEmployeesCreated_ShouldBeExecutedInLessThan10Sec()
        {
            //---------------------------------- ARRANGE -------------------------------------

            //expected loading time is 10 seconds
            TimeSpan EXPECTED_EXECUTION_DURATION = TimeSpan.FromSeconds(10);

            Stopwatch stopwatch = new Stopwatch();

            //string the stopwatch
            stopwatch.Start();

            //---------------------------------- ACT -------------------------------------

            //test method goes here
            for (int i = 0; i < 1000; i++)
                EmployeeBLL.CreateNewEmployee(TestDataFactory.CreateNewObjectWithValidNewEmployeeData());

            //---------------------------------- ASSERT -------------------------------------

            //stopping the stopwatch
            stopwatch.Stop();

            TimeSpan ACTUAL_EXECUTION_DURATION = stopwatch.Elapsed;

            Console.WriteLine("Method executed in toal seconds : " + ACTUAL_EXECUTION_DURATION.TotalSeconds);

            Assert.IsTrue(stopwatch.Elapsed < EXPECTED_EXECUTION_DURATION,
               string.Format(System.Globalization.CultureInfo.CurrentCulture,
               "Loading time ({0:#,##0.0} seconds) exceed the expected time ({1:#,##0.0} seconds).",
               ACTUAL_EXECUTION_DURATION.TotalSeconds, EXPECTED_EXECUTION_DURATION.TotalSeconds));

        }

        [TestMethod]
        public void CreateNewEmployee_10000NewEmployeesCreated_ShouldBeExecutedInLessThan50Sec()
        {
            //---------------------------------- ARRANGE -------------------------------------

            //expected loading time is 50 seconds
            TimeSpan EXPECTED_EXECUTION_DURATION = TimeSpan.FromSeconds(50);

            Stopwatch stopwatch = new Stopwatch();

            //string the stopwatch
            stopwatch.Start();

            //---------------------------------- ACT -------------------------------------

            //test method goes here
            for (int i = 0; i < 10000; i++)
                EmployeeBLL.CreateNewEmployee(TestDataFactory.CreateNewObjectWithValidNewEmployeeData());

            //---------------------------------- ASSERT -------------------------------------

            //stopping the stopwatch
            stopwatch.Stop();

            TimeSpan ACTUAL_EXECUTION_DURATION = stopwatch.Elapsed;

            Console.WriteLine("Method executed in toal seconds : " + ACTUAL_EXECUTION_DURATION.TotalSeconds);

            Assert.IsTrue(stopwatch.Elapsed < EXPECTED_EXECUTION_DURATION,
               string.Format(System.Globalization.CultureInfo.CurrentCulture,
               "Loading time ({0:#,##0.0} seconds) exceed the expected time ({1:#,##0.0} seconds).",
               ACTUAL_EXECUTION_DURATION.TotalSeconds, EXPECTED_EXECUTION_DURATION.TotalSeconds));

        }
    }
}
