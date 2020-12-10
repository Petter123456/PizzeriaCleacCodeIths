using PizzeriaCleacCodeIths.Models;
using System;
using System.Collections.Generic;

namespace PizzeriaCleacCodeIths.Repositories
{
    public interface IOrder
    {
        List<Models.OrderDto> HandleRequest(PizzaOrderRequest placedOrder, DrinksOrderRequest placedDrinksOrder, ExtraIngredientsOrderRequest placedExtraIngredients);
        OrderDto ValidateOrderChangeRequest(Guid id, PizzaOrderRequest pizzas, DrinksOrderRequest drinks, ExtraIngredientsOrderRequest extraIngredients, bool orderHandled);
    }
}