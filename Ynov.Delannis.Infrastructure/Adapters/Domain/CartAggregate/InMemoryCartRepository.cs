using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Ynov.Delannis.Domain.CartAggregate;
using Ynov.Delannis.Domain.CartAggregate.Ports;

namespace Ynov.Delannis.Infrastructure.Adapters.Domain.CartAggregate
{
    public class InMemoryCartRepository : ICartRepository
    {
        private IImmutableList<Cart> _carts = ImmutableArray<Cart>.Empty;
        public IReadOnlyCollection<Cart>? Carts => _carts.Select(_ => _.Adapt<Cart>()).ToList().AsReadOnly();
        public ValueTask<Cart> GetCartByIdAndUserEmailAsync(int cartId, string? userEmail) => new ValueTask<Cart>(Carts.First(_ => Int64.Parse(_.Id) == cartId && _.Email == userEmail));

        public Task AddAsync(Cart cart)
        {
            _carts = _carts.Add(cart);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Cart cart)
        {
            ICollection<Cart> tempCarts = _carts.Where(_ => _.Id != cart.Id).ToList();
            tempCarts.Add(cart);

            _carts = tempCarts.ToImmutableList();
        
            return Task.CompletedTask;
        }

        public ValueTask<Cart?> GetCartByUserEmailAsync(string? userEmail) => new ValueTask<Cart?>(_carts.FirstOrDefault(_ => _.Email == userEmail));
    }
}