using Reqnroll.Assist;

namespace ReqnrollProject1.Utils
{
    public class BooleanValueRetriever : IValueRetriever
    {
        public bool CanRetrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
        {
            switch (keyValuePair.Value.ToLowerInvariant())
                {
                    case "true":
                    case "yes":
                    case "t":
                    case "y":
                    case "false":
                    case "no":
                    case "f":
                    case "n":
                        return true;
                    default:
                        return false;
                }
        }

        public object Retrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
        {
            switch (keyValuePair.Value.ToLowerInvariant())
            {
                case "true":
                case "yes":
                case "t":
                case "y":
                    return true;
                default:
                    return false;
            }
        }
    }
}
