using Excel.Application.Enums;
using Excel.Application.Strategy.Contracts;
using Excel.Domain;
using Excel.Infrastructure.Service.Interface;
using System.Collections.Generic;

namespace Excel.Application.Strategy
{
    public class FileExcelStrategy: IFileExcelStrategy
    {
        private readonly IWorksheetInfrastructureService _worksheetInfrastructureService;

        public FileExcelStrategy(IWorksheetInfrastructureService worksheetInfrastructureService)
        {
            _worksheetInfrastructureService = worksheetInfrastructureService;
        }

        public void CreateFile(DisplayType displayType, IEnumerable<Operation> operations)
        {
            _worksheetInfrastructureService.CreateWorksheet((Infrastructure.Enums.DisplayType)displayType,operations);
        }
    }
}
