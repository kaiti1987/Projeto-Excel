using Excel.Domain;
using System.Collections.Generic;

namespace Excel.Application.Strategy.Contracts
{
    public interface IOperationStrategy
    {
        IEnumerable<Operation> GetGroupOperations(IEnumerable<Operation> operations);
    }
}
