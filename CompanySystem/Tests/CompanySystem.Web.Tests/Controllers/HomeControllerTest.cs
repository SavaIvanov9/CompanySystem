namespace CompanySystem.Web.Tests.Controllers
{
    using System.Web.Mvc;
    using CompanySystem.Data;
    using CompanySystem.Web.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexViewResultShouldNotBeNull()
        {
            // Arrange
            var mockedData = new Mock<ICompanySystemData>();
            HomeController controller = new HomeController(mockedData.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
