using System.Collections.Generic;

namespace PizzeriaCleacCodeIths.Data
{
    public sealed class Menu
    {
        private static Menu instance = null; 
        public static Menu GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new Menu();
                return instance;
            }
        }

        public static readonly Dictionary<string, int> Prices = new Dictionary<string, int> {
            {"Margarita", 85},
            {"Hawaii", 95},
            {"KebabPizza", 105},
            {"QuatroStagioni", 115},
            {"CocaCola", 20},
            {"Fanta", 20},
            {"Sprite", 25},
            {"CheapExtras", 10},
            {"MidPriceExtras", 15},
            {"HighPriceExtras", 20}
        };

        public static readonly Dictionary<string, string> Pizzas = new Dictionary<string, string>
        {
            { "Margarita", "Ost,Tomatsås" },
            { "Hawaii", "Ost, tomatsås, skinka, ananas" },
            { "KebabPizza", "- Ost, tomatsås, kebab, champinjoner, lök, feferoni, isbergssallad, tomatkebabsås" },
            { "QuatroStagioni", "Ost, tomatsås, skinka, räkor, musslor, champinjoner, kronärtskocka" }
        };
        public static readonly Dictionary<string, int> ExtraIngredients = new Dictionary<string, int>
        {
            { "Skinka, ananas, champinjoner, lök, kebabsås", Prices["CheapExtras"] },
            { "Räkor, musslor, kronärtskocka", (int) Prices["MidPriceExtras"] },
            { "Kebab, koriander", (int) Prices["HighPriceExtras"] },
        };
        public static readonly Dictionary<string, int> Drinks = new Dictionary<string, int>
        {
            { "CocaCola", (int) Prices["CocaCola"] },
            { "Fanta", (int) Prices["Fanta"] },
            { "Sprite", (int) Prices["Sprite"] },
        };
    }
}
