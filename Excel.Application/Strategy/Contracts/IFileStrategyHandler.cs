using Excel.Application.Enums;
using Excel.Domain;
using System.Collections.Generic;

namespace Excel.Application.Strategy.Contracts
{
    public interface IFileStrategyHandler
    {
        void CreateFile(FileType fileType, DisplayType displayType, IEnumerable<Operation> operations);
    }
}
