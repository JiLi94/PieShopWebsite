﻿using PieShopWebsite.Models;

namespace PieShopWebsite.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PieShopDbContext _pieShopDbContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(PieShopDbContext bethanysPieShopDbContext, IShoppingCart shoppingCart)
        {
            _pieShopDbContext = bethanysPieShopDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            //By using ?, you allow the variable to be assigned a null value.
            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    Price = shoppingCartItem.Pie.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _pieShopDbContext.Orders.Add(order);

            _pieShopDbContext.SaveChanges();
        }
    }
}
