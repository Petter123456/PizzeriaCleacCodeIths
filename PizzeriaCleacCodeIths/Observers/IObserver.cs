using PizzeriaCleacCodeIths.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaCleacCodeIths.Observers
{
    public interface IObserver
    {
        void update(Order order);
    }
}
