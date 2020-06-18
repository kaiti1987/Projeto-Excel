using Bogus;
using Excel.Domain;
using Excel.Domain.Enums;
using System.Collections.Generic;

namespace Excel.UnitTest.FakeObject
{
    internal static class FakeOperation
    {
        internal static Operation CreateSuccess()
        {
            return new Faker<Operation>()
               .StrictMode(false)
               .CustomInstantiator(f => new Operation(account: f.Random.Int(min: 1, max: 100),
                  assetName: f.Random.String2(minLength: 1, maxLength: 4),
                  id: f.Random.Int(min: 1),
                  inclusionDate: f.Date.Soon(),
                  price: f.Random.Decimal(min: 0.01M, max: 1000000),
                  quantity: f.Random.Int(min: 1, max: 1000000),
                  type: f.PickRandom<OperationType>()));
        }

        internal static IEnumerable<Operation> CreateOperationsSuccess()
        {
            var count = new Faker().Random.Int(1, 20);

            return new Faker<Operation>()
               .StrictMode(false)
               .CustomInstantiator(f => new Operation(account: f.Random.Int(min: 1, max: 100),
                  assetName: f.Random.String2(minLength: 1, maxLength: 4),
                  id: f.Random.Int(min: 1),
                  inclusionDate: f.Date.Soon(),
                  price: f.Random.Decimal(min: 0.01M, max: 1000000),
                  quantity: f.Random.Int(min: 1, max: 1000000),
                  type: f.PickRandom<OperationType>())).Generate(count);
        }

    }
}
