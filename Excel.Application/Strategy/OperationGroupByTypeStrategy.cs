using Excel.Application.Strategy.Contracts;
using Excel.Domain;
using Excel.Domain.Contracts;
using System.Collections.Generic;

namespace Excel.Application.Strategy
{
    public class OperationGroupByTypeStrategy: IOperationGroupByTypeStrategy
    {
        private readonly IOperationRepository _operationRepository;

        public OperationGroupByTypeStrategy(IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository;
        }

        public IEnumerable<Operation> GetGroupOperations(IEnumerable<Operation> operations)
        {
            return _operationRepository.GroupByOperationType(operations);
        }
    }
}
