using PizzeriaCleacCodeIths.Data;
using PizzeriaCleacCodeIths.Models;
using PizzeriaCleacCodeIths.Observers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzeriaCleacCodeIths.Repositories
{
    public class PlaceOrder : IPlaceOrder
    {
        private List<Pizza> validPizzas = new List<Pizza>();
        private List<Drinks> validDrinks = new List<Drinks>();
        private List<ExtraIngredients> validExtraIngredients = new List<ExtraIngredients>();
        private List<Pizza> pizzas;
        private List<Drinks> drinks;
        private List<ExtraIngredients> extraIngredients;
        public Order order = new Order();

        public Order ReciveOrder(PlacedPizzaOrder placedPizzaOrder, PlacedDrinksOrder placedDrinksOrder, PlacedExtraIngredientsOrder placedExtraIngredientsOrder)
        {
            pizzas = ValidatePizza(placedPizzaOrder);
            drinks = ValidateDrinks(placedDrinksOrder);
            extraIngredients = ValidateExtraIngredients(placedExtraIngredientsOrder);

            order.Pizzas = pizzas;
            order.Drinks = drinks;
            order.ExtraIngredients = extraIngredients;

            return order;
            //var x = Menu.Pizzas.Any(x => x.Key == order.);
            //ICalculatePrice calculatePrice = new CalculatePrice(); 
            //var observer = new Observer(order,calculatePrice);
            //observer.update(order);

        }

        private List<ExtraIngredients> ValidateExtraIngredients(PlacedExtraIngredientsOrder placedExtraIngredientsOrder)
        {
            foreach (var product in placedExtraIngredientsOrder.ExtraIngredientsName)
            {
                if (!Menu.ExtraIngredients.Any(p => p.Key.Contains(product)))
                {
                    throw new ArgumentException("Wrong input");
                }
                else
                {
                    var extraIngredient = new ExtraIngredients()
                    {
                        Name = product,
                        Price = Menu.Prices[product],
                    };
                    validExtraIngredients.Add(extraIngredient);
                }
            }
            return validExtraIngredients;
        }

        private List<Drinks> ValidateDrinks(PlacedDrinksOrder placedDrinksOrder)
        {
            foreach (var product in placedDrinksOrder.DrinksName)
            {
                if (!Menu.Drinks.Any(p => p.Key.Equals(product)))
                {
                    throw new ArgumentException("Wrong input");
                }
                else
                {
                    var drink = new Drinks()
                    {
                        Name = product,
                        Price = Menu.Prices[product],
                    };
                    validDrinks.Add(drink);
                }
            }
            return validDrinks;
        }

        public List<Pizza> ValidatePizza(PlacedPizzaOrder placedOrder)
        {
            foreach (var product in placedOrder.PizzasName)
            {
                if (!Menu.Pizzas.Any(p => p.Key.Equals(product)))
                {
                    throw new ArgumentException("Wrong input");
                }
                else
                {
                    var pizza = new Pizza()
                    {
                        Name = product,
                        Price = Menu.Prices[product],
                        Ingredients = Menu.Pizzas[product]
                    };
                    validPizzas.Add(pizza);
                }
            }
            return validPizzas;
        }


    }
}
