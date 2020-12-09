using PizzeriaCleacCodeIths.Models;
using PizzeriaCleacCodeIths.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaCleacCodeIths.Observers
{
    public class Observer : IObserver
    {
        public Observer(Order order, ICalculatePrice calculatePrice)
        {
            calculatePrice.RegisterObserver(this);
        }
        public void update(Order order)
        {

        }
    }
}
