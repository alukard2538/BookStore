using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Cart;

namespace BookStore.Promos
{
    class AbsoluteDiscountPromo : IPromo
    {
        private readonly int _discount;

        public AbsoluteDiscountPromo(int discount)
        {
            // > 0
            _discount = discount;
        }

        public void ApplyPromo(Order order)
        {
            order.CommonDiscount += _discount;
        }
    }
}
