using Excel.Application.Enums;
using Excel.Domain;
using System.Collections.Generic;

namespace Excel.Application.Strategy.Contracts
{
    public interface IOperationStrategyHandler
    {
        IEnumerable<Operation> GetGroupOperations(DisplayType operationGroupBy, IEnumerable<Operation> operations);
    }
}
