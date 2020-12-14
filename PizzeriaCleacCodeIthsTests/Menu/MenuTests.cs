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
    public class MenuTests
    {
        [TestMethod()]
        public void IMenu_GetListOfOrders_should_only_return_non_approved_orders()
        {
            //Arrange
            var menu = new Menu();

            var orderDto = new OrderDto()
            {
                Id = new Guid(),
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
            var orderDto2 = new OrderDto()
            {
                Id = new Guid(),
                TotalPrice = 85,
                Pizzas = new List<PizzaModel>()
                {
                    new PizzaModel()
                    {
                        Name = "margarita"
                    }
                },
                Approved = true
            };

            Menu.Orders = new List<OrderDto>();
            Menu.Orders.Add(orderDto);
            Menu.Orders.Add(orderDto2);

            var actual = menu.GetListOfOrders();

            actual.Any(x => x.Approved).Should().BeFalse();
        }

        [TestMethod()]
        public void IMenu_AddToListOfOrders_should_only_return_all_orders()
        {
            //Arrange
            var menu = new Menu();

            var orderDto = new OrderDto()
            {
                Id = new Guid(),
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
            var orderDto2 = new OrderDto()
            {
                Id = new Guid(),
                TotalPrice = 85,
                Pizzas = new List<PizzaModel>()
                {
                    new PizzaModel()
                    {
                        Name = "margarita"
                    }
                },
                Approved = true
            };

            Menu.Orders = new List<OrderDto>();
            Menu.Orders.Add(orderDto);
            Menu.Orders.Add(orderDto2);

            var actual = menu.AddToListOfOrders(orderDto2);

            actual.Count().Should().Be(3); 
        }

        [TestMethod()]
        public void IMenu_DeleteOrderDto_should_throw_exception_if_id_do_not_match()
        {
            //Arrange
            var menu = new Menu();
            var guidOne = Guid.NewGuid();
            var guidTwo = Guid.NewGuid();

            var orderDto = new OrderDto()
            {
                Id = guidTwo,
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

            Action actual = () => menu.DeleteOrderDto(guidOne);

            actual.Should().Throw<ArgumentException>(); 
        }

        [TestMethod()]
        public void IMenu_ApproveOrder_should_throw_exception_if_id_do_not_match()
        {
            //Arrange
            var menu = new Menu();
            var guidOne = Guid.NewGuid();
            var guidTwo = Guid.NewGuid();

            var orderDto = new OrderDto()
            {
                Id = guidTwo,
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

            Action actual = () => menu.ApproveOrder(guidOne, true);

            actual.Should().Throw<ArgumentException>();
        }
    }
}