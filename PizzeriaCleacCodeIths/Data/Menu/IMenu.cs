using System;
using System.Collections.Generic;
using PizzeriaCleacCodeIths.Dto;

namespace PizzeriaCleacCodeIths.Data.Menu
{
    public interface IMenu
    {
        List<OrderDto> AddToListOfOrders(OrderDto order);
        List<OrderDto> GetListOfOrders();
        OrderDto EditOrderDto(Guid id, OrderDto orderDtoChanged);
        List<OrderDto> DeleteOrderDto(Guid id);
        Dictionary<string, int> Prices { get; }
        Dictionary<string, string> PizzasWithIngredients { get; }
        Dictionary<string, int> ExtraIngredientsWithPrices { get; }
        Dictionary<string, int> DrinksWithPrices { get; }
        OrderDto ApproveOrder(Guid id, in bool orderHandled);
    }
}