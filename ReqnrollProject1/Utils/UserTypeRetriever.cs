using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using Reqnroll.Assist;
using ReqnrollProject1.Models;


namespace ReqnrollProject1.Utils
{
    internal class UserTypeRetriever : IValueRetriever
    {
        public bool CanRetrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
        {
            return propertyType == typeof(InternalUserType);
        }
        public object Retrieve(KeyValuePair<string, string> keyValuePair, Type targetType, Type propertyType)
        {
            return keyValuePair.Value.ToLowerInvariant() switch
            {
                "admin" or "administrator" => InternalUserType.Admin,
                "user" => InternalUserType.User,
                "guest" => InternalUserType.Guest,
                _ => InternalUserType.Unknown

            };
        }
    }
}
