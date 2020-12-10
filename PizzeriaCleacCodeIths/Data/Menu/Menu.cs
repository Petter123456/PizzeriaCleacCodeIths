using PizzeriaCleacCodeIths.Models;
using System.Collections.Generic;

namespace PizzeriaCleacCodeIths.Data
{
    public sealed class Menu : IMenu
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

        Dictionary<string, int> IMenu.Prices => new Dictionary<string, int> {
            {"Margarita", 85},
            {"Hawaii", 95},
            {"KebabPizza", 105},
            {"QuatroStagioni", 115},
            {"CocaCola", 20},
            {"Fanta", 20},
            {"Sprite", 25},
            {"skinka", 10},
            {"ananas", 10},
            {"champinjoner", 10},
            {"lök", 10},
            {"kebabsås", 10},
            {"räkor", 15},
            {"musslor", 15},
            {"kronärtskocka", 15},
            {"kebab", 20},
            {"koriander", 20},
            {"CheapExtras", 10},
            {"MidPriceExtras", 15},
            {"HighPriceExtras", 20}
        };

        public Dictionary<string, string> PizzasWithIngredients => new Dictionary<string, string>
        {
            { "Margarita", "Ost,Tomatsås" },
            { "Hawaii", "Ost, tomatsås, skinka, ananas" },
            { "KebabPizza", "- Ost, tomatsås, kebab, champinjoner, lök, feferoni, isbergssallad, tomatkebabsås" },
            { "QuatroStagioni", "Ost, tomatsås, skinka, räkor, musslor, champinjoner, kronärtskocka" }
        };

        public Dictionary<string, int> ExtraIngredientsWithPrices => new Dictionary<string, int>
        {
            { "Skinka, ananas, champinjoner, lök, kebabsås", 10 },
            { "Räkor, musslor, kronärtskocka", 15 },
            { "Kebab, koriander", 20 },
        };

        public Dictionary<string, int> DrinksWithPrices => new Dictionary<string, int>
        {
            { "CocaCola", 20 },
            { "Fanta", 20 },
            { "Sprite", 25 },
        };

        public static List<Order> orders = new List<Order>();

        //public static readonly Dictionary<string, int> Prices = new Dictionary<string, int> {
        //    {"Margarita", 85},
        //    {"Hawaii", 95},
        //    {"KebabPizza", 105},
        //    {"QuatroStagioni", 115},
        //    {"CocaCola", 20},
        //    {"Fanta", 20},
        //    {"Sprite", 25},
        //    {"skinka", 10},
        //    {"ananas", 10},
        //    {"champinjoner", 10},
        //    {"lök", 10},
        //    {"kebabsås", 10},
        //    {"räkor", 15},
        //    {"musslor", 15},
        //    {"kronärtskocka", 15},
        //    {"kebab", 20},
        //    {"koriander", 20},
        //    {"CheapExtras", 10},
        //    {"MidPriceExtras", 15},
        //    {"HighPriceExtras", 20}
        //};

        //public static readonly Dictionary<string, string> Pizzas = new Dictionary<string, string>
        //{
        //    { "Margarita", "Ost,Tomatsås" },
        //    { "Hawaii", "Ost, tomatsås, skinka, ananas" },
        //    { "KebabPizza", "- Ost, tomatsås, kebab, champinjoner, lök, feferoni, isbergssallad, tomatkebabsås" },
        //    { "QuatroStagioni", "Ost, tomatsås, skinka, räkor, musslor, champinjoner, kronärtskocka" }
        //};
        //public static readonly Dictionary<string, int> ExtraIngredients = new Dictionary<string, int>
        //{
        //    { "Skinka, ananas, champinjoner, lök, kebabsås", Prices["CheapExtras"] },
        //    { "Räkor, musslor, kronärtskocka", (int) Prices["MidPriceExtras"] },
        //    { "Kebab, koriander", (int) Prices["HighPriceExtras"] },
        //};
        //public static readonly Dictionary<string, int> Drinks = new Dictionary<string, int>
        //{
        //    { "CocaCola", (int) Prices["CocaCola"] },
        //    { "Fanta", (int) Prices["Fanta"] },
        //    { "Sprite", (int) Prices["Sprite"] },
        //};

        public List<Order> GetListOfOrders(Order order)
        {
            orders.Add(order);
            return orders; 
        }
    }
}
