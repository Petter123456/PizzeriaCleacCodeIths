using System;
using System.Collections.Generic;
using PizzeriaCleacCodeIths.Data.Menu;
using PizzeriaCleacCodeIths.Dto;
using PizzeriaCleacCodeIths.Models;
using PizzeriaCleacCodeIths.Observers;
using PizzeriaCleacCodeIths.PricesCalculation;

namespace PizzeriaCleacCodeIths.Orders
{
    public class Order : IOrder, IOrderObserver
    {
        public OrderDto orderDto = new OrderDto();
        private List<OrderDto> allOrders;
        private List<DrinksModel> drinks;
        private List<PizzaModel> pizzas;
        private List<ExtraIngredientsModel> extraIngredients;
        private ICalculateOrderPrice CalculateOrderPrice { get; }
        public IMenu Menu { get; }
        private IValidate Validate { get; }

        public Order(ICalculateOrderPrice calculateOrderPrice, IMenu menu, IValidate validate)
        {
            CalculateOrderPrice = calculateOrderPrice;
            Menu = menu;
            Validate = validate;
        }

        public List<OrderDto> HandleRequest(OrderRequestModel orderRequestModel)
        {
            OrderDto orderDto = RunInputValidation(orderRequestModel);

            orderDto.TotalPrice = GetOrderPrice(CalculateOrderPrice, orderDto);

            allOrders = Menu.AddToListOfOrders(orderDto);

            return allOrders;
        }

        private OrderDto RunInputValidation(OrderRequestModel orderRequestModel)
        {
            if (orderRequestModel.Pizzas == null && orderRequestModel.Drinks == null && orderRequestModel.ExtraIngredients != null)
            {
                throw new NullReferenceException("Invalid input. You may orderDto only drinks, but you have orderDto a pizza to orderDto extra ingredients");
            }

            if (orderRequestModel.Drinks != null)
            {
                drinks = Validate.ValidateDrinks(orderRequestModel.Drinks);
            }

            if (orderRequestModel.Pizzas != null)
            {
                pizzas = Validate.ValidatePizza(orderRequestModel.Pizzas);
            }

            if (orderRequestModel.ExtraIngredients != null)
            {
                extraIngredients = Validate.ValidateExtraIngredients(orderRequestModel.ExtraIngredients);
            }

            orderDto = new OrderDto()
            {
                Pizzas = pizzas,
                Drinks = drinks,
                ExtraIngredients = extraIngredients,
            };

            return orderDto;
        }

        public int GetOrderPrice(ICalculateOrderPrice calculatePrice, OrderDto orderDto)
        {
            return calculatePrice.CalculateTotalOrderPrice(orderDto);
        }

        public OrderDto ChangeOrderRequest(Guid id, OrderRequestModel orderRequestModel, bool orderHandled)
        {
            if (orderRequestModel.Drinks == null && 
                orderRequestModel.Pizzas == null && 
                orderRequestModel.ExtraIngredients == null)
            {
                return Menu.ApproveOrder(id, orderHandled);
            }
            else
            {
                orderDto = RunInputValidation(orderRequestModel);
                orderDto.Id = id;
                orderDto.TotalPrice = GetOrderPrice(CalculateOrderPrice, orderDto);
                orderDto.Approved = orderHandled;
            }
            return Menu.EditOrderDto(id, orderDto);
        }
    }
}
