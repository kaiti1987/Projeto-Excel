using Excel.Domain;
using Excel.Infrastructure.Enums;
using Excel.Infrastructure.Extensions;
using Excel.Infrastructure.Service.Interface;
using NPOI.OpenXml4Net.OPC;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Excel.Infrastructure.Service.Implementation
{
    public class WorksheetInfrastructureService: IWorksheetInfrastructureService
    {
        public void CreateWorksheet(DisplayType displayType, IEnumerable<Operation> filter)
        {
            var memoryStream = new MemoryStream();
            var executingAssembly = Assembly.GetExecutingAssembly();

            using (var stream = executingAssembly.GetManifestResourceStream($"Excel.Infrastructure.Templates.{displayType.ToString()}.xlsx"))
            {
                CreateSheet(stream, out var workbook, out var sheet);

                if (displayType.Equals(DisplayType.All))
                    FillSheet(filter, sheet);
                else
                    FillSheetGroupBy(filter, sheet, displayType);

                workbook.Write(memoryStream);
                var output = memoryStream.ToArray();

                File.WriteAllBytes($"{System.AppDomain.CurrentDomain.BaseDirectory.GetParentPath()}/Relatorios/operations.xlsx", output);
            }
        }

        private static void CreateSheet(Stream stream, out IWorkbook workbook, out ISheet sheet)
        {
            var package = OPCPackage.Open(stream);
            workbook = new XSSFWorkbook(package);
            sheet = workbook.GetSheet("Planilha1");
        }

        private static void FillSheetGroupBy(IEnumerable<Operation> excel, ISheet sheet, DisplayType displayType)
        {
            int initialRow = 1;

            foreach (var itemRow in excel)
            {

                var row = sheet.CreateRow(initialRow);

                var cell = row.CreateCell(0, CellType.String);

                if(displayType.Equals(DisplayType.GroupByType))
                    cell.SetCellValue(itemRow.Type.GetDescription());
                else if(displayType.Equals(DisplayType.GroupByAccount))
                    cell.SetCellValue(itemRow.Account.ToString());
                else
                    cell.SetCellValue(itemRow.AssetName.ToString());

                cell = row.CreateCell(1, CellType.Numeric);
                cell.SetCellValue(itemRow.Quantity);
                cell = row.CreateCell(2, CellType.Numeric);
                cell.SetCellValue(itemRow.Price.ToString());

                initialRow++;
            }
        }

        private static void FillSheet(IEnumerable<Operation> excel, ISheet sheet)
        {
            int initialRow = 1;

            foreach (var itemRow in excel)
            {

                var row = sheet.CreateRow(initialRow);

                var cell = row.CreateCell(0, CellType.Numeric);

                cell.SetCellValue(itemRow.Id);                        
                cell = row.CreateCell(1, CellType.String);
                cell.SetCellValue(itemRow.InclusionDate.ToString());                
                cell = row.CreateCell(2, CellType.String);
                cell.SetCellValue(itemRow.Type.GetDescription());                
                cell = row.CreateCell(3, CellType.String);
                cell.SetCellValue(itemRow.AssetName);                
                cell = row.CreateCell(4, CellType.Numeric);
                cell.SetCellValue(itemRow.Quantity);                
                cell = row.CreateCell(5, CellType.Numeric);
                cell.SetCellValue(itemRow.Price.ToString());
                cell = row.CreateCell(6, CellType.Numeric);
                cell.SetCellValue(itemRow.Account);

                initialRow++;
            }
        }
    }
}
