using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzeriaCleacCodeIths.Data.Menu;
using PizzeriaCleacCodeIths.Dto;
using PizzeriaCleacCodeIths.Models;
using PizzeriaCleacCodeIths.PricesCalculation;

namespace PizzeriaCleacCodeIths.Orders.Tests
{
    [TestClass()]
    public class OrderTests
    {
        [TestMethod()]
        public void HandleRequest_should_only_return_items_on_menu()
        {
            //Arrange
            var menu = new Menu();
            var validate = new Validate(menu);
            var calculatePrice = new CalculateOrderPrice();
            var sut = new Order(calculatePrice, menu, validate);
            var orderRequest = new OrderRequestModel()
            {
                Pizzas = new List<string>()
                {
                    "bananpizza"
                }
            };

            //Act
            Action actual = () => sut.HandleRequest(orderRequest);
            //Assert
            actual.Should().Throw<ArgumentException>();
        }

        [TestMethod()]
        public void HandleRequest_should_not_accept_only_extra_ingredients()
        {
            //Arrange
            var menu = new Menu();
            var validate = new Validate(menu);
            var calculatePrice = new CalculateOrderPrice();
            var sut = new Order(calculatePrice, menu, validate);
            var orderRequest = new OrderRequestModel()
            {
                ExtraIngredients = new List<string>()
                {
                    "kronärtskocka"
                }
            };

            //Act
            Action actual = () => sut.HandleRequest(orderRequest);
            //Assert
            actual.Should().Throw<NullReferenceException>();

        }

        [TestMethod()]
        public void HandleRequest_should_accept_only_pizza()
        {
            //Arrange
            var menu = new Menu();
            var validate = new Validate(menu);
            var calculatePrice = new CalculateOrderPrice();
            var sut = new Order(calculatePrice, menu, validate);
            var orderRequest = new OrderRequestModel()
            {
                Pizzas = new List<string>()
                {
                    "margarita"
                }
            };

            //Act
            Action actual = () => sut.HandleRequest(orderRequest);
            //Assert
            actual.Should().NotBeNull();

        }
        [TestMethod()]
        public void HandleRequest_should_accept_only_drinks()
        {
            //Arrange
            var menu = new Menu();
            var validate = new Validate(menu);
            var calculatePrice = new CalculateOrderPrice();
            var sut = new Order(calculatePrice, menu, validate);
            var orderRequest = new OrderRequestModel()
            {
                Drinks = new List<string>()
                {
                    "cocacola"
                }
            };

            //Act
            Action actual = () => sut.HandleRequest(orderRequest);
            //Assert
            actual.Should().NotBeNull();

        }
        [TestMethod()]
        public void OrderDto_should_only_change_approved_if_orderRequest_is_null()
        {
            //Arrange
            var menu = new Menu();
            var validate = new Validate(menu);
            var calculatePrice = new CalculateOrderPrice();
            var sut = new Order(calculatePrice, menu, validate);
            var orderId = new Guid();
            var orderDto = new OrderDto()
            {
                Id = orderId,
                TotalPrice = 85,
                Pizzas = new List<PizzaModel>()
                {
                    new PizzaModel()
                    {
                        Name = "margarita"
                    }
                },
                Approved = false
            };

            Menu.Orders = new List<OrderDto>();
            Menu.Orders.Add(orderDto);
            var orderRequest = new OrderRequestModel()
            {
                Drinks = null,
                Pizzas = null,
                ExtraIngredients = null
            };
            //Act
            var actual = sut.ChangeOrderRequest(orderId, orderRequest, true);
            //Assert
            actual.Approved.Should().BeTrue();
            actual.Should().Be(orderDto);
        }

        [TestMethod()]
        public void OrderDto_should_change_all_other_items_if_orderRequest_is_not_null()
        {
            //Arrange
            var menu = new Menu();
            var validate = new Validate(menu);
            var calculatePrice = new CalculateOrderPrice();
            var sut = new Order(calculatePrice, menu, validate);
            var orderId = new Guid();
            var orderDto = new OrderDto()
            {
                Id = orderId,
                TotalPrice = 85,
                Pizzas = new List<PizzaModel>()
                {
                    new PizzaModel()
                    {
                        Name = "margarita"
                    }
                },
                Approved = false
            };

            Menu.Orders = new List<OrderDto>();
            Menu.Orders.Add(orderDto);
            var orderRequest = new OrderRequestModel()
            {
                Drinks = null,
                Pizzas = new List<string>()
                {
                    "hawaii"
                },
                ExtraIngredients = null
            };
            //Act
            var actual = sut.ChangeOrderRequest(orderId, orderRequest, false);
            //Assert
            actual.Approved.Should().BeFalse();
            actual.Pizzas.First().Name.Should().Be(orderRequest.Pizzas.First());
            actual.Pizzas.First().Ingredients.Should().NotBeNull();
        }
    }
}
