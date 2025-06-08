using ReqnrollProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.StepDefinitions.ShoppingBasket
{
    [Binding]
    public sealed class ShoppingBasketRunSteps
    {
        private List<Products>? _seedProduct;
        private Products? _productUnderTests;
        private ScenarioContext _scenarioContext;
        public ShoppingBasketRunSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [When("I click the Add to Basket button")]
        public void WhenIClickTheAddToBasketButton()
        {
            _productUnderTests = _scenarioContext.Get<Products>("ProductUnderTests");

            if (_productUnderTests == null)
                throw new InvalidOperationException("Product is not initialized");

            _productUnderTests.Message = (_productUnderTests.Stock, _productUnderTests.Basket) switch
            {
                (0, _) => "Out of stock",
                (_, > 0) => "Already in basket",
                _ => AddToBasket()
            };
        }

        [When("I remove Product Id {int} from basket")]
        public void WhenIRemoveProductIdFromBasket(int productId)
        {
            _seedProduct = _scenarioContext.Get<List<Products>>("SeedProduct");
            _productUnderTests = _seedProduct?.FirstOrDefault(p => p.ProductId == productId);
            if (_productUnderTests == null) throw new ArgumentNullException(nameof(_productUnderTests), $"Product with ID {productId} not found in the seed data.");
            if (_productUnderTests.Basket > 0) RemoveFromBasket();
        }
        private string AddToBasket()
        {
            _productUnderTests = _scenarioContext.Get<Products>("ProductUnderTests");
            _productUnderTests!.Basket++;
            _productUnderTests.Stock--;
            return _productUnderTests.Message = "Added to basket";
        }

        private string RemoveFromBasket()
        {
            _productUnderTests.Basket--;
            _productUnderTests.Stock++;
            return _productUnderTests.Message = "Removed from basket";

        }
    }
}
