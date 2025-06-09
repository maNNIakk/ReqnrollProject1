using ReqnrollProject1.Models;
namespace ReqnrollProject1.StepDefinitions.ShoppingBasket
{
    [Binding]
    public sealed class ShoppingBasketValidationSteps
    {
        [Then("the quantities are")]
        public void ThenTheQuantitiesAreStockLevelOfAndBasketQtyOfForProductIDProductId(DataTable dataTable)
        {
            dataTable.CompareToSet(Products.SeededProducts);
        }

        [Then("the quantities are stock level of {int} and basket qty of {int}")]
        public void ThenTheQuantitiesAreStockLevelOfAndBasketQtyOf(int stockQty, int basketQty)
        {
            Assert.AreEqual(stockQty, Products.ProductUnderTest?.Stock, "Stock level does not match");
            Assert.AreEqual(basketQty, Products.ProductUnderTest?.Basket, "Basket quantity does not match");
        }



        [Then("a message {string} is displayed to the customer")] 
        public void ThenAMessageIsDisplayedToTheCustomer(string expectedMessage)
        {
            //_scenarioContext!.Pending();
        }

    }
}
