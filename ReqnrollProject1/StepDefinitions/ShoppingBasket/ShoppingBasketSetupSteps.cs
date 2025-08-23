
using ReqnrollProject1.Models;
using static ReqnrollProject1.Models.Products;

namespace ReqnrollProject1.StepDefinitions.ShoppingBasket
{
    [Binding]
    public sealed class ShoppingBasketSetupSteps
    {
        private ProductTestDataContext _productTestDataContext;
        private ClothesSizeContext _clothesSizeContext;
        public ShoppingBasketSetupSteps(ProductTestDataContext productTestDataContext, ClothesSizeContext clothesSizeContext)
        {
            _productTestDataContext = productTestDataContext;
            _clothesSizeContext = clothesSizeContext;
        }

        [Given("I have the following data")]
        public void GivenIHaveTheFollowingData(DataTable dataTable)
        {
            _productTestDataContext.SeededProducts = dataTable.CreateSet<Products.ProductQuantities>().ToList();
           
        }

        [Given("I am on the product detail page of product {int}")]
        public void GivenIAmOnTheProductDetailPageOfProduct(int productId)
        {
            _productTestDataContext.ProductUnderTest = _productTestDataContext.SeededProducts?.FirstOrDefault(p => p.ProductId == productId);
            if(_productTestDataContext.ProductUnderTest is null) throw new ArgumentNullException(nameof(_productTestDataContext.ProductUnderTest), $"Product with ID {productId} not found in the seed data.");
        }

        [Given("I am on the basket page")]
        public void GivenIAmOnTheBasketPage()
        {
        }

        [Given("I have the following offer codes")]
        public void GivenIHaveTheFollowingOfferCodes(DataTable dataTable)
        {
            var results = dataTable.CreateSet<OfferCodes>(); 
        }
        [Given("today is {string}")]
        public void GivenTodayIs(DateTime today)
        {
             
        }

        [Given("I have an offer code of {string}with an offer type of {OfferCodeType}")]
        public void GivenIHaveAnOfferCodeOfWithAnOfferTypeOf(string offerCode, OfferCodeType offerCodeType)
        {
            
        }

        [Given("I have the following clothes size data")]
        public void GivenIHaveTheFollowingClothesSizeData(DataTable dataTable)
        {
            _clothesSizeContext.clothesSize = dataTable.CreateSet<Products.ClothesSize>().ToList();
        }


    }
}
