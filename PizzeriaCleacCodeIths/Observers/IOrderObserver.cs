using PizzeriaCleacCodeIths.Dto;
using PizzeriaCleacCodeIths.PricesCalculation;

namespace PizzeriaCleacCodeIths.Observers
{
    interface IOrderObserver
    {
        int GetOrderPrice(ICalculateOrderPrice calculatePrice, OrderDto orderDto);
    }
}
