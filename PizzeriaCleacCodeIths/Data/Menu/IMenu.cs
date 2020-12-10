using PizzeriaCleacCodeIths.Models;
using System;
using System.Collections.Generic;

namespace PizzeriaCleacCodeIths.Data
{
    public interface IMenu
    {
        List<OrderDto> GetListOfOrders(OrderDto order);
        OrderDto EditOrderDto(Guid id, OrderDto orderDtoChanged);
        List<OrderDto> DeleteOrderDto(Guid id);

        Dictionary<string, int> Prices { get; }
        Dictionary<string,string> PizzasWithIngredients { get; }
        Dictionary<string, int> ExtraIngredientsWithPrices { get; }
        Dictionary<string, int> DrinksWithPrices { get; }
    }
}