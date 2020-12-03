using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Products;

namespace BookStore.Cart
{
    class OrderItem
    {
        public IProduct Item { get; }
        public decimal InitialPrice => Item.Price;
        public decimal Discount { get; set; }
        public bool HasPromoApplied { get; set; }
        public decimal FinalPrice => Math.Max(InitialPrice - Discount, 0);

        public OrderItem(IProduct item)
        {
            Item = item;
        }
    }
}
