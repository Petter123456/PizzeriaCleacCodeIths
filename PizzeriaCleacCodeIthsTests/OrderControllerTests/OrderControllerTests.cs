using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzeriaCleacCodeIths.Controllers;
using PizzeriaCleacCodeIths.Data.Menu;
using PizzeriaCleacCodeIths.Dto;
using PizzeriaCleacCodeIths.Models;
using PizzeriaCleacCodeIths.Orders;
using PizzeriaCleacCodeIths.PricesCalculation;

namespace PizzeriaCleacCodeIthsTests
{
    [TestClass()]

    public class OrderControllerTests
    {
        [TestMethod()]
        public void Create_Should_return_200_ok()
        {
            var orderRequest = new OrderRequestModel()
            {
                Pizzas = new List<string>()
                {
                    "margarita"
                },
                Drinks = new List<string>()
                {
                    "cocacola"
                },
                ExtraIngredients = new List<string>()
                {
                    "kronärtskocka"
                }
            };

            //Arrange
            var menu = new Menu();
            var validate = new Validate(menu);
            var calculatePrice = new CalculateOrderPrice();
            var order = new Order(calculatePrice, menu, validate);

            var controller = new  OrdersController(order,menu);
            
            var actual = controller.Create(orderRequest);

            var contentResult = actual.As<OkObjectResult>();

            actual.Should().Be(contentResult);
        }
    }
}
