using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Products
{
    interface IProduct
    {
        string Name { get; }
        string Author { get;  }
        decimal Price { get; }
        bool IsDelivery { get; }

        public ProductType CheckType();
    }
}

