using ReqnrollProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.StepDefinitions.ShoppingBasket
{
    [Binding]
    public sealed class ShoppingBasketValidationSteps
    {
        private List<Products>? _seedProduct;

        private Products? _productUnderTests;
        private ScenarioContext? _scenarioContext;

        public ShoppingBasketValidationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Then("the quantities are")]
        public void ThenTheQuantitiesAreStockLevelOfAndBasketQtyOfForProductIDProductId(DataTable dataTable)
        {
            _seedProduct = _scenarioContext!.Get<List<Products>>("SeedProduct");
            dataTable.CompareToSet(_seedProduct);
        }

        [Then("the quantities are stock level of {int} and basket qty of {int}")]
        public void ThenTheQuantitiesAreStockLevelOfAndBasketQtyOf(int stockQty, int basketQty)
        {
            _productUnderTests = _scenarioContext!.Get<Products>("ProductUnderTests");
            Assert.AreEqual(stockQty, _productUnderTests?.Stock, "Stock level does not match");
            Assert.AreEqual(basketQty, _productUnderTests?.Basket, "Basket quantity does not match");
        }



        [Then("a message {string} is displayed to the customer")] 
        public void ThenAMessageIsDisplayedToTheCustomer(string expectedMessage)
        {
            //_scenarioContext!.Pending();
        }

    }
}
