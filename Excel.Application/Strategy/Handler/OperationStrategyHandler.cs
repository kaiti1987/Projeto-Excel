using Excel.Application.Enums;
using Excel.Application.Strategy.Contracts;
using Excel.Domain;
using System.Collections.Generic;

namespace Excel.Application.Strategy.Handler
{
    public sealed class OperationStrategyHandler: IOperationStrategyHandler
    {
        private readonly Dictionary<DisplayType, IOperationStrategy> _strategies =
         new Dictionary<DisplayType, IOperationStrategy>();

        public OperationStrategyHandler(IOperationGroupByAccountStrategy operationGroupByAccountStrategy,
                                        IOperationGroupByAssetStrategy operationGroupByAsset,
                                        IOperationGroupByTypeStrategy operationGroupByType)
            
        {
            _strategies.Add(DisplayType.GroupByAccount, operationGroupByAccountStrategy);
            _strategies.Add(DisplayType.GroupByAsset, operationGroupByAsset);
            _strategies.Add(DisplayType.GroupByType, operationGroupByType);
        }
        
        public IEnumerable<Operation> GetGroupOperations(DisplayType operationGroupBy, IEnumerable<Operation> operations)
        {
            return _strategies[operationGroupBy].GetGroupOperations(operations);            
        }
    }
}
