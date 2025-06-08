using ReqnrollProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.StepDefinitions.ShoppingBasket
{
    [Binding]
    public sealed class ShoppingBasketSetupSteps
    {

        private List<Products>? _seedProduct;

        private Products? _productUnderTests;
        private ScenarioContext _scenarioContext;

        public ShoppingBasketSetupSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("I have the following data")]
        public void GivenIHaveTheFollowingData(DataTable dataTable)
        {
            _seedProduct = dataTable.CreateSet<Products>().ToList();
            _scenarioContext.Add("SeedProduct", _seedProduct);

        }

        [Given("I am on the product detail page of product {int}")]
        public void GivenIAmOnTheProductDetailPageOfProduct(int productId)
            {
                _productUnderTests = _seedProduct?.FirstOrDefault(p => p.ProductId == productId);
                if (_productUnderTests == null) throw new ArgumentNullException(nameof(_productUnderTests), $"Product with ID {productId} not found in the seed data.");
                _scenarioContext.Add("ProductUnderTests", _productUnderTests);
        }
        [Given("I am on the basket page")]
        public void GivenIAmOnTheBasketPage()
        {
        }

    }
}
