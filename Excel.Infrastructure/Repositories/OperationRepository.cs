using Bogus;
using Excel.Domain;
using Excel.Domain.Contracts;
using Excel.Domain.Enums;
using Excel.Infrastructure.Extensions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace Excel.Infrastructure.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        public async Task<IEnumerable<Operation>> GetOperation()
        {
            var count = 2000;

            return new Faker<Operation>()
               .StrictMode(false)
               .CustomInstantiator(f => new Operation(account: f.Random.Int(min: 1, max: 100),
                  assetName: string.Concat(f.PickRandom<string>("PETR", "ITUB", "VALE", "ABEV"), f.Random.Int(min:1, max: 9)),
                  id: f.Random.Int(min: 1, max: 20000),
                  inclusionDate: f.Date.Soon(),
                  price: f.Finance.Amount(1, 1000, 2),
                  quantity: f.Random.Int(min: 1, max: 10000),
                  type: f.PickRandom<OperationType>())).Generate(count);
        }

        public async Task<IEnumerable<Operation>> GetAll()
        {            
            var fileName = $"{System.AppDomain.CurrentDomain.BaseDirectory.GetParentPath()}/Massa/operations.json";
            var operationJson = File.ReadAllText(fileName);

            var operation = JsonConvert.DeserializeObject<IEnumerable<Operation>>(operationJson);

            return operation;
        }

        public IEnumerable<Operation> GroupByAsset(IEnumerable<Operation> operations)
        {
            ObjectCache cache = MemoryCache.Default;
            string cacheKey = "asset";

            if (cache.Contains(cacheKey))
                return (IEnumerable<Operation>)cache.Get(cacheKey);
            else
            {
                var operationsGroupByAsset = operations.GroupBy(x => x.AssetName).Select(c => new Operation
                {
                    Quantity = c.Sum(t => t.Quantity),
                    Price = c.Sum(t => t.AvgPrice()),
                    AssetName = c.Key
                }).ToList();

                cache.AddCache(cacheKey, operationsGroupByAsset);

                return operationsGroupByAsset;
            }            
        }

        public IEnumerable<Operation> GroupByOperationType(IEnumerable<Operation> operations)
        {
            ObjectCache cache = MemoryCache.Default;
            string cacheKey = "operationType";

            if (cache.Contains(cacheKey))
                return (IEnumerable<Operation>)cache.Get(cacheKey);
            else
            {
                var operationsGroupByOperationType = operations.GroupBy(x => x.Type).Select(c => new Operation
                {
                    Quantity = c.Sum(t => t.Quantity),
                    Price = c.Sum(t => t.AvgPrice()),
                    Type = c.Key
                }).ToList();

                cache.AddCache(cacheKey, operationsGroupByOperationType);
                
                return operationsGroupByOperationType;
            }
        }

        public IEnumerable<Operation> GroupByAccount(IEnumerable<Operation> operations)
        {
            ObjectCache cache = MemoryCache.Default;
            string cacheKey = "account";

            if (cache.Contains(cacheKey))
                return (IEnumerable<Operation>)cache.Get(cacheKey);
            else
            {
                var operationsGroupByAccount = operations.GroupBy(x => x.Account).Select(c => new Operation
                {
                    Quantity = c.Sum(t => t.Quantity),
                    Price = c.Sum(t => t.AvgPrice()),
                    Account = c.Key
                }).ToList();

                cache.AddCache(cacheKey, operationsGroupByAccount);

                return operationsGroupByAccount;
            }            
        }
    }
}
