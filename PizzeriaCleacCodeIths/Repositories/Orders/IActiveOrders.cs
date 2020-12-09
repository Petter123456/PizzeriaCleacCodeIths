using PizzeriaCleacCodeIths.Models;
using System.Collections.Generic;

namespace PizzeriaCleacCodeIths.Repositories.Orders
{
    public interface IActiveOrders
    {
        List<Order> AddUnConfirmedOrder(Order order);
    }
}