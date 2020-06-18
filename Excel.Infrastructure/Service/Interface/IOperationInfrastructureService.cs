using Excel.Domain;
using System.Collections.Generic;

namespace Excel.Infrastructure.Service.Interface
{
    public interface IOperationInfrastructureService
    {
        void GenerateFile(IEnumerable<Operation> operations);
    }
}
