using Excel.Application.Strategy.Contracts;
using Excel.Domain;
using Excel.Domain.Contracts;
using System.Collections.Generic;

namespace Excel.Application.Strategy
{
    public class OperationGroupByAccountStrategy : IOperationGroupByAccountStrategy
    {
        private readonly IOperationRepository _operationRepository;

        public OperationGroupByAccountStrategy(IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository;
        }

        public IEnumerable<Operation> GetGroupOperations(IEnumerable<Operation> operations)
        {
            return _operationRepository.GroupByAccount(operations);            
        }
    }
}
