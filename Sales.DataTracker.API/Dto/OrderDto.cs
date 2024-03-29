using Sales.DataTracker.DataCore.Entities;

namespace Sales.DataTracker.API.Dto
{
    public class OrderDto
    {
        public int order_id { get; set; }
        public string date { get; set; }
        public string time { get; set; }
    }
}
