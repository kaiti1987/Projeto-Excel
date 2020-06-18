using Excel.Domain;
using Excel.Infrastructure.Enums;
using System.Collections.Generic;

namespace Excel.Infrastructure.Service.Interface
{
    public interface IWorksheetInfrastructureService
    {
        void CreateWorksheet(DisplayType displayType, IEnumerable<Operation> filter);
    }
}
