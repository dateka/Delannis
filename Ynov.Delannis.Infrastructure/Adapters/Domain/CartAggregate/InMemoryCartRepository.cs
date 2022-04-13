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
        //private IImmutableList<Cart> _carts = ImmutableArray<Cart>.Empty;
        
        private IImmutableSet<Cart> _carts = ImmutableHashSet<Cart>.Empty;
        
        //public IReadOnlyCollection<Cart>? Carts => _carts.Select(_ => _.Adapt<Cart>()).ToList().AsReadOnly();

        public Task<Cart> GetCartByIdAndUserEmailAsync(string cartId, string? userEmail)
        {
            return Task.FromResult(_carts.First(_ => _.Id == cartId && _.Email == userEmail));
           //return new ValueTask<Cart>(Carts.First(_ => _.Id == cartId && _.Email == userEmail));
        } 

        public Task AddAsync(Cart product)
        {
            IImmutableSet<Cart> immutableSet = _carts.Add(product);
            _carts = immutableSet;
            
            return Task.CompletedTask;
        }
        
        /*public Task AddAsync(Cart cart)
        {
            _carts = _carts.Add(cart);
            return Task.CompletedTask;
        }*/
        
        public Task UpdateAsync(Cart product)
        {
            ICollection<Cart> tempProducts = _carts.Where(_ => _.Id != product.Id).ToList();
            tempProducts.Add(product);

            _carts = tempProducts.ToImmutableHashSet();
        
            return Task.CompletedTask;
        }

        /*public Task UpdateAsync(Cart cart)
        {
            ICollection<Cart> tempCarts = _carts.Where(_ => _.Id != cart.Id).ToList();
            tempCarts.Add(cart);

            _carts = tempCarts.ToImmutableList();
        
            return Task.CompletedTask;
        }*/

        public Task<Cart> GetCartByUserEmailAsync(string? userEmail)
        {
            return Task.FromResult(_carts.First(_ => _.Email == userEmail));
        } 
        //public ValueTask<Cart?> GetCartByUserEmailAsync(string? userEmail) => new ValueTask<Cart?>(_carts.FirstOrDefault(_ => _.Email == userEmail));
    }
}