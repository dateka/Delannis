using System.Collections.Generic;
using System.Linq;
using Ynov.Delannis.Domain.Common;
using Ynov.Delannis.DomainShared.Core.Exceptions.CartAggregate;

namespace Ynov.Delannis.Domain.CartAggregate
{
    public class Cart : EntityBase, IAggregateRoot
    {
        private const int MinProPositiveValue = 0;
        private List<CartItem> _cartItems = new List<CartItem>();
        public IReadOnlyCollection<CartItem> CartItems => _cartItems;

        public decimal TotalWithTaxes => _cartItems.Sum(_ => _.Quantity * _.TaxedPrice);
        public string Email { get; set; }


        public void AddItem(string label, decimal taxedPrice, decimal taxRate, int quantity)
        {
            CartItem cartItem = new CartItem(label, taxedPrice, taxRate, quantity);

            _cartItems.Add(cartItem);
        }

        public List<CartItem> EmptyItems()
        {
            List<CartItem> copy = new List<CartItem>(_cartItems);
            _cartItems = new List<CartItem>();

            return copy;
        }

        public int UpdateCartItemQuantity(string productName, int quantity)
        {
            CartItem cartItem = CartItems.FirstOrDefault(_ => _.Label == productName) ??
                                throw new CartDoesNotContainItemException();

            int finalQuantity = cartItem.Quantity + quantity;

            if (finalQuantity <= 0)
            {
                _cartItems.Remove(cartItem);
            }
            else
            {
                cartItem.SetQuantity(finalQuantity);
            }

            return finalQuantity;
        }
    }

    public class CartItem : EntityBase
    {
        public CartItem(string label, decimal taxedPrice, decimal taxRate, int quantity)
        {
            Label = label;
            TaxedPrice = taxedPrice;
            TaxRate = taxRate;
            Quantity = quantity;
        }
        
        public string Label { get; private set; }
        public decimal TaxedPrice { get; private set; }
        public decimal TaxRate { get; private set; }
        public int Quantity { get; private set; }
        
        public void SetQuantity(int finalQuantity)
        {
            Quantity = finalQuantity;
        }
    }
}