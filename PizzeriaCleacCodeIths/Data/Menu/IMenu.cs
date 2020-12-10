using PizzeriaCleacCodeIths.Models;
using System.Collections.Generic;

namespace PizzeriaCleacCodeIths.Data
{
    public interface IMenu
    {
        List<Order> GetListOfOrders(Order order);
        Dictionary<string, int> Prices { get; }
        Dictionary<string,string> PizzasWithIngredients { get; }

        Dictionary<string, int> ExtraIngredientsWithPrices { get; }
        Dictionary<string, int> DrinksWithPrices { get; }


    }
}