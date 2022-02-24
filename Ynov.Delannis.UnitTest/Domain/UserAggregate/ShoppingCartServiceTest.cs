using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Ynov.Delannis.Domain.UserAggregate;
using Ynov.Delannis.DomainShared.Core.Exceptions.UserAggregate;
using Ynov.Delannis.UnitTest.Commons;

namespace Ynov.Delannis.UnitTest.Domain.UserAggregate
{
    public class ShoppingCartServiceTest : UnitTestFixture
    {
        private readonly User elonMusk = new User("elonMusk", "elonMusk@tesla.com", "Azerty123&");
        
        public ShoppingCartServiceTest(UnitTestConfiguration unitTestConf) : base(unitTestConf)
        {
            InitFixtureAsync().GetAwaiter().GetResult();
        }
        
        [Fact]
        [Trait("Category", "Domain")]
        public void ShoppingCartService_WhenIaddOneProductIntoMyShoppingCart_ShouldUpdateMyShoppingCart()
        {
            
        }
        
        [Fact]
        [Trait("Category", "Domain")]
        public void ShoppingCartService_WhenIaddTheSameProductTwiceIntoMyShoppingCart_ShouldUpdateMyShoppingCart()
        {
            
        }
        
        [Fact]
        [Trait("Category", "Domain")]
        public void ShoppingCartService_WhenIaddTwoDifferentProductsIntoMyShoppingCart_ShouldUpdateMyShoppingCart()
        {
            
        }
        
        [Fact]
        [Trait("Category", "Domain")]
        public void ShoppingCartService_WhenIRemoveOneProductFromMyShoppingCart_ShouldUpdateMyShoppingCart()
        {
            
        }
    }
}