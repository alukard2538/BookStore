using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BookStore.Cart;
using BookStore.Products;

namespace BookStore.Promos
{
    class FreeBookPromo : IPromo
    {
        private IProduct _freeProduct;

        public FreeBookPromo(IProduct freeproduct)
        {
            _freeProduct = freeproduct;
        }

        public void ApplyPromo(Order order)
        {
            var foundProduct = order.OrderItems
                .Where(oi => !oi.HasPromoApplied)
                .FirstOrDefault(oi => Equals(oi.Item, _freeProduct));
            if (foundProduct != null)
            {
                foundProduct.Discount += foundProduct.InitialPrice;
                foundProduct.HasPromoApplied = true;
            }
        }
    }
}
