using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaCleacCodeIths.Dto
{
    public class OrderIngredientsDto
    {
        public Dictionary<string,string> PizzasWithIngredients { get; set; }
        public int OrderPrice { get; set; }
    }
}
