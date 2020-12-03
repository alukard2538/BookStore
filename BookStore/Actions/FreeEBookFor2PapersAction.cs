using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Cart;
using System.Linq;
using BookStore.Products;

namespace BookStore.Actions
{
    class FreeEBookFor2PapersAction : IAction
    {
        public void ApplyAction(Order order)
        {
            var twoPaperBooksOneAuthor = order.OrderItems
                .Where(oi => !oi.HasPromoApplied)
                .Where(oi => oi.Item.CheckType() == ProductType.PaperBook)
                .GroupBy(ob => ob.Item.Author)
                .Where(group => group.Count() > 1)
                .ToDictionary(group => group.Key, group => group.Count() / 2);            

            if (twoPaperBooksOneAuthor.Count < 1)
                return;

            var ElBook = order.OrderItems
                .Where(oi => !oi.HasPromoApplied)
                .Where(oi => oi.Item.CheckType() == ProductType.EBook && twoPaperBooksOneAuthor.Keys.Contains(oi.Item.Author))
                .OrderBy(oi => oi.InitialPrice)
                .FirstOrDefault();
            if (ElBook == null)
                return;

            order.OrderItems
                .Where(oi => oi.Item.Author == ElBook.Item.Author)
                .OrderByDescending(oi => oi.InitialPrice)
                .Take(2)
                .ToList()
                .ForEach(oi => oi.HasPromoApplied = true);

            ElBook.HasPromoApplied = true;
            ElBook.Discount = ElBook.InitialPrice;
        }
    }
}
