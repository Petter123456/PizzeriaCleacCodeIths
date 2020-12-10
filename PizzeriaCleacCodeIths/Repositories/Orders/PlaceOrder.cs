using PizzeriaCleacCodeIths.Data;
using PizzeriaCleacCodeIths.Models;
using PizzeriaCleacCodeIths.Observers;
using PizzeriaCleacCodeIths.Repositories.CalculatePrice;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzeriaCleacCodeIths.Repositories
{
    public class PlaceOrder : IPlaceOrder , IAcceptVisitor
    {
        private List<Pizza> validPizzas = new List<Pizza>();
        private List<Drinks> validDrinks = new List<Drinks>();
        private List<ExtraIngredients> validExtraIngredients = new List<ExtraIngredients>();
        public Order order = new Order();
        private List<Order> allOrders;

        public ICalculateOrderPrice _calculateOrderPrice { get; }
        public IMenu _menu { get; }

        public PlaceOrder(ICalculateOrderPrice calculateOrderPrice, IMenu menu)
        {
            _calculateOrderPrice = calculateOrderPrice;
            _menu = menu;
        }

        public List<Order> ReciveOrder(PlacedPizzaOrder placedPizzaOrder, PlacedDrinksOrder placedDrinksOrder, PlacedExtraIngredientsOrder placedExtraIngredientsOrder)
        {
           var pizzas = ValidatePizza(placedPizzaOrder);
           var drinks = ValidateDrinks(placedDrinksOrder);
           var extraIngredients = ValidateExtraIngredients(placedExtraIngredientsOrder);

            order.Pizzas = pizzas;
            order.Drinks = drinks;
            order.ExtraIngredients = extraIngredients;
            order.TotalPrice = GetOrderPrice(_calculateOrderPrice);

            allOrders = _menu.GetListOfOrders(order);
            
            return allOrders;
        }

        private List<ExtraIngredients> ValidateExtraIngredients(PlacedExtraIngredientsOrder placedExtraIngredientsOrder)
        {
            foreach (var product in placedExtraIngredientsOrder.ExtraIngredientsName)
            {
                if (!_menu.ExtraIngredientsWithPrices.Any(p => p.Key.Contains(product)))
                {
                    throw new ArgumentException("Invalid input for Extra Ingredients. Ingredients is not availible on menu");
                }
                else
                {
                    var extraIngredient = new ExtraIngredients()
                    {
                        Name = product,
                        Price = _menu.Prices[product],
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
                if (!_menu.DrinksWithPrices.Any(p => p.Key.Equals(product)))
                {
                    throw new ArgumentException("Invalid input for drinks. Drink is not availible on menu");
                }
                else
                {
                    var drink = new Drinks()
                    {
                        Name = product,
                        Price = _menu.Prices[product],
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
                if (!_menu.PizzasWithIngredients.Any(p => p.Key.Equals(product)))
                {
                    throw new ArgumentException("Invalid input for pizza. Pizza is not availible on menu");
                }
                else
                {
                    var pizza = new Pizza()
                    {
                        Name = product,
                        Price = _menu.Prices[product],
                        Ingredients = _menu.PizzasWithIngredients[product]
                    };
                    validPizzas.Add(pizza);
                }
            }
            return validPizzas;
        }

        public int GetOrderPrice(ICalculateOrderPrice calculatePrice)
        {
           return calculatePrice.CalculateTotalOrderPrice(this.order);
        }
    }
}
