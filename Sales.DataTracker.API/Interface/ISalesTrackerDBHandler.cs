using Sales.DataTracker.API.Dto;
using Sales.DataTracker.DataCore.Entities;
using System.Security.Cryptography;

namespace Sales.DataTracker.API.Interface
{
    public interface ISalesTrackerDBHandler
    {
        public void SavePizza(List<PizzaDto> pizzaList);
        public void SavePizzaTypes(List<PizzaTypeDto> pizzaTypeList);
        public void SaveOrder(List<OrderDto> orderList);
        public void SaveOrderDetails(List<OrderDetailsDto> orderDetailsList);

        public IEnumerable<Order> GetOrders();

    }
}
