using System.Collections.Generic;
using BookStore.Actions;
using BookStore.Delivery;
using BookStore.Promos;
using System.Linq;
using BookStore.Products;

namespace BookStore.Cart
{
    class ShoppingCart
    {
        private IDeliveryCalculator _deliveryCalculator;
        private IActionProvider _actionProvider;

        public ShoppingCart(IDeliveryCalculator deliveryCalculator, IActionProvider actionProvider)
        {
            _deliveryCalculator = deliveryCalculator;
            _actionProvider = actionProvider;
        }

        public decimal GetTotalPrice(List<IProduct> items, List<IPromo> promoCodes)
        {
            var order = new Order(items);
            bool isDelivery = order.OrderItems
                .Where(item => item.Item.IsDelivery == true)
                .Count() != 0;
            order.DeliveryPrice = isDelivery ? _deliveryCalculator.GetDeliveryPrice(items) : 0;

            promoCodes.ForEach(p => p.ApplyPromo(order));
            _actionProvider.GetActiveActions().ForEach(a => a.ApplyAction(order));

            return order.GetTotalFinalPrice();
        }
    }
}