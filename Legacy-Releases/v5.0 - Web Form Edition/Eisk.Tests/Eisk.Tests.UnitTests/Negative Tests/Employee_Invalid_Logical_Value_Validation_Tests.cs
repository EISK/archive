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


using Eisk.BusinessEntities;
using Eisk.Helpers;
using Eisk.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Eisk.Tests.UnitTests.NegativeTests
{
    [TestClass]
    public class Employee_Invalid_Logical_Value_Validation_Tests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidDataKeyException), "Method didnt thow exception for invalid EmployeeId as expected.")]
        public void EmployeeId_InvalidEmployeeIdAssigned_ShouldThrowException()
        {
            // ARRANGE
            Employee employee = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            const int INVALID_KEY_VALUE = -1;

            // ACT
            employee.EmployeeId = INVALID_KEY_VALUE;
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleViolationOnInMemoryException), "Method didnt thow exception as expected.")]
        public void BirthDate_BirthDateLaterThanHireDateAssigned_ShouldThrowException()
        {
            // ARRANGE
            Employee employee = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            DateTime VALID_HIRE_DATE_VALUE = DateTime.Now;
            DateTime INVALID_BIRTHDATE_VALUE_AS_LATER_THAN_HIRE_DATE = VALID_HIRE_DATE_VALUE.AddDays(1);
            employee.HireDate = VALID_HIRE_DATE_VALUE;
 
            // ACT
            employee.BirthDate = INVALID_BIRTHDATE_VALUE_AS_LATER_THAN_HIRE_DATE;

        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleViolationOnInMemoryException), "Method didnt thow exception as expected.")]
        public void HireDate_HireDateEarlierThanBirthDateAssigned_ShouldThrowException()
        {
            // ARRANGE
            Employee employee = TestDataFactory.CreateNewObjectWithValidNewEmployeeData();
            DateTime VALID_BIRTHDATE_VALUE = DateTime.Now;
            DateTime INVALID_HIREDATE_VALUE_AS_EARLIER_THAN_BIRTHDATE = VALID_BIRTHDATE_VALUE.Subtract(new TimeSpan(1));
            employee.BirthDate = VALID_BIRTHDATE_VALUE;

            // ACT
            employee.HireDate = INVALID_HIREDATE_VALUE_AS_EARLIER_THAN_BIRTHDATE;

        }
    }
}
