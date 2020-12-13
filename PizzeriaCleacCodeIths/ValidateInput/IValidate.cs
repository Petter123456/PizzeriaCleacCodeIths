using System.Collections.Generic;
using PizzeriaCleacCodeIths.Models;

namespace PizzeriaCleacCodeIths.Orders
{
    public interface IValidate
    {
        List<ExtraIngredientsModel> ValidateExtraIngredients(List<string> extraIngredients);
        List<PizzaModel> ValidatePizza(List<string> pizzas);
        List<DrinksModel> ValidateDrinks(List<string> drinks);
    }
}