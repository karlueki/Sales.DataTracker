using Sales.DataTracker.API.Dto;
using Sales.DataTracker.DataCore.Entities;

namespace Sales.DataTracker.API.Mappers
{
    public static class OrderDetailsDataMappers
    {
        public static OrderDetails Map(OrderDetailsDto dto)
        {
            OrderDetails orderDetails = new OrderDetails();

            orderDetails.Order_Details_Id = dto.order_details_id;
            orderDetails.Order_Id = dto.order_details_id;
            orderDetails.PizzaId = dto.pizza_id;
            orderDetails.Quantity = dto.quantity;

            return orderDetails;
        }
    }
}
