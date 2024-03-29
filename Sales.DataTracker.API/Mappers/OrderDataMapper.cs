using Sales.DataTracker.API.Dto;
using Sales.DataTracker.DataCore.Entities;

namespace Sales.DataTracker.API.Mappers
{
    public class OrderDataMapper
    {
        public static Order Map(OrderDto dto)
        {
            Order order = new Order();

            order.Order_Id = dto.order_id;
            DateTime dtoDate = DateTime.Parse(dto.date);
           DateOnly dateOnlyValue = new DateOnly(dtoDate.Year, dtoDate.Month, dtoDate.Day);
            order.Date = dateOnlyValue;
            DateTime dtoDateTime = DateTime.Parse(dto.time);
            TimeOnly timeOnlyValue = new TimeOnly(dtoDateTime.Hour, dtoDateTime.Minute, dtoDateTime.Second);
            order.Time = timeOnlyValue;

            return order;
        }

        
    }
}
