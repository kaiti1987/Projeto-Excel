using Excel.Application.Enums;
using Excel.Application.Strategy.Contracts;
using Excel.Domain;
using Excel.Infrastructure.Service.Interface;
using System.Collections.Generic;

namespace Excel.Application.Strategy
{
    public class FileCsvStrategy: IFileCsvStrategy
    {
        private readonly ICsvInfrastructureService _csvInfrastructureService;

        public FileCsvStrategy(ICsvInfrastructureService csvInfrastructureService)
        {
            _csvInfrastructureService = csvInfrastructureService;
        }

        public void CreateFile(DisplayType displayType, IEnumerable<Operation> operations)
        {
            _csvInfrastructureService.CreateCsv((Infrastructure.Enums.DisplayType)displayType, operations);
        }
    }
}
