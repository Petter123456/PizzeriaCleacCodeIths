using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaCleacCodeIths.Data
{
    public class Menu
    {
        public enum Prices {
            Margarita = 85,
            Hawaii = 95,
            KebabPizza = 105,
            QuatroStagioni = 115,
            CocaCola = 20,
            Fanta = 20,
            Sprite = 25,
            CheapExtras = 10,
            MidPriceExtras = 15,
            HighPriceExtras = 20
        }

        public Dictionary<string, string> Pizzas = new Dictionary<string, string>
        {
            { "Margarita", "Ost,Tomatsås" },
            { "Hawaii", "Ost, tomatsås, skinka, ananas" },
            { "KebabPizza", "- Ost, tomatsås, kebab, champinjoner, lök, feferoni, isbergssallad, tomatkebabsås" },
            { "QuatroStagioni", "Ost, tomatsås, skinka, räkor, musslor, champinjoner, kronärtskocka" }
        };
        public Dictionary<string, int> ExtraIngredients = new Dictionary<string, int>
        {
            { "Skinka, ananas, champinjoner, lök, kebabsås", (int) Prices.CheapExtras },
            { "Räkor, musslor, kronärtskocka", (int) Prices.MidPriceExtras },
            { "Kebab, koriander", (int) Prices.HighPriceExtras },
        };
        public Dictionary<string, int> Drinks = new Dictionary<string, int>
        {
            { "CocaCola", (int) Prices.CocaCola },
            { "Fanta", (int) Prices.Fanta },
            { "Sprite", (int) Prices.Sprite },
        };
    }
}
