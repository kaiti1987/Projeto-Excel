using Excel.UnitTest.FakeObject;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Excel.UnitTest.Domain
{
    [TestClass]
    public class OperationTest
    {
        
        [TestMethod]
        public void ShouldCalculatAveragePriceWithSuccess()
        {
            //Arrange            
            var operation = FakeOperation.CreateSuccess();

            //Act
            var result = operation.AvgPrice();

            //Assert
            result.Should().Be((operation.Quantity * operation.Price) / operation.Quantity);            
        }
    }
}
