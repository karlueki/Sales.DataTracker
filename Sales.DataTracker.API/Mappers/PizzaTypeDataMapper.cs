using Sales.DataTracker.API.Dto;
using Sales.DataTracker.DataCore.Entities;

namespace Sales.DataTracker.API.Mappers
{
    public static class PizzaTypeDataMapper
    {
        public static PizzaType Map(PizzaTypeDto dto)
        {
            PizzaType pizzaType = new PizzaType();

            pizzaType.Pizza_Type_Id = dto.pizza_type_id;
            pizzaType.Ingredients = dto.ingredients;
            pizzaType.Name = dto.name;
            pizzaType.Category = dto.category;

            return pizzaType;
        }
    }
}
