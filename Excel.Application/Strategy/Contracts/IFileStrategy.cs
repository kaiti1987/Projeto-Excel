using Excel.Application.Enums;
using Excel.Domain;
using System.Collections.Generic;

namespace Excel.Application.Strategy.Contracts
{
    public interface IFileStrategy
    {
        void CreateFile(DisplayType displayType, IEnumerable<Operation> operations);
    }
}
