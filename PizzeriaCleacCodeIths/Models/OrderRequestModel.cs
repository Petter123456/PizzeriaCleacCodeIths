using System.Collections.Generic;

namespace PizzeriaCleacCodeIths.Models
{
    public class OrderRequestModel
    {
        public List<string> Pizzas { get; set; }
        public List<string> ExtraIngredients { get; set; }
        public List<string> Drinks { get; set; }
    }
}
