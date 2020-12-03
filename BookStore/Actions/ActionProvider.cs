using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Actions
{
    class ActionProvider : IActionProvider
    {
        public List<IAction> GetActiveActions()
        {
            var actions = new List<IAction>
            {
                new FreeEBookFor2PapersAction(),
                new TenPercentForThreeJournalAction()
            };           

            return actions;
        }
    }
}
