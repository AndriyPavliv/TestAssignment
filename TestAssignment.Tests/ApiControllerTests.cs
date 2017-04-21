using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TestAssignment.Controllers.API;
using TestAssignment.Infrastructure.EF;
using TestAssignment.Models.EmployeeSales;
using TestAssignment.Services;

namespace TestAssignment.Tests
{
    [TestFixture]
    public class ApiControllerTests
    {
        [Test]
        public void HomeController_Search_Method_Test()
        {
            //Arrange
            var dataSvcMock = new Mock<IDataService>();
            var filter = Mock.Of<EmployeeSalesFilterModel>(f =>
                        f.Name == string.Empty && 
                        f.PageIdx == 1 && 
                        f.PageSize == 5);

            var employeeSales = new List<EmployeeSales>
            {
                new EmployeeSales
                {
                    EmployeeID = 1
                }
            };

            dataSvcMock.Setup(t => t.LoadEmployeeSales(1,5, string.Empty))
                                  .Returns(employeeSales);           

            var homeController = new HomeController(dataSvcMock.Object);

            //Act

            var employeeSalesModel = homeController.Search(filter);

            //Assert
            Assert.That(employeeSalesModel, Is.Not.Null);
            dataSvcMock.Verify(t => t.LoadEmployeeSales(1,5, string.Empty), Times.Once());
        }
    }
}
