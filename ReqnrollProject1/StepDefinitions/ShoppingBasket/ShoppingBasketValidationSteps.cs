using ReqnrollProject1.Models;
using static ReqnrollProject1.Models.Products;
namespace ReqnrollProject1.StepDefinitions.ShoppingBasket
{
    [Binding]
    public sealed class ShoppingBasketValidationSteps
    {
        private ProductTestDataContext _productTestDataContext;
        private ClothesSizeContext _clothesSizeContext;
        public ShoppingBasketValidationSteps(ProductTestDataContext productTestDataContext, ClothesSizeContext clothesSizeContext)
        {
            _productTestDataContext = productTestDataContext;
            _clothesSizeContext = clothesSizeContext;
        }

        [Then("the quantities are")]
        public void ThenTheQuantitiesAreStockLevelOfAndBasketQtyOfForProductIDProductId(DataTable dataTable)
        {
            dataTable.CompareToSet(_productTestDataContext.SeededProducts);
        }

        [Then("the quantities are stock level of {int} and basket qty of {int}")]
        public void ThenTheQuantitiesAreStockLevelOfAndBasketQtyOf(int stockQty, int basketQty)
        {
            var productUnderTest = _productTestDataContext.ProductUnderTest;
            Assert.AreEqual(stockQty, productUnderTest?.Stock, "Stock level does not match");
            Assert.AreEqual(basketQty, productUnderTest?.Basket, "Basket quantity does not match");
        }



        [Then("a message {string} is displayed to the customer")] 
        public void ThenAMessageIsDisplayedToTheCustomer(string expectedMessage)
        {
            //_scenarioContext!.Pending();
        }

        [Then("the offer code is valid")]
        public void ThenTheOfferCodeIsValid()
        {
        }

        [Then("the clothing data is translated to")]
        public void ThenTheClothingDataIsTranslatedTo(DataTable dataTable)
        {
            dataTable.CompareToSet<Products.ClothesSize>(_clothesSizeContext.clothesSize);
        }



    }
}
