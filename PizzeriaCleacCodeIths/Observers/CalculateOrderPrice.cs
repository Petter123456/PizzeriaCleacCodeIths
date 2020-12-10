using PizzeriaCleacCodeIths.Models;
using PizzeriaCleacCodeIths.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaCleacCodeIths.Observers
{
    public class CalculateOrderPrice : ICalculateOrderPrice
    {
        private int totalPizzaPrice;
        private int totalDrinksPrice;
        private int totalExtraIngredientsPrice;
        private int totalOrderPrice;

        public Models.OrderDto Order { get; }

        public CalculateOrderPrice()
        {
           
        }
        public int CalculateTotalOrderPrice(Models.OrderDto order)
        {
            var pizzasPrice = CalculatePizzaPrice(order.Pizzas);
            var drinksPrice = CalculateDrinksPrice(order.Drinks);
            var extraIngredientsPrice = CalculateExtraIngredientsPrice(order.ExtraIngredients);

            totalOrderPrice = pizzasPrice + drinksPrice + extraIngredientsPrice;
            
            return totalOrderPrice; 
        }

        public int CalculatePizzaPrice(List<Pizza> pizzas)
        {
            foreach (var pizza in pizzas)
            {
                totalPizzaPrice += pizza.Price;
            }
            return totalPizzaPrice; 
        }

        public int CalculateDrinksPrice(List<Drinks> drinks)
        {
            foreach (var drink in drinks)
            {
                totalDrinksPrice += drink.Price;
            }
            return totalDrinksPrice;
        }
        public int CalculateExtraIngredientsPrice(List<ExtraIngredients> extraIngredients)
        {
            foreach (var extra in extraIngredients)
            {
                totalExtraIngredientsPrice += extra.Price;
            }
            return totalExtraIngredientsPrice;
        }
    }
}
