using PizzeriaCleacCodeIths.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaCleacCodeIths.Repositories.Orders
{
    public class ActiveOrders : IActiveOrders
    {
        public List<Order> UnConfirmedOrders = new List<Order>(); 

        public List<Order> AddUnConfirmedOrder(Order order)
        {
            UnConfirmedOrders.Add(order);
            return UnConfirmedOrders; 
        }
    }
}
