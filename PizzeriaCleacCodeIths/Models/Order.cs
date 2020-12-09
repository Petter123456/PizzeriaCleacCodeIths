using System.Collections.Generic;

namespace PizzeriaCleacCodeIths.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<Pizzas> Pizzas { get; set; }
        public List<ExtraIngredients> ExtraIngredients { get; set; }
        public List<Drinks> Drinks { get; set; }
        public bool Approved { get; set; } = false; 
    }
}
