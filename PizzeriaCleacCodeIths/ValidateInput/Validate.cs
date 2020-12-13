using System;
using System.Collections.Generic;
using System.Linq;
using PizzeriaCleacCodeIths.Data.Menu;
using PizzeriaCleacCodeIths.Models;

namespace PizzeriaCleacCodeIths.Orders
{
    public class Validate : IValidate
    {
        private readonly IMenu _menu;
        public List<ExtraIngredientsModel> ValidExtraIngredients = new List<ExtraIngredientsModel>();
        public List<PizzaModel> ValidPizzas = new List<PizzaModel>();
        public List<DrinksModel> ValidDrinks = new List<DrinksModel>();

        public Validate(IMenu menu)
        {
            _menu = menu;
        }

        public List<ExtraIngredientsModel> ValidateExtraIngredients(List<string> extraIngredients)
        {

            foreach (var product in extraIngredients)
            {
                if (String.IsNullOrWhiteSpace(product) ||
                    !_menu.ExtraIngredientsWithPrices
                        .Any(p => p.Key
                            .Contains(product
                                .ToLower()
                                .Trim()))
                )
                {
                    throw new ArgumentException("Invalid input for Extra Ingredients. Ingredients is not availible on _menu");
                }

                var extraIngredient = new ExtraIngredientsModel()
                {
                    Name = product.ToLower().Trim(),
                    Price = _menu.Prices[product.ToLower().Trim()],
                };
                ValidExtraIngredients.Add(extraIngredient);
            }
            return ValidExtraIngredients;
        }

        public List<DrinksModel> ValidateDrinks(List<string> drinks)
        {

            foreach (var product in drinks)
            {
                if (String.IsNullOrWhiteSpace(product) ||
                    !_menu.DrinksWithPrices
                        .Any(p => p.Key
                            .Equals(product
                                .ToLower()
                                .Trim()))
                )
                {
                    throw new ArgumentException("Invalid input for drinks. Drink is not availible on _menu");
                }

                var drink = new DrinksModel()
                {
                    Name = product.ToLower().Trim(),
                    Price = _menu.Prices[product.ToLower().Trim()],
                };
                ValidDrinks.Add(drink);
            }
            return ValidDrinks;
        }

        public List<PizzaModel> ValidatePizza(List<string> pizzas)
        {
            foreach (var product in pizzas)
            {
                if (String.IsNullOrWhiteSpace(product) ||
                    !_menu.PizzasWithIngredients
                        .Any(p => p.Key
                            .Equals(product
                                .ToLower()
                                .Trim()))
                )
                {
                    throw new ArgumentException("Invalid input for pizza. PizzaModel is not availible on _menu");
                }

                var pizza = new PizzaModel()
                {
                    Name = product.ToLower().Trim(),
                    Price = _menu.Prices[product.ToLower().Trim()],
                    Ingredients = _menu.PizzasWithIngredients[product.ToLower().Trim()]
                };
                ValidPizzas.Add(pizza);
            }
            return ValidPizzas;
        }
    }
}