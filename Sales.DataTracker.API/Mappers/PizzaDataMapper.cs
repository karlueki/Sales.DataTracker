using Sales.DataTracker.API.Dto;
using Sales.DataTracker.DataCore.Entities;

namespace Sales.DataTracker.API.Mappers
{
    public static class PizzaDataMapper
    {
        public static Pizza Map(PizzaDto dto)
        {
            Pizza pizza = new Pizza();

            pizza.Id = dto.pizza_id;
            pizza.Pizza_Type_Id = dto.pizza_type_id;
            pizza.Size = dto.size;
            pizza.Price = dto.price;

            return pizza;
        }
    }
}
