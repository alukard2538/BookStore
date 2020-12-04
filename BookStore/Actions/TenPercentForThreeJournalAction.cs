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
                .OrderBy(oj => ((PaperJournal)oj.Item).DateInMonths)
                .ToList();

            if (sortedListOfJournals.Count < 1)
                return;            

            List<OrderItem> discountJournals = new List<OrderItem>();
            discountJournals.Add(sortedListOfJournals[0]);
            for (int i=1; i < sortedListOfJournals.Count(); i++)
            {
                if(((PaperJournal)sortedListOfJournals[i].Item).DateInMonths - 1 == ((PaperJournal)sortedListOfJournals[i-1].Item).DateInMonths)
                {
                    discountJournals.Add(sortedListOfJournals[i]);
                }                
                else 
                {
                    if (discountJournals.Count < 2)
                    {
                        discountJournals.Clear();
                        discountJournals.Add(sortedListOfJournals[i]);
                    }                        
                    else
                    {                        
                        foreach (OrderItem journal in discountJournals)
                        {
                            journal.Discount += journal.InitialPrice / 100 * 10;
                            journal.HasPromoApplied = true;
                        }
                        discountJournals.Clear();
                    }
                }
                if (i == sortedListOfJournals.Count() - 1 && discountJournals.Count > 2) 
                {
                    foreach (OrderItem journal in discountJournals)
                    {
                        journal.Discount += journal.InitialPrice / 100 * 10;
                        journal.HasPromoApplied = true;
                    }
                    discountJournals.Clear();
                }
            }            
        }
    }
}
