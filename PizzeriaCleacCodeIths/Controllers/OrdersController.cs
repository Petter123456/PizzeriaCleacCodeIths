using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzeriaCleacCodeIths.Data;
using PizzeriaCleacCodeIths.Models;
using PizzeriaCleacCodeIths.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PizzeriaCleacCodeIths.Controllers
{
    public class OrdersController : Controller
    {
        private List<Models.OrderDto> orders;
        private List<OrderDto> allOrders;
        private OrderDto order;

        public IOrder _placeOrder { get; }
        public IMapper _mapper { get; }
        public IMenu _menu { get; }
        public List<Models.OrderDto> EmptyResult { get; private set; }

        public OrdersController(IOrder placeOrder, IMenu menu)
        {
            _placeOrder = placeOrder;
            _menu = menu;
        }

        // GET: Orders
        [HttpGet ("Get")]
        [ProducesResponseType(typeof(List<Models.OrderDto>), (int)HttpStatusCode.OK)]
        public IActionResult Index()
        {
            try
            {
                orders = Menu.Orders;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            return orders != null ? Ok(orders) : (IActionResult) Result(HttpStatusCode.NoContent, "No Orders has been placed");
        }

        private static IActionResult Result(HttpStatusCode statusCode, string reason) => new ContentResult
        {
            StatusCode = (int)statusCode,
            Content = $"Status Code: {(int)statusCode}; {statusCode}; {reason}",
            ContentType = "text/plain",
        };

        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost("Create")]
        [ProducesResponseType(typeof(List<OrderDto>), (int)HttpStatusCode.OK)]
        public IActionResult Create(PizzaOrderRequest pizzas, DrinksOrderRequest drinks, ExtraIngredientsOrderRequest ExtraIngredients)
        {
            try
            {
                orders = _placeOrder.HandleRequest(pizzas, drinks, ExtraIngredients);
            }
            catch (ArgumentException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            return orders.Any() ? Ok(orders) : (IActionResult)StatusCode(StatusCodes.Status204NoContent);
        }

        // POST: Orders/Edit/5
        [HttpPut ("Edit")]
        [ProducesResponseType(typeof(OrderDto), (int)HttpStatusCode.OK)]
        public IActionResult Edit(Guid id, PizzaOrderRequest pizzas, DrinksOrderRequest drinks, ExtraIngredientsOrderRequest extraIngredients, bool orderHandled)
        {
            try
            {
                order = _placeOrder.ValidateOrderChangeRequest(id, pizzas, drinks, extraIngredients, orderHandled);
            }
            catch (ArgumentException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            return order != null ? Ok(order) : (IActionResult)StatusCode(StatusCodes.Status204NoContent);

        }

        // POST: Orders/Delete/5
        [HttpDelete ("Delete")]
        [ProducesResponseType(typeof(List<OrderDto>), (int)HttpStatusCode.OK)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                orders = _menu.DeleteOrderDto(id); 
            }
            catch (ArgumentException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            return orders.Any() ? Ok(orders) : (IActionResult)StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpPost("Approve")]
        [ProducesResponseType(typeof(List<OrderDto>), (int)HttpStatusCode.OK)]
        public ActionResult Approve(int id, bool approve)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
