using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Cart;
using System.Linq;
using BookStore.Products;

namespace BookStore.Actions
{
    class TenPercentForThreeJournalAction : IAction
    {
        public void ApplyAction(Order order)
        {
            var sortedListOfJournals = order.OrderItems
                .Where(oi => !oi.HasPromoApplied)
                .Where(oi => oi.Item is PaperJournal && oi.Item.CheckType() == ProductType.PaperJournal)
                .OrderBy(oj => ((PaperJournal)oj.Item).Year).ThenBy(oj => ((PaperJournal)oj.Item).Month)
                .ToList();

            if (sortedListOfJournals.Count < 1)
                return;            

            List<OrderItem> discountJournals = new List<OrderItem>();
            int count = 0;
            int start = 0;
            for(int i=1; i < sortedListOfJournals.Count(); i++)
            {
                if(((PaperJournal)sortedListOfJournals[i].Item).Month-1 == ((PaperJournal)sortedListOfJournals[i-1].Item).Month)
                {
                    count++;
                }
                else 
                {
                    if (count < 2)
                        count = 0;
                    else
                    {                        
                        for (int j = start; j <= count; j++)
                        {
                            sortedListOfJournals[j].Discount += sortedListOfJournals[j].InitialPrice / 100 * 10;
                            sortedListOfJournals[j].HasPromoApplied = true;
                        }
                        start = count;
                        count = 0;
                    }
                }                    
            }            
        }
    }
}
