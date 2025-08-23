namespace ReqnrollProject1.Models
{
    public class Products
    {
        public const string PRODUCT_TEST_DATA_CONTEXT = "ProductTestDataContext";
        public class ProductQuantities
        {
            public int ProductId { get; set; }
            public int Stock { get; set; }
            public int Basket { get; set; }
            public string Message { get; set; } = string.Empty;
        

        }

        public class ProductTestDataContext
        {
            public List<ProductQuantities>? SeededProducts;
            public ProductQuantities? ProductUnderTest;
        }

        public class OfferCodeContext
        {
            public List<OfferCodes>? OfferCodes { get; set; }
            public DateTime Today { get; set; } 
        }

        public class ClothesSizeContext
        {
            public List<ClothesSize>? clothesSize;
        }

        public class OfferCodes
        {
            public string? OfferCode { get; set; }
            public DateTime ExpiryDate { get; set; }
            public OfferCodeType OfferCodeType { get; set; }
            public bool IsValid { get; set; }

        }

        public enum OfferCodeType
        {
            ByProduct,
            ByDate,
            ByPrice,
            ByDay
        }

        public class ClothesSize
        {
            public string? Name { get; set; }
            public InternalSize? Size { get; set; }

        }

        public class InternalSize
        {
            public string? InternalName { get; set; }
            public string? Width { get;set; }
            public string? Height { get; set; }

        }
    }
}
