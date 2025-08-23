using Reqnroll.Assist;
using Reqnroll.Plugins;
using ReqnrollProject1.Models;

namespace ReqnrollProject1.Utils
{
    public class ClothesSizeComparer : IValueComparer
    {
        public bool CanCompare(object actualValue)
        {
            return actualValue is Products.InternalSize;
        }

        public bool Compare(string expectedValue, object actualValue)
        {
            return (actualValue as Products.InternalSize).InternalName.Equals(expectedValue);
        }
    }
}
