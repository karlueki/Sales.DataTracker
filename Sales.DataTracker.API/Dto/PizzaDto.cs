using Sales.DataTracker.DataCore.Entities;

namespace Sales.DataTracker.API.Dto
{
    public class PizzaDto
    {
        public string pizza_id { get; set; }
        public string pizza_type_id { get; set; }
        public string size { get; set; }

        public double price { get; set; }
    }
}
