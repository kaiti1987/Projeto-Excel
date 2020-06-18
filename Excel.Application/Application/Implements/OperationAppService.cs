using Excel.Application.Application.Contracts;
using Excel.Application.Enums;
using Excel.Application.Mapping;
using Excel.Application.Mapping.Param;
using Excel.Application.Mapping.Result;
using Excel.Application.Strategy.Contracts;
using Excel.Domain.Contracts;
using Excel.Infrastructure.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Excel.Application.Application.Implements
{
    public class OperationAppService : IOperationAppService
    {
        private readonly IOperationRepository _operationRepository;
        private readonly IOperationInfrastructureService _operationInfrastructureService;        
        private readonly IFileStrategyHandler _fileStrategyHandler;
        private readonly IOperationStrategyHandler _operationStrategyHandler;

        public OperationAppService(IOperationRepository operationRepository,
                                   IOperationInfrastructureService operationInfrastructureService,
                                   IFileStrategyHandler fileStrategyHandler,
                                   IOperationStrategyHandler operationStrategyHandler)
        {
            _operationRepository = operationRepository;
            _operationInfrastructureService = operationInfrastructureService;
            _fileStrategyHandler = fileStrategyHandler;
            _operationStrategyHandler = operationStrategyHandler;
        }

        public async Task GenerateData()
        {
            var operations = await _operationRepository.GetOperation().ConfigureAwait(false);

            _operationInfrastructureService.GenerateFile(operations);
        }       
        
        public async Task<IEnumerable<GetOperationsResult>> GetOperations(GetOperationsParam param)
        {
            var operations = await _operationRepository.GetAll().ConfigureAwait(false);

            if (!param.DisplayType.Equals(DisplayType.All))
            {
               operations = _operationStrategyHandler.GetGroupOperations(param.DisplayType, operations);
            }
                        
            return operations.MapToResult();
        }
       
        public async Task CreateFile(CreateFileParam param)
        {
            var operations = await _operationRepository.GetAll().ConfigureAwait(false);

            if (!param.DisplayType.Equals(DisplayType.All))
            {
                operations = _operationStrategyHandler.GetGroupOperations(param.DisplayType, operations);
            }

            _fileStrategyHandler.CreateFile(param.FileType, param.DisplayType, operations);
        }
    }
}
