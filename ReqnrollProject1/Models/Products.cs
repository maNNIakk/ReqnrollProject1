using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.Models
{
    internal class Products
    {
        

            public int ProductId { get; set; }
            public int Stock { get; set; }
            public int Basket { get; set; }
            public string Message { get; set; } = string.Empty;
        
    }
}
