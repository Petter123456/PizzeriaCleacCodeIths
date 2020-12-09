using PizzeriaCleacCodeIths.Models;

namespace PizzeriaCleacCodeIths.Repositories
{
    public interface IPlaceOrder
    {
        void ReciveOrder(Pizzas pizza, Drinks drinks, ExtraIngredients extras);
    }
}