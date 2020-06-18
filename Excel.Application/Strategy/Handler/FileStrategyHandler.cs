using Excel.Application.Enums;
using Excel.Application.Strategy.Contracts;
using Excel.Domain;
using System.Collections.Generic;

namespace Excel.Application.Strategy.Handler
{
    public sealed class FileStrategyHandler : IFileStrategyHandler
    {
        private readonly Dictionary<FileType, IFileStrategy> _strategies =
          new Dictionary<FileType, IFileStrategy>();

        public FileStrategyHandler(IFileExcelStrategy fileExcelStrategy,
                                   IFileCsvStrategy fileCsvStrategy)
        {
            _strategies.Add(FileType.Excel, fileExcelStrategy);
            _strategies.Add(FileType.Csv, fileCsvStrategy);
        }

        public void CreateFile(FileType fileType, DisplayType displayType, IEnumerable<Operation> operations)
        {
            _strategies[fileType].CreateFile(displayType, operations);
        }
    }
}
