﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzeriaCleacCodeIths.Models;
using PizzeriaCleacCodeIths.Repositories;

namespace PizzeriaCleacCodeIths.Controllers
{
    public class OrdersController : Controller
    {
        public IPlaceOrder _placeOrder { get; }
        public IMapper _mapper { get; }

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
        public ActionResult Create(string[] pizza, string[] drinks, string[] extras)
        {
            try
            {
                var pizzas = _mapper.Map(pizza, new Pizzas());
                var beverages = _mapper.Map(drinks, new Drinks());
                var extraIngredients = _mapper.Map(extras, new ExtraIngredients());
                _placeOrder.ReciveOrder(pizzas, beverages, extraIngredients);

                return Ok(); 
            }
            catch
            {
                return View();
            }
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