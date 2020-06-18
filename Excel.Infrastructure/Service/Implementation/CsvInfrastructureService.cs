using Excel.Domain;
using Excel.Infrastructure.Enums;
using Excel.Infrastructure.Extensions;
using Excel.Infrastructure.Service.Interface;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Excel.Infrastructure.Service.Implementation
{
    public class CsvInfrastructureService : ICsvInfrastructureService
    {
        public void CreateCsv(DisplayType displayType, IEnumerable<Operation> operations)
        {
            var builder = new StringBuilder();

            if (displayType.Equals(DisplayType.All))
                FillCsv(builder, operations);
            else
                FillGroupCsv(builder, operations, displayType);
            
            File.WriteAllText($"{System.AppDomain.CurrentDomain.BaseDirectory.GetParentPath()}/Relatorios/operations.csv", builder.ToString(), Encoding.GetEncoding("iso-8859-1"));
        }

        private static void FillGroupCsv(StringBuilder builder, IEnumerable<Operation> operations, DisplayType displayType)
        {            
            if(displayType.Equals(DisplayType.GroupByType))
                builder.AppendLine("Tipo Operação,Quantidade,Preço"); 
            else if (displayType.Equals(DisplayType.GroupByAccount))
                builder.AppendLine("Conta,Quantidade,Preço");
            else
                builder.AppendLine("Ativo,Quantidade,Preço");

            foreach (var operation in operations)
            {
                if (displayType.Equals(DisplayType.GroupByType))
                    builder.AppendLine($"{operation.Type.GetDescription()},{operation.Quantity},{operation.Price.ToString().Replace(",", ".")}");
                else if (displayType.Equals(DisplayType.GroupByAccount))
                    builder.AppendLine($"{operation.Account},{operation.Quantity},{operation.Price.ToString().Replace(",", ".")}");
                else
                    builder.AppendLine($"{operation.AssetName},{operation.Quantity},{operation.Price.ToString().Replace(",", ".")}");
            }
        }

        private static void FillCsv(StringBuilder builder, IEnumerable<Operation> operations)
        {
            builder.AppendLine("Id,Data,Tipo Operação,Ativo,Quantidade,Preço,Conta");

            foreach (var operation in operations)
            {
                builder.AppendLine($"{operation.Id},{operation.InclusionDate},{operation.Type.GetDescription()},{operation.AssetName},{operation.Quantity},{operation.Price.ToString().Replace(",",".")},{operation.Account}");
            }
        }
    }
}
