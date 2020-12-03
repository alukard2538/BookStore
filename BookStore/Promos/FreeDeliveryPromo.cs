using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Cart;

namespace BookStore.Promos
{
    class FreeDeliveryPromo : IPromo
    {
        public void ApplyPromo(Order order)
        {
            order.DeliveryPrice = 0;
        }
    }
}
