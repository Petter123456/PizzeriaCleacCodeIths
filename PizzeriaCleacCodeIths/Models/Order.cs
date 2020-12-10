using System.Collections.Generic;

namespace PizzeriaCleacCodeIths.Models
{
    public class Order
    {
        public List<Pizza> Pizzas { get; set; }
        public List<ExtraIngredients> ExtraIngredients { get; set; }
        public List<Drinks> Drinks { get; set; }
        public int TotalPrice { get; set; }
        public bool Approved { get; set; } = false; 
    }
}
