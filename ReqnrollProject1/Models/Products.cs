namespace ReqnrollProject1.Models
{
    public static class Products
    {
        private static List<ProductQuantities>? _seededProducts;
        private static ProductQuantities? _productUnderTest;

        public class ProductQuantities
        {
            public int ProductId { get; set; }
            public int Stock { get; set; }
            public int Basket { get; set; }
            public string Message { get; set; } = string.Empty;
        

        }

        public static List<ProductQuantities> SeededProducts
        {
            get => _seededProducts!; 
            set => _seededProducts = value; 
        }

        public static ProductQuantities? ProductUnderTest 
        {  
            get => _productUnderTest;
            set => _productUnderTest = value;
            
        }
    }
}
