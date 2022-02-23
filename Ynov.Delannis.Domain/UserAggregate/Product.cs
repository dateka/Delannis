using Ynov.Delannis.Domain.Common;

namespace Ynov.Delannis.Domain.UserAggregate
{
    public class Product : EntityBase, IAggregateRoot
    {
        public string Name { get; }
        public float Price { get;  }

        public Product(string productModelName, float productModelPrice)
        {
            Name = productModelName;
            Price = productModelPrice;
        }
    }
}