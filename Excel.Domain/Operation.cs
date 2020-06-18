using Excel.Domain.Enums;
using System;

namespace Excel.Domain
{
    public class Operation
    {
        public Operation()
        {

        }

        public Operation(int id, DateTime inclusionDate, OperationType type, string assetName, long quantity, decimal price, int account)
        {
            Id = id;
            InclusionDate = inclusionDate;
            Type = type;
            AssetName = assetName;
            Quantity = quantity;
            Price = price;
            Account = account;
        }

        public int Id { get; set; }
        public DateTime InclusionDate { get; set; }
        public OperationType Type { get; set; }
        public string AssetName { get; set; }
        public Int64 Quantity { get; set; }
        public decimal Price { get; set; }
        public int Account { get; set; }

        public decimal AvgPrice() => (Quantity * Price) / Quantity;        
    }
}
