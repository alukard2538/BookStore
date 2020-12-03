using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Products;

namespace BookStore.Delivery
{
    interface IDeliveryCalculator
    {
        decimal GetDeliveryPrice(List<IProduct> items);
    }
}
