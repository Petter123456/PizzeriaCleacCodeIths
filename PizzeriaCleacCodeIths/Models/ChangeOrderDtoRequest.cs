using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaCleacCodeIths.Models
{
    public class ChangeOrderDtoRequest
    {
        public Guid Id { get; } = Guid.NewGuid();
        public List<Pizza> Pizzas { get; set; }
        public List<ExtraIngredients> ExtraIngredients { get; set; }
        public List<Drinks> Drinks { get; set; }
        public int TotalPrice { get; set; }
        public bool OrderHandled { get; set; } = false;
    }
}
