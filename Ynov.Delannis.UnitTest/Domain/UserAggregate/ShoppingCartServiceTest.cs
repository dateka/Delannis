using Ynov.Delannis.Domain.UserAggregate;
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
    }
}