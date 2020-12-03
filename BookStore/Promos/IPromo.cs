using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Cart;

namespace BookStore.Promos
{
    interface IPromo
    {
        void ApplyPromo(Order order);
    }
}
