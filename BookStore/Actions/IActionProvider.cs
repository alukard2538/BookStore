using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Actions
{
    interface IActionProvider
    {
        List<IAction> GetActiveActions();
    }
}
