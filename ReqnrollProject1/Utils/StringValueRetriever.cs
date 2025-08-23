using Reqnroll.Assist;

namespace ReqnrollProject1.Utils
{
    public class StringValueRetriever : IValueRetriever
    {
        public bool CanRetrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
        {
            return propertyType == typeof(string);
        }

        public object? Retrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
        {
            return string.IsNullOrEmpty(keyValuePair.Value) ? null : keyValuePair.Value;
        }
    }
}
