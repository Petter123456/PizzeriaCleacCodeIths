using PizzeriaCleacCodeIths.Data;
using PizzeriaCleacCodeIths.Models;
using PizzeriaCleacCodeIths.Observers;
using PizzeriaCleacCodeIths.Repositories.CalculatePrice;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzeriaCleacCodeIths.Repositories
{
    public class Order : IOrder, IAcceptVisitor
    {
        private List<Pizza> validPizzas = new List<Pizza>();
        private List<Drinks> validDrinks = new List<Drinks>();
        private List<ExtraIngredients> validExtraIngredients = new List<ExtraIngredients>();
        public Models.OrderDto order = new Models.OrderDto();
        private List<Models.OrderDto> allOrders;

        public ICalculateOrderPrice _calculateOrderPrice { get; }
        public IMenu _menu { get; }

        public Order(ICalculateOrderPrice calculateOrderPrice, IMenu menu)
        {
            _calculateOrderPrice = calculateOrderPrice;
            _menu = menu;
        }

        public List<Models.OrderDto> HandleRequest(PizzaOrderRequest placedPizzaOrder, DrinksOrderRequest placedDrinksOrder, ExtraIngredientsOrderRequest placedExtraIngredientsOrder)
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

        private List<ExtraIngredients> ValidateExtraIngredients(ExtraIngredientsOrderRequest placedExtraIngredientsOrder)
        {
            foreach (var product in placedExtraIngredientsOrder.ExtraIngredientsName)
            {
                if (!_menu.ExtraIngredientsWithPrices.Any(p => p.Key.Contains(product.ToLower().Trim())))
                {
                    throw new ArgumentException("Invalid input for Extra Ingredients. Ingredients is not availible on menu");
                }
                else if (validPizzas.Count() == 0)
                {
                    throw new ArgumentException("Invalid input, you have to order a pizza to order extra ingredients");
                }
                else
                {
                    var extraIngredient = new ExtraIngredients()
                    {
                        Name = product.ToLower().Trim(),
                        Price = _menu.Prices[product.ToLower().Trim()],
                    };
                    validExtraIngredients.Add(extraIngredient);
                }
            }
            return validExtraIngredients;
        }

        private List<Drinks> ValidateDrinks(DrinksOrderRequest placedDrinksOrder)
        {
            foreach (var product in placedDrinksOrder.DrinksName)
            {
                if (!_menu.DrinksWithPrices.Any(p => p.Key.Equals(product.ToLower().Trim())))
                {
                    throw new ArgumentException("Invalid input for drinks. Drink is not availible on menu");
                }
                else
                {
                    var drink = new Drinks()
                    {
                        Name = product.ToLower().Trim(),
                        Price = _menu.Prices[product.ToLower().Trim()],
                    };
                    validDrinks.Add(drink);
                }
            }
            return validDrinks;
        }

        public List<Pizza> ValidatePizza(PizzaOrderRequest placedOrder)
        {
            foreach (var product in placedOrder.PizzasName)
            {
                if (!_menu.PizzasWithIngredients.Any(p => p.Key.Equals(product.ToLower().Trim())))
                {
                    throw new ArgumentException("Invalid input for pizza. Pizza is not availible on menu");
                }
                else
                {
                    var pizza = new Pizza()
                    {
                        Name = product.ToLower().Trim(),
                        Price = _menu.Prices[product.ToLower().Trim()],
                        Ingredients = _menu.PizzasWithIngredients[product.ToLower().Trim()]
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

        public OrderDto ValidateOrderChangeRequest(Guid id, PizzaOrderRequest pizzas, DrinksOrderRequest drinks, ExtraIngredientsOrderRequest extraIngredients, bool orderHandled)
        {
            var pizza = ValidatePizza(pizzas);
            var drink = ValidateDrinks(drinks);
            var extraIngredient = ValidateExtraIngredients(extraIngredients);

            var orderDto = Menu.Orders.Where(order => order.Id == id).SingleOrDefault();

            if (orderDto != null)
            {
                orderDto.Drinks = drink;
                orderDto.Pizzas = pizza;
                orderDto.ExtraIngredients = extraIngredient;
                orderDto.TotalPrice = GetOrderPrice(_calculateOrderPrice);
                orderDto.Approved = orderHandled;

                return _menu.EditOrderDto(id, orderDto);
            }
            else
            {
                throw new ArgumentException("No order with the id you entered was found");
            }

        }
    }
}
