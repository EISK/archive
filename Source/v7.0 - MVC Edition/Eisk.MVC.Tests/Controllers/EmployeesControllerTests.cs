using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Eisk.BusinessRules;
using Eisk.Controllers;
using Eisk.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Eisk.Tests
{
    [TestClass]
    public class EmployeesControllerTest : IntegrationTestBase
    {
        [TestMethod]
        public void Edit_Positive_Get_Test()
        {
            // Arrange
            var controller = DependencyHelper.GetInstance<EmployeesController>();

            // Act
            var viewResult = controller.Edit(1) as ViewResult;

            // Assert
            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [TestMethod]
        public void Edit_Positive_Post_Test()
        {
            //Arrange
            var controller = DependencyHelper.GetInstance<EmployeesController>();

            var employee = TestDataHelper.CreateEmployeeWithValidData(1);

            controller.FireValidationForModel(employee);

            //Act
            var result = controller.Edit(employee);

            //Assert
            Assert.IsTrue(controller.ModelState.IsValid);

        }

        [TestMethod]
        public void Edit_Negative_Test_Post_Test()
        {
            //Arrange
            var controller = DependencyHelper.GetInstance<EmployeesController>();
            var employee = TestDataHelper.CreateEmployeeWithValidData(1);
            employee.Address.AddressLine = "2, ABC Road";
            controller.FireValidationForModel(employee);
            //Act
            controller.Edit(employee);

            //Assert
            Assert.IsTrue(EmployeeAddressMustBeUnique.IsErrorAvalilableIn(controller, employee));
        }

        [TestMethod]
        public void Edit_Test()
        {
            //Arrange
            var controller = DependencyHelper.GetInstance<EmployeesController>();

            var employee = TestDataHelper.CreateEmployeeWithValidData(1);

            employee.Address.AddressLine = string.Empty;

            controller.FireValidationForModel(employee.Address);

            //Act
            var result = controller.Edit(employee);

            //Assert
            Assert.IsFalse(controller.ModelState.IsValid);

        }

    }
}
