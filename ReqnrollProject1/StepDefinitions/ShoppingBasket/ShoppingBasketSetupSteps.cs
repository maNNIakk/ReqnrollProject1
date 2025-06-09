using ReqnrollProject1.Models;

namespace ReqnrollProject1.StepDefinitions.ShoppingBasket
{
    [Binding]
    public sealed class ShoppingBasketSetupSteps
    {
     
        [Given("I have the following data")]
        public void GivenIHaveTheFollowingData(DataTable dataTable)
        {
            Products.SeededProducts = dataTable.CreateSet<Products.ProductQuantities>().ToList();
        }

        [Given("I am on the product detail page of product {int}")]
        public void GivenIAmOnTheProductDetailPageOfProduct(int productId)
        {
                Products.ProductUnderTest = Products.SeededProducts?.FirstOrDefault(p => p.ProductId == productId);
                if (Products.ProductUnderTest == null) throw new ArgumentNullException(nameof(Products.ProductUnderTest), $"Product with ID {productId} not found in the seed data.");
        }

        [Given("I am on the basket page")]
        public void GivenIAmOnTheBasketPage()
        {
        }

    }
}
