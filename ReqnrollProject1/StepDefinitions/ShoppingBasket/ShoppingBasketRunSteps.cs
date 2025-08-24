
using static ReqnrollProject1.Models.Products;

namespace ReqnrollProject1.StepDefinitions.ShoppingBasket
{
    [Binding]
    public sealed class ShoppingBasketRunSteps 
    {
        private ProductTestDataContext _productTestDataContext;
        public ShoppingBasketRunSteps(ProductTestDataContext productTestDataContext)
        {
            _productTestDataContext = productTestDataContext;
        }


        [When("I click the Add to Basket button")]
        public void WhenIClickTheAddToBasketButton()
        {
        
            if (_productTestDataContext.ProductUnderTest!.Stock > 0 && _productTestDataContext.ProductUnderTest.Basket == 0)
            {
                AddToBasket();
            }
        }

        [When("I remove Product Id {int} from basket")]
        public void WhenIRemoveProductIdFromBasket(int productId)
        {
            _productTestDataContext.ProductUnderTest = _productTestDataContext.SeededProducts?.FirstOrDefault(p => p.ProductId == productId);
            if (_productTestDataContext.ProductUnderTest == null) throw new ArgumentNullException(nameof(_productTestDataContext.ProductUnderTest), $"Product with ID {productId} not found in the seed data.");            
            if (_productTestDataContext.ProductUnderTest.Basket > 0)
            {
                RemoveFromBasket();
            }
        }
        private string AddToBasket()
        {
            _productTestDataContext.ProductUnderTest!.Basket++;
            _productTestDataContext.ProductUnderTest.Stock--;
            return _productTestDataContext.ProductUnderTest.Message = "Added to basket";
        }

        private string RemoveFromBasket()
        {
            _productTestDataContext.ProductUnderTest!.Basket--;
            _productTestDataContext.ProductUnderTest.Stock++;
            return _productTestDataContext.ProductUnderTest.Message = "Removed from basket";

        }
    }
}
