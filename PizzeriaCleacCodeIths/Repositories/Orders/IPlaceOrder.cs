using PizzeriaCleacCodeIths.Models;
using System.Collections.Generic;

namespace PizzeriaCleacCodeIths.Repositories
{
    public interface IPlaceOrder
    {
        List<Order> ReciveOrder(PlacedPizzaOrder placedOrder, PlacedDrinksOrder placedDrinksOrder, PlacedExtraIngredientsOrder placedExtraIngredients);
    }
}