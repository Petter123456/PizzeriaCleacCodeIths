using PizzeriaCleacCodeIths.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaCleacCodeIths.Repositories.CalculatePrice
{
    interface IAcceptVisitor
    {
        int GetOrderPrice(ICalculateOrderPrice calculatePrice);
    }
}
