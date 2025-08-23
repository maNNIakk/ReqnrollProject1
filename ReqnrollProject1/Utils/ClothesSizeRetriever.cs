using Reqnroll.Assist;
using ReqnrollProject1.Models;

namespace ReqnrollProject1.Utils
{
    public class ClothesSizeRetriever : IValueRetriever
    {
        public bool CanRetrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
        {
            return propertyType == typeof(Products.InternalSize);
        }

        public object Retrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
        {
           switch (keyValuePair.Value)
            {
                case "XXL":
                    return new Products.InternalSize
                    {
                        InternalName = "ExtraExtraLarge",
                        Width = "240cm",
                        Height = "240cm"
                    };
                case "L":
                    return new Products.InternalSize
                    {
                        InternalName = "Large",
                        Width = "200cm",
                        Height = "200cm"
                    };
                case "S":
                    return new Products.InternalSize
                    {
                        InternalName = "Small",
                        Width = "160cm",
                        Height = "160cm"
                    };
                default:
                    throw new ArgumentException($"Unknown size: {keyValuePair.Value}", nameof(keyValuePair));
            }
        }
    }
}
