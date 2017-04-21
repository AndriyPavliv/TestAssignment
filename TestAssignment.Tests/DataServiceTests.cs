using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TestAssignment.Infrastructure.EF;
using TestAssignment.Services;

namespace TestAssignment.Tests
{
    [TestFixture]
    public class DataServiceTests
    {
        [Test]
        public void DataService_LoadEmployeeSales_Test()
        {
            //Arrange
            var dataSvcMock = new Mock<IDataService>();
            
            var employeeSales = new List<EmployeeSales>
            {
                new EmployeeSales
                {
                    EmployeeID = 1
                }
            };

            dataSvcMock.Setup(t => t.LoadEmployeeSales(1, 5, string.Empty))
                                  .Returns(employeeSales);

            //Act
            var actual = dataSvcMock.Object.LoadEmployeeSales(1, 5, string.Empty);            

            //Assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Count == 1);
            dataSvcMock.Verify(t => t.LoadEmployeeSales(1, 5, string.Empty), Times.Once());
        }        
    }
}
