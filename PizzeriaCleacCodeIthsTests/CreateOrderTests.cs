using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzeriaCleacCodeIths.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using PizzeriaCleacCodeIths.Controllers;
using PizzeriaCleacCodeIths.Data.Menu;
using PizzeriaCleacCodeIths.Dto;
using PizzeriaCleacCodeIths.Models;
using PizzeriaCleacCodeIths.PricesCalculation;

namespace PizzeriaCleacCodeIths.Orders.Tests
{
    [TestClass()]
    public class CreateOrderTests
    {
        [TestMethod()]
        public void HandleRequest_should_only_return_items_on_menu()
        {
            //Arrange
            var menu = new Menu();
            var validate = new Validate(menu);
            var calculatePrice = new CalculateOrderPrice();
            var sut = new Order(calculatePrice,menu,validate);
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
            //  Det är möjligt att bara beställa läsk, men det behövs en grundpizza för att få beställa extra tillbehör

            // lista med bara ej klara orders 

            //create 
            //edit
            //Delete 
            // Skriv in design patters i readme 

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
    }
}