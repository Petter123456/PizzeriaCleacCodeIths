using System;
using System.Collections.Generic;
using PizzeriaCleacCodeIths.Models;

namespace PizzeriaCleacCodeIths.Dto
{
    public class OrderDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public List<PizzaModel> Pizzas { get; set; }
        public List<ExtraIngredientsModel?> ExtraIngredients { get; set; }
        public List<DrinksModel> Drinks { get; set; }
        public int TotalPrice { get; set; }
        public bool Approved { get; set; } = false; 
    }
}
