using Excel.Application.Mapping.Param;
using Excel.Application.Mapping.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Excel.Application.Application.Contracts
{
    public interface IOperationAppService
    {
        Task GenerateData();        
        Task<IEnumerable<GetOperationsResult>> GetOperations(GetOperationsParam param);
        Task CreateFile(CreateFileParam param);
    }
}
