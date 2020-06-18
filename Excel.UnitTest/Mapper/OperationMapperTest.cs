using Excel.Application.Mapping;
using Excel.Infrastructure.Extensions;
using Excel.UnitTest.FakeObject;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Excel.UnitTest.Mapper
{
    [TestClass]
    public class OperationMapperTest
    {
        [TestMethod]
        public void ShouldMapOperationToGetOperationsResultSucessAndBeEquivalent()
        {
            //Arrange  
            var operations = FakeOperation.CreateOperationsSuccess();

            //Act
            var result = operations.MapToResult();

            //Assert
            result.Should().BeEquivalentTo(operations, options => options.ExcludingMissingMembers().Excluding(c => c.Type));

            var mappedType = operations.Select(a => a.Type.GetDescription());
            result.All(c => mappedType.Contains(c.Type)).Should().BeTrue();

        }
    }
}
