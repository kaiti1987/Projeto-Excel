using System;

namespace Excel.Application.Mapping.Result
{
    public class GetOperationsResult
    {
        public int Id { get; set; }
        public DateTime InclusionDate { get; set; }
        public string Type { get; set; }
        public string AssetName { get; set; }
        public Int64 Quantity { get; set; }
        public decimal Price { get; set; }
        public int Account { get; set; }
    }
}
