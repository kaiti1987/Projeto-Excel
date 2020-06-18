using Excel.Application.Application.Implements;
using Excel.Application.Mapping.Param;
using Excel.Application.Strategy.Contracts;
using Excel.Domain;
using Excel.Domain.Contracts;
using Excel.Infrastructure.Extensions;
using Excel.Infrastructure.Service.Interface;
using Excel.UnitTest.FakeObject;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;

namespace Excel.UnitTest.Application
{
    [TestClass]
    public class OperationAppServiceTest
    {
        private OperationAppService _operationAppService;
        private IOperationRepository _operationRepository;
        private IOperationInfrastructureService _operationInfrastructureService;
        private IFileStrategyHandler _fileStrategyHandler;
        private IOperationStrategyHandler _operationStrategyHandler;

        private const int One = 1;

        [TestInitialize]
        public void TestInitialize()
        {
            _operationRepository = Substitute.For<IOperationRepository>();
            _operationInfrastructureService = Substitute.For<IOperationInfrastructureService>();
            _fileStrategyHandler = Substitute.For<IFileStrategyHandler>();
            _operationStrategyHandler = Substitute.For<IOperationStrategyHandler>();

            _operationAppService = new OperationAppService(_operationRepository,
                                                           _operationInfrastructureService,
                                                           _fileStrategyHandler,
                                                           _operationStrategyHandler);
        }

        [TestMethod]
        public void ShouldSucessWhenGenerateData()
        {
            //Arrange  
            var operations = FakeOperation.CreateOperationsSuccess();
            _operationRepository.GetOperation().Returns(operations);

            //Act
            _operationAppService.GenerateData().GetAwaiter().GetResult();

            //Assert
            _operationRepository.Received(One).GetOperation();

            var condition = Arg.Is<IEnumerable<Operation>>(a => a.Equals(operations));
            _operationInfrastructureService.Received(One).GenerateFile(condition);            
        }

