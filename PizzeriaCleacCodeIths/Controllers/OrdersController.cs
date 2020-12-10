using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private List<Order> order;

        public IPlaceOrder _placeOrder { get; }
        public IMapper _mapper { get; }
        public List<Order> EmptyResult { get; private set; }

        public OrdersController(IPlaceOrder placeOrder, IMapper mapper)
        {
            _placeOrder = placeOrder;
            _mapper = mapper;
        }

        // GET: Orders
        [HttpGet ("Get")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost ("Create")]
        [ProducesResponseType(typeof(List<Order>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Create(PlacedPizzaOrder placedPizzaOrder, PlacedDrinksOrder placedDrinksOrder, PlacedExtraIngredientsOrder placedExtraIngredients)
        {
            try
            {
               order = _placeOrder.ReciveOrder(placedPizzaOrder, placedDrinksOrder, placedExtraIngredients);         
            }
            catch (ArgumentException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            return order.Any() ? Ok(order) : (IActionResult) StatusCode(StatusCodes.Status204NoContent);
        }

        // POST: Orders/Edit/5
        [HttpPut ("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Order order)
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

        // POST: Orders/Delete/5
        [HttpDelete ("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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

        [HttpPost("Approve")]
        [ValidateAntiForgeryToken]
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
