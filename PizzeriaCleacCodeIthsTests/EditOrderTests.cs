using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper.Configuration.Conventions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzeriaCleacCodeIths.Data.Menu;
using PizzeriaCleacCodeIths.Models;
using PizzeriaCleacCodeIths.Orders;
using PizzeriaCleacCodeIths.PricesCalculation;

namespace PizzeriaCleacCodeIthsTests
{
    [TestClass()]
    public class EditOrderTests
    {
        [TestMethod()]
        public void ChangeOrderRequest_should_only_approve_order_if_OrderRequestInput_is_null()
        {
            //Arrange
            var menu = new Menu();
            var validate = new Validate(menu);
            var calculatePrice = new CalculateOrderPrice();
            var sut = new Order(calculatePrice, menu, validate);
            var orderRequest = new OrderRequestModel()
            {
                Drinks = null,
                Pizzas = null,
                ExtraIngredients = null
            };
            var orderDto = sut.orderDto;
            //Act
            var actual = sut.ChangeOrderRequest(new Guid(),orderRequest,true);
            //Assert
            actual.Approved.Should().BeTrue();
        }
    }
}