        [TestMethod]
        public void ShouldSucessWhenGetOperationsWithDisplayTypeAll()
        {
            //Arrange  
            var param = new GetOperationsParam {DisplayType = Excel.Application.Enums.DisplayType.All };

            var operations = FakeOperation.CreateOperationsSuccess();
             _operationRepository.GetAll().Returns(operations);            

            //Act
            var result = _operationAppService.GetOperations(param).GetAwaiter().GetResult();

            //Assert
            _operationRepository.Received(One).GetAll();

            _operationStrategyHandler.DidNotReceiveWithAnyArgs().GetGroupOperations(param.DisplayType, operations);            

            result.Should().BeEquivalentTo(operations, options => options.ExcludingMissingMembers().Excluding(c => c.Type));

            var mappedType = operations.Select(a => a.Type.GetDescription());
            result.All(c => mappedType.Contains(c.Type)).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldSucessWhenGetOperationsWithDisplayTypeGroupByAccount()
        {
            //Arrange  
            var param = new GetOperationsParam { DisplayType = Excel.Application.Enums.DisplayType.GroupByAccount };

            var operations = FakeOperation.CreateOperationsSuccess();
            _operationRepository.GetAll().Returns(operations);
            _operationStrategyHandler.GetGroupOperations(param.DisplayType, operations).Returns(operations);

            //Act
            var result = _operationAppService.GetOperations(param).GetAwaiter().GetResult();

            //Assert
            _operationRepository.Received(One).GetAll();

            var condition = Arg.Is<IEnumerable<Operation>>(a => a.Equals(operations));
            _operationStrategyHandler.Received(One).GetGroupOperations(param.DisplayType, condition);

            result.Should().BeEquivalentTo(operations, options => options.ExcludingMissingMembers().Excluding(c => c.Type));

            var mappedType = operations.Select(a => a.Type.GetDescription());
            result.All(c => mappedType.Contains(c.Type)).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldSucessWhenGetOperationsWithDisplayTypeGroupByAsset()
        {
            //Arrange  
            var param = new GetOperationsParam { DisplayType = Excel.Application.Enums.DisplayType.GroupByAsset };

            var operations = FakeOperation.CreateOperationsSuccess();
            _operationRepository.GetAll().Returns(operations);
            _operationStrategyHandler.GetGroupOperations(param.DisplayType, operations).Returns(operations);

            //Act
            var result = _operationAppService.GetOperations(param).GetAwaiter().GetResult();

            //Assert
            _operationRepository.Received(One).GetAll();

            var condition = Arg.Is<IEnumerable<Operation>>(a => a.Equals(operations));
            _operationStrategyHandler.Received(One).GetGroupOperations(param.DisplayType, condition);

            result.Should().BeEquivalentTo(operations, options => options.ExcludingMissingMembers().Excluding(c => c.Type));

            var mappedType = operations.Select(a => a.Type.GetDescription());
            result.All(c => mappedType.Contains(c.Type)).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldSucessWhenGetOperationsWithDisplayTypeGroupByType()
        {
            //Arrange  
            var param = new GetOperationsParam { DisplayType = Excel.Application.Enums.DisplayType.GroupByType };

            var operations = FakeOperation.CreateOperationsSuccess();
            _operationRepository.GetAll().Returns(operations);
            _operationStrategyHandler.GetGroupOperations(param.DisplayType, operations).Returns(operations);

            //Act
            var result = _operationAppService.GetOperations(param).GetAwaiter().GetResult();

            //Assert
            _operationRepository.Received(One).GetAll();

            var condition = Arg.Is<IEnumerable<Operation>>(a => a.Equals(operations));
            _operationStrategyHandler.Received(One).GetGroupOperations(param.DisplayType, condition);

            result.Should().BeEquivalentTo(operations, options => options.ExcludingMissingMembers().Excluding(c => c.Type));

            var mappedType = operations.Select(a => a.Type.GetDescription());
            result.All(c => mappedType.Contains(c.Type)).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldSucessWhenCreateFileWithDisplayTypeAllAndFileTypeCsv()
        {
            //Arrange  
            var param = new CreateFileParam { DisplayType = Excel.Application.Enums.DisplayType.All,  FileType = Excel.Application.Enums.FileType.Csv};

            var operations = FakeOperation.CreateOperationsSuccess();
            _operationRepository.GetAll().Returns(operations);

            //Act
            _operationAppService.CreateFile(param).GetAwaiter().GetResult();

            //Assert
            _operationRepository.Received(One).GetAll();

            _operationStrategyHandler.DidNotReceiveWithAnyArgs().GetGroupOperations(param.DisplayType, operations);

            var condition = Arg.Is<IEnumerable<Operation>>(a => a.Equals(operations));
            _fileStrategyHandler.Received(One).CreateFile(param.FileType, param.DisplayType, condition);
        }

        [TestMethod]
        public void ShouldSucessWhenCreateFileWithDisplayTypeAllAndFileTypeExcel()
        {
            //Arrange  
            var param = new CreateFileParam { DisplayType = Excel.Application.Enums.DisplayType.All, FileType = Excel.Application.Enums.FileType.Excel };

            var operations = FakeOperation.CreateOperationsSuccess();
            _operationRepository.GetAll().Returns(operations);

            //Act
            _operationAppService.CreateFile(param).GetAwaiter().GetResult();

            //Assert
            _operationRepository.Received(One).GetAll();

            _operationStrategyHandler.DidNotReceiveWithAnyArgs().GetGroupOperations(param.DisplayType, operations);

            var condition = Arg.Is<IEnumerable<Operation>>(a => a.Equals(operations));
            _fileStrategyHandler.Received(One).CreateFile(param.FileType, param.DisplayType, condition);
        }

        [TestMethod]
        public void ShouldSucessWhenCreateFileWithDisplayTypeGroupByAccountAndFileTypeCsv()
        {
            //Arrange  
            var param = new CreateFileParam { DisplayType = Excel.Application.Enums.DisplayType.GroupByAccount, FileType = Excel.Application.Enums.FileType.Csv };

            var operations = FakeOperation.CreateOperationsSuccess();
            _operationRepository.GetAll().Returns(operations);

            _operationStrategyHandler.GetGroupOperations(param.DisplayType, operations).Returns(operations);

            //Act
            _operationAppService.CreateFile(param).GetAwaiter().GetResult();

            //Assert
            _operationRepository.Received(One).GetAll();

            var condition = Arg.Is<IEnumerable<Operation>>(a => a.Equals(operations));
            _operationStrategyHandler.Received(One).GetGroupOperations(param.DisplayType, condition);
            var conditionFile = Arg.Is<IEnumerable<Operation>>(a => a.Equals(operations));
            _fileStrategyHandler.Received(One).CreateFile(param.FileType, param.DisplayType, conditionFile);
        }

        [TestMethod]
        public void ShouldSucessWhenCreateFileWithDisplayTypeGroupByAccountAndFileTypeExcel()
        {
            //Arrange  
            var param = new CreateFileParam { DisplayType = Excel.Application.Enums.DisplayType.GroupByAccount, FileType = Excel.Application.Enums.FileType.Excel };

            var operations = FakeOperation.CreateOperationsSuccess();
            _operationRepository.GetAll().Returns(operations);

            _operationStrategyHandler.GetGroupOperations(param.DisplayType, operations).Returns(operations);

            //Act
            _operationAppService.CreateFile(param).GetAwaiter().GetResult();

            //Assert
            _operationRepository.Received(One).GetAll();

            var condition = Arg.Is<IEnumerable<Operation>>(a => a.Equals(operations));
            _operationStrategyHandler.Received(One).GetGroupOperations(param.DisplayType, condition);
            var conditionFile = Arg.Is<IEnumerable<Operation>>(a => a.Equals(operations));
            _fileStrategyHandler.Received(One).CreateFile(param.FileType, param.DisplayType, conditionFile);
        }

        [TestMethod]
        public void ShouldSucessWhenCreateFileWithDisplayTypeGroupByTypeAndFileTypeCsv()
        {
            //Arrange  
            var param = new CreateFileParam { DisplayType = Excel.Application.Enums.DisplayType.GroupByType, FileType = Excel.Application.Enums.FileType.Csv };

            var operations = FakeOperation.CreateOperationsSuccess();
            _operationRepository.GetAll().Returns(operations);

            _operationStrategyHandler.GetGroupOperations(param.DisplayType, operations).Returns(operations);

            //Act
            _operationAppService.CreateFile(param).GetAwaiter().GetResult();

            //Assert
            _operationRepository.Received(One).GetAll();

            var condition = Arg.Is<IEnumerable<Operation>>(a => a.Equals(operations));
            _operationStrategyHandler.Received(One).GetGroupOperations(param.DisplayType, condition);
            var conditionFile = Arg.Is<IEnumerable<Operation>>(a => a.Equals(operations));
            _fileStrategyHandler.Received(One).CreateFile(param.FileType, param.DisplayType, conditionFile);
        }

        [TestMethod]
        public void ShouldSucessWhenCreateFileWithDisplayTypeGroupByTypeAndFileTypeExcel()
        {
            //Arrange  
            var param = new CreateFileParam { DisplayType = Excel.Application.Enums.DisplayType.GroupByType, FileType = Excel.Application.Enums.FileType.Excel };

            var operations = FakeOperation.CreateOperationsSuccess();
            _operationRepository.GetAll().Returns(operations);

            _operationStrategyHandler.GetGroupOperations(param.DisplayType, operations).Returns(operations);

            //Act
            _operationAppService.CreateFile(param).GetAwaiter().GetResult();

            //Assert
            _operationRepository.Received(One).GetAll();

            var condition = Arg.Is<IEnumerable<Operation>>(a => a.Equals(operations));
            _operationStrategyHandler.Received(One).GetGroupOperations(param.DisplayType, condition);
            var conditionFile = Arg.Is<IEnumerable<Operation>>(a => a.Equals(operations));
            _fileStrategyHandler.Received(One).CreateFile(param.FileType, param.DisplayType, conditionFile);
        }

        [TestMethod]
        public void ShouldSucessWhenCreateFileWithDisplayTypeGroupByAssetAndFileTypeCsv()
        {
            //Arrange  
            var param = new CreateFileParam { DisplayType = Excel.Application.Enums.DisplayType.GroupByAsset, FileType = Excel.Application.Enums.FileType.Csv };

            var operations = FakeOperation.CreateOperationsSuccess();
            _operationRepository.GetAll().Returns(operations);

            _operationStrategyHandler.GetGroupOperations(param.DisplayType, operations).Returns(operations);

            //Act
            _operationAppService.CreateFile(param).GetAwaiter().GetResult();

            //Assert
            _operationRepository.Received(One).GetAll();

            var condition = Arg.Is<IEnumerable<Operation>>(a => a.Equals(operations));
            _operationStrategyHandler.Received(One).GetGroupOperations(param.DisplayType, condition);
            var conditionFile = Arg.Is<IEnumerable<Operation>>(a => a.Equals(operations));
            _fileStrategyHandler.Received(One).CreateFile(param.FileType, param.DisplayType, conditionFile);
        }

        [TestMethod]
        public void ShouldSucessWhenCreateFileWithDisplayTypeGroupByAssetAndFileTypeExcel()
        {
            //Arrange  
            var param = new CreateFileParam { DisplayType = Excel.Application.Enums.DisplayType.GroupByAsset, FileType = Excel.Application.Enums.FileType.Excel };

            var operations = FakeOperation.CreateOperationsSuccess();
            _operationRepository.GetAll().Returns(operations);

            _operationStrategyHandler.GetGroupOperations(param.DisplayType, operations).Returns(operations);

            //Act
            _operationAppService.CreateFile(param).GetAwaiter().GetResult();

            //Assert
            _operationRepository.Received(One).GetAll();

            var condition = Arg.Is<IEnumerable<Operation>>(a => a.Equals(operations));
            _operationStrategyHandler.Received(One).GetGroupOperations(param.DisplayType, condition);
            var conditionFile = Arg.Is<IEnumerable<Operation>>(a => a.Equals(operations));
            _fileStrategyHandler.Received(One).CreateFile(param.FileType, param.DisplayType, conditionFile);
        }
    }
}
