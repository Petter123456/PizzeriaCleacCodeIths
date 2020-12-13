using System.Collections.Generic;
using PizzeriaCleacCodeIths.Dto;
using PizzeriaCleacCodeIths.Models;

namespace PizzeriaCleacCodeIths.PricesCalculation
{
    public class CalculateOrderPrice : ICalculateOrderPrice
    {
        private int totalPizzaPrice;
        private int totalDrinksPrice;
        private int totalExtraIngredientsPrice;
        private int totalOrderPrice;
        private int pizzasPrice = 0;
        private int drinksPrice = 0;
        private int extraIngredientsPrice = 0;

        public int CalculateTotalOrderPrice(OrderDto order)
        {
            if (order.Pizzas != null) 
                pizzasPrice = CalculatePizzaPrice(order.Pizzas);

            if (order.Drinks != null)
                drinksPrice = CalculateDrinksPrice(order.Drinks);

            if (order.ExtraIngredients != null)
                extraIngredientsPrice = CalculateExtraIngredientsPrice(order.ExtraIngredients);

            totalOrderPrice = pizzasPrice + drinksPrice + extraIngredientsPrice;
            
            return totalOrderPrice; 
        }

        public int CalculatePizzaPrice(List<PizzaModel> pizzas)
        {
            foreach (var pizza in pizzas)
            {
                totalPizzaPrice += pizza.Price;
            }
            return totalPizzaPrice; 
        }

        public int CalculateDrinksPrice(List<DrinksModel> drinks)
        {
            foreach (var drink in drinks)
            {
                totalDrinksPrice += drink.Price;
            }
            return totalDrinksPrice;
        }
        public int CalculateExtraIngredientsPrice(List<ExtraIngredientsModel> extraIngredients)
        {
            foreach (var extra in extraIngredients)
            {
                totalExtraIngredientsPrice += extra.Price;
            }
            return totalExtraIngredientsPrice;
        }
    }
}
