using Ynov.Delannis.Domain.Common;

namespace Ynov.Delannis.Domain.productAggregate
{
    public class Product : EntityBase, IAggregateRoot
    {
        public string Label { get; set; }
        public decimal TaxedPrice { get; set; }
        public decimal TaxRate { get; set; }
        public int StockQuantity { get; set; }

        public void LessStockQuantity(int quantity)
        {
            StockQuantity -= quantity;
        }

        public void AddStockQuantity(int quantity)
        {
            StockQuantity += quantity;
        }
    }
}