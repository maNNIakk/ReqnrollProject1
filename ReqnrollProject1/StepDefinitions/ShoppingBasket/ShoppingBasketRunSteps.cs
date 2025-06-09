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
     

        [When("I click the Add to Basket button")]
        public void WhenIClickTheAddToBasketButton()
        {
        
            if (Products.ProductUnderTest!.Stock > 0 && Products.ProductUnderTest.Basket == 0)
            {
                AddToBasket();
            }
        }

        [When("I remove Product Id {int} from basket")]
        public void WhenIRemoveProductIdFromBasket(int productId)
        {
            Products.ProductUnderTest = Products.SeededProducts?.FirstOrDefault(p => p.ProductId == productId);
            if (Products.ProductUnderTest == null) throw new ArgumentNullException(nameof(Products.ProductUnderTest), $"Product with ID {productId} not found in the seed data.");            
            if (Products.ProductUnderTest.Basket > 0)
            {
                RemoveFromBasket();
            }
        }
        private string AddToBasket()
        {
            Products.ProductUnderTest!.Basket++;
            Products.ProductUnderTest.Stock--;
            return Products.ProductUnderTest.Message = "Added to basket";
        }

        private string RemoveFromBasket()
        {
            Products.ProductUnderTest!.Basket--;
            Products.ProductUnderTest.Stock++;
            return Products.ProductUnderTest.Message = "Removed from basket";

        }
    }
}
