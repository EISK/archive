using System.Web.Mvc;
using Eisk.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eisk.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
