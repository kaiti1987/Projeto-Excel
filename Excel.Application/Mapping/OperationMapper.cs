using Excel.Application.Mapping.Result;
using Excel.Domain;
using Excel.Infrastructure.Extensions;
using System.Collections.Generic;

namespace Excel.Application.Mapping
{
    public static class OperationMapper
    {
        public static IEnumerable<GetOperationsResult> MapToResult(this IEnumerable<Operation> operations)
        {
            var result = new List<GetOperationsResult>();

            foreach (var operation in operations)
            {
                result.Add(new GetOperationsResult
                {
                    Account = operation.Account,
                    AssetName = operation.AssetName,
                    Id = operation.Id,
                    InclusionDate = operation.InclusionDate,
                    Price = operation.Price,
                    Quantity = operation.Quantity,
                    Type = operation.Type.GetDescription()
                });
            }

            return result;
        }       
    }
}
