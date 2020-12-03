using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Cart;

namespace BookStore.Actions
{
    interface IAction
    {
        void ApplyAction(Order order);
    }
}
