using TechTalk.SpecFlow;

namespace Ynov.Delannis.Specs.Steps.UserAggregate
{
    [Binding]
    public class ShoppingCartDefinition
    {
        [When(@"I add one product to my shopping cart")]
        public void WhenIAddOneProductToMyShoppingCart()
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"The shopping cart should get updated")]
        public void ThenTheShoppingCartShouldGetUpdated()
        {
            ScenarioContext.StepIsPending();
        }

        [When(@"I add the same product twice to my shopping cart")]
        public void WhenIAddTheSameProductTwiceToMyShoppingCart()
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"The shopping cart quantity should be two and the price should be twice the initial price")]
        public void ThenTheShoppingCartQuantityShouldBeTwoAndThePriceShouldBeTwiceTheInitialPrice()
        {
            ScenarioContext.StepIsPending();
        }

        [When(@"I add two different products to my shopping cart")]
        public void WhenIAddTwoDifferentProductsToMyShoppingCart()
        {
            ScenarioContext.StepIsPending();
        }

        [When(@"I remove one product from my shopping cart")]
        public void WhenIRemoveOneProductFromMyShoppingCart()
        {
            ScenarioContext.StepIsPending();
        }

        [When(@"I remove all product from my shopping cart")]
        public void WhenIRemoveAllProductFromMyShoppingCart()
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"The shopping cart should be empty")]
        public void ThenTheShoppingCartShouldBeEmpty()
        {
            ScenarioContext.StepIsPending();
        }
    }
}