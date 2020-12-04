using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookStore.Products;

namespace BookStore.Delivery
{
    class DeliveryCalculator : IDeliveryCalculator
    {
        private decimal MinimumFreeDeliveryAmount = 1000;
        private decimal DeliveryPrice = 200;

        public decimal GetDeliveryPrice(List<IProduct> items)
        {
            var onlyEBooks = items
                .Where(item => item.IsDelivery == true)
                .Count() == 0;

            if (onlyEBooks) 
                return 0;            

            var sum = items.Sum(item => item.Price);
            if (sum >= MinimumFreeDeliveryAmount)
                return 0;
            return DeliveryPrice;
        }
    }
}
