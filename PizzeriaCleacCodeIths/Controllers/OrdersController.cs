using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzeriaCleacCodeIths.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using PizzeriaCleacCodeIths.Data.Menu;
using PizzeriaCleacCodeIths.Dto;
using PizzeriaCleacCodeIths.Orders;

namespace PizzeriaCleacCodeIths.Controllers
{
    public class OrdersController : Controller
    {
        public List<OrderDto> orders;
        public OrderDto order;

        public IOrder Order { get; }
        public IMenu _Menu { get; }

        public OrdersController(IOrder order, IMenu menu)
        {
            Order = order;
            _Menu = menu;
        }

        // GET: Orders
        /// <summary>Returns a list of non-approved orders in the system
        /// </summary>
        [HttpGet ("Get")]
        [ProducesResponseType(typeof(List<OrderDto>), (int)HttpStatusCode.OK)]
        public IActionResult Index()
        {
            try
            {
                orders = _Menu.GetListOfOrders();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            return orders != null ? Ok(orders) : Result(HttpStatusCode.NoContent, "No Orders has been placed");
        }

        private static IActionResult Result(HttpStatusCode statusCode, string reason) => new ContentResult
        {
            ContentType = $"{reason},   Status Code: {(int)statusCode} {statusCode}",
            Content = $"{reason},  Status Code: {(int)statusCode} {statusCode}",
            StatusCode = (int)statusCode,
        };


        // POST: Orders/Create
        /// <summary>Creates a new order in the system.
        /// Only accepts Items from the menu, the menu is:
        /// Pizzas: margarita,hawaii,kebabpizza,cuatrostagioni.
        /// Drinks:cocacola,fanta,sprite.
        /// Extra Ingredientsskinka,ananas,champinjoner,lök,kebabsås,räkor,musslor,kronärtskocka,kebab,koriander.
        /// </summary>
        [HttpPost("Create")]
        [ProducesResponseType(typeof(List<OrderDto>), (int)HttpStatusCode.OK)]
        public IActionResult Create(OrderRequestModel orderRequestModel)
        {
            try
            {
                orders = Order.HandleRequest(orderRequestModel);
            }
            catch (ArgumentException e)
            {
                return Result(HttpStatusCode.BadRequest, e.Message);
            }
            catch (NullReferenceException e)
            {
                return Result(HttpStatusCode.NoContent, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

            return Ok(orders); 
        }

        // POST: Orders/Edit/5
        /// <summary>Modifies an exisiting order in the system.
        /// If the order status of the order is to be changed leave pizzas, drinks and extra ingredients blank. 
        /// </summary>
        [HttpPut ("Edit")]
        [ProducesResponseType(typeof(OrderDto), (int)HttpStatusCode.OK)]
        public IActionResult Edit(Guid id, OrderRequestModel orderRequestModel, bool orderHandled)
        {
            try
            {
                order = Order.ChangeOrderRequest(id, orderRequestModel, orderHandled);
            }
            catch (ArgumentException e)
            {
                return Result(HttpStatusCode.BadRequest, e.Message);
            }
            catch (NullReferenceException e)
            {
                return Result(HttpStatusCode.NoContent, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            return order != null ? Ok(order) : Result(HttpStatusCode.NoContent, "Please enter valid options from the menu");
        }

        // POST: Orders/Delete/5
        /// <summary>Deletes an order from the system. 
        /// </summary>
        [HttpDelete ("Delete")]
        [ProducesResponseType(typeof(List<OrderDto>), (int)HttpStatusCode.OK)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                orders = _Menu.DeleteOrderDto(id);
            }
            catch (ArgumentException e)
            {
                return Result(HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            return orders.Any() ? Ok(orders) : Result(HttpStatusCode.NoContent, "order was deleted");
        }
    }
}
