using System;
using System.Collections.Generic;
using System.Linq;
using PizzeriaCleacCodeIths.Dto;

namespace PizzeriaCleacCodeIths.Data.Menu
{
    public sealed class Menu : IMenu
    {
        private static Menu _instance = null;
        public static List<OrderDto> Orders { get; set; }
  
        public static Menu GetInstance
        {
            get
            {
                if (_instance == null)
                    _instance = new Menu();
                return _instance;
            }
        }

        Dictionary<string, int> IMenu.Prices => new Dictionary<string, int> {
            {"margarita", 85},
            {"hawaii", 95},
            {"kebabPizza", 105},
            {"cuatrostagioni", 115},
            {"cocacola", 20},
            {"fanta", 20},
            {"sprite", 25},
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
            { "margarita", "Ost,Tomatsås" },
            { "hawaii", "Ost, tomatsås, skinka, ananas" },
            { "kebabPizza", "- Ost, tomatsås, kebab, champinjoner, lök, feferoni, isbergssallad, tomatkebabsås" },
            { "quatrostagioni", "Ost, tomatsås, skinka, räkor, musslor, champinjoner, kronärtskocka" }
        };

        public Dictionary<string, int> ExtraIngredientsWithPrices => new Dictionary<string, int>
        {
            { "skinka, ananas, champinjoner, lök, kebabsås", 10 },
            { "räkor, musslor, kronärtskocka", 15 },
            { "kebab, koriander", 20 },
        };

        public Dictionary<string, int> DrinksWithPrices => new Dictionary<string, int>
        {
            { "cocacola", 20 },
            { "fanta", 20 },
            { "sprite", 25 },
        };

        public OrderDto ApproveOrder(Guid id, in bool orderHandled)
        {
            var orderDto = Orders.SingleOrDefault(order => order.Id.Equals(id));

            if (orderDto != null)
            {
                orderDto.Approved = orderHandled;
            }
            else
            {
                throw new ArgumentException("No orderDto with the id you entered was found");
            }

            return orderDto;
        }


        public List<OrderDto> GetListOfOrders(OrderDto order)
        {
            Orders ??= new List<OrderDto>();
            Orders.Add(order);

            var noneApprovedOrders = Orders.Where(order => order.Approved == false);

            return noneApprovedOrders.ToList(); 
        }
        public OrderDto EditOrderDto(Guid id, OrderDto orderChanged)
        {
            var orderDtoIndex = Orders.FindIndex(x => x.Id.Equals((id)));
            Orders[orderDtoIndex] = orderChanged; 
            return Orders[orderDtoIndex];
        }
        public List<OrderDto> DeleteOrderDto(Guid id)
        {
            var order = Orders.SingleOrDefault(order => order.Id == id);

            if (order != null)
            {
                Orders.Remove(order);
            }
            else
            {
                throw new ArgumentException("No order with the id you entered was found");
            }

            return Orders;
        }
    }
}
