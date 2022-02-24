using Ynov.Delannis.Domain.Common;

namespace Ynov.Delannis.Domain.UserAggregate
{
    public class Product : EntityBase, IAggregateRoot
    {
        public string Name { get; }
        public float Price { get;  }
        public int Quantity { get;  }

        public Product(string productModelName, float productModelPrice, int quantity)
        {
            Name = productModelName;
            Price = productModelPrice;
            Quantity = quantity;
        }
    }
}