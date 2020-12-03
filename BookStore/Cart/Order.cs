using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using BookStore.Products;

namespace BookStore.Cart
{
    class Order
    {
        private readonly List<OrderItem> _orderItems;

        public ReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();
        public decimal DeliveryPrice { get; set; }
        public decimal CommonDiscount { get; set; }

        public Order(List<IProduct> items)
        {
            _orderItems = items
                .Select(item => new OrderItem(item))
                .ToList();
        }

        public decimal GetTotalFinalPrice()
        {
            return Math.Max(_orderItems.Sum(ob => ob.FinalPrice) + DeliveryPrice - CommonDiscount, 0);
        }
    }
}

