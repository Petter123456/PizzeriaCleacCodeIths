using PizzeriaCleacCodeIths.Data;
using PizzeriaCleacCodeIths.Models;
using PizzeriaCleacCodeIths.Observers;
using System.Linq;

namespace PizzeriaCleacCodeIths.Repositories
{
    public class PlaceOrder : IPlaceOrder
    {
        public void ReciveOrder(Pizzas pizzas, Drinks drinks, ExtraIngredients extras)
        {
            

            //var x = Menu.Pizzas.Any(x => x.Key == order.);
            ICalculatePrice calculatePrice = new CalculatePrice(); 
            //var observer = new Observer(order,calculatePrice);
            //observer.update(order);
        }

       
    }
}
