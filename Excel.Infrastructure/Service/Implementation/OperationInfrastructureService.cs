using Excel.Domain;
using Excel.Infrastructure.Extensions;
using Excel.Infrastructure.Service.Interface;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Excel.Infrastructure.Service.Implementation
{
    public class OperationInfrastructureService : IOperationInfrastructureService
    {
        public void GenerateFile(IEnumerable<Operation> operations)
        {                        
            var fileName = $"{System.AppDomain.CurrentDomain.BaseDirectory.GetParentPath()}/Massa/operations.json";
            var jsonString = JsonConvert.SerializeObject(operations);

            File.WriteAllText(fileName, jsonString);            
        }
    }
}
