using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzeriaCleacCodeIths.Data.Menu;
using PizzeriaCleacCodeIths.Dto;
using PizzeriaCleacCodeIths.Models;
using PizzeriaCleacCodeIths.PricesCalculation;

namespace PizzeriaCleacCodeIths.Orders.Tests
{
    [TestClass()]
    public class CalculateOrderPriceTests 
    {
        [TestMethod()]
        public void CalculatePrice_should_return_correct_price()
        {
            //Arrange
            var calculatePrice = new CalculateOrderPrice();
            var orderDto = new OrderDto()
            {
                Id = Guid.NewGuid(),
                TotalPrice = 85,
                Pizzas = new List<PizzaModel>()
                {
                    new PizzaModel()
                    {
                        Name = "margarita"
                    },
                    new PizzaModel()
                    {
                        Name = "hawaii"
                    }
                },
                ExtraIngredients = new List<ExtraIngredientsModel?>()
                {
                    new ExtraIngredientsModel()
                    {
                        Name = "kronärtskocka"
                    },
                    new ExtraIngredientsModel()
                    {
                        Name = "kronärtskocka"
                    }
                },
                Drinks = new List<DrinksModel>()
                {
                    new DrinksModel()
                    {
                        Name = "cocacola"
                    },
                    new DrinksModel()
                    {
                        Name = "sprite"
                    }
                }, 
                Approved = false
            };

            var pizzas = new List<PizzaModel>()
            {
                new PizzaModel()
                {
                    Name = "margarita"
                },
                new PizzaModel()
                {
                    Name = "hawaii"
                }
            };

            var drinks = new List<DrinksModel>()
            {
                new DrinksModel()
                {
                    Name = "cocacola"
                },
                new DrinksModel()
                {
                    Name = "sprite"
                }
            };

            var extra = new List<ExtraIngredientsModel>()
            {
                new ExtraIngredientsModel()
                {
                    Name = "kronärtskocka"
                },
                new ExtraIngredientsModel()
                {
                    Name = "kronärtskocka"
                }
            };

            var pizzaPrice = calculatePrice.CalculatePizzaPrice(pizzas);
            var drinkPrice = calculatePrice.CalculateDrinksPrice(drinks);
            var extraPrice = calculatePrice.CalculateExtraIngredientsPrice(extra);

            //act
            var actual = calculatePrice.CalculateTotalOrderPrice(orderDto);
            //assert
            actual.Should().Be(pizzaPrice + drinkPrice + extraPrice);
        }
    }
}