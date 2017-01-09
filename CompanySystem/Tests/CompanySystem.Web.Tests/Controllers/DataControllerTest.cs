namespace CompanySystem.Web.Tests.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using CompanySystem.Data;
    using CompanySystem.Models;
    using CompanySystem.Web.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Telerik.JustMock;

    [TestClass]
    public class DataControllerTest
    {
        [TestMethod]
        public void GetShouldNotReturnNull()
        {
            // Arrange
            var mockedData = Mock.Create<ICompanySystemData>();
            var controller = new DataController(mockedData);

            // Act
            var jsonResult = controller.Get();

            // Assert
            Assert.IsNotNull(jsonResult);
        }

        [TestMethod]
        public void GetShouldReturnCorrectType()
        {
            // Arrange
            var mockedData = Mock.Create<ICompanySystemData>();
            var controller = new DataController(mockedData);

            // Act
            var jsonResult = controller.Get();

            // Assert
            Assert.AreEqual(typeof(JsonResult), jsonResult.GetType());
        }

        [TestMethod]
        public void GetShouldReturnCorrectData()
        {
            // Arrange
            var mockedData = Mock.Create<ICompanySystemData>();
            var fakeEmployees = GenerateEmployees(5);

            Mock.Arrange(() => mockedData.Employees.All())
                .Returns(() => fakeEmployees.AsQueryable());

            var controller = new DataController(mockedData);

            // Act
            var jsonResult = controller.Get();
            List<Employee> resultData = jsonResult.Data as List<Employee>;

            // Assert
            Assert.IsTrue(resultData.SequenceEqual(fakeEmployees));
        }

        private List<Employee> GenerateEmployees(int employeesCount)
        {
            var employees = new List<Employee>();

            for (int i = 0; i <= employeesCount; i++)
            {
                employees.Add(
                    new Employee
                    {
                        Id = i,
                        FirstName = "FirstName" + i,
                        LastName = "LastName" + i,
                        Age = i + 20,
                        Email = "Email" + i,
                    });
            }

            return employees;
        }
    }
}
