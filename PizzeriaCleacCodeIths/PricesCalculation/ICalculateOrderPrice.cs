using PizzeriaCleacCodeIths.Dto;

namespace PizzeriaCleacCodeIths.PricesCalculation
{
    public interface ICalculateOrderPrice
    {
        int CalculateTotalOrderPrice(OrderDto order);
    }
}
