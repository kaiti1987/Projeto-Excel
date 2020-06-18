using Excel.Domain;
using Excel.Infrastructure.Enums;
using System.Collections.Generic;

namespace Excel.Infrastructure.Service.Interface
{
    public interface ICsvInfrastructureService
    {
        void CreateCsv(DisplayType displayType,IEnumerable<Operation> operations);
    }
}
