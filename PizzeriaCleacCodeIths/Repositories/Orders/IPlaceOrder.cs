using PizzeriaCleacCodeIths.Models;

namespace PizzeriaCleacCodeIths.Repositories
{
    public interface IPlaceOrder
    {
        Order ReciveOrder(PlacedPizzaOrder placedOrder, PlacedDrinksOrder placedDrinksOrder, PlacedExtraIngredientsOrder placedExtraIngredients);
    }
}