using System;
using System.Collections.Generic;
using PizzeriaCleacCodeIths.Dto;
using PizzeriaCleacCodeIths.Models;

namespace PizzeriaCleacCodeIths.Orders
{
    public interface IOrder
    {
        List<OrderDto> HandleRequest(OrderRequestModel orderRequestModel);
        OrderDto ChangeOrderRequest(Guid id, OrderRequestModel orderRequestModel, bool orderHandled);
    }
}