using System.Collections.Generic;
using System.Threading.Tasks;

namespace Excel.Domain.Contracts
{
    public interface IOperationRepository
    {
        Task<IEnumerable<Operation>> GetOperation();
        Task<IEnumerable<Operation>> GetAll();
        IEnumerable<Operation> GroupByAsset(IEnumerable<Operation> operations);
        IEnumerable<Operation> GroupByOperationType(IEnumerable<Operation> operations);
        IEnumerable<Operation> GroupByAccount(IEnumerable<Operation> operations);
    }
}
