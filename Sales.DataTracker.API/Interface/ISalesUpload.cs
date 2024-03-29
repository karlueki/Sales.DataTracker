using Sales.DataTracker.API.Dto;
using Sales.DataTracker.DataCore.Entities;

namespace Sales.DataTracker.API.Interface
{
    public interface ISalesUpload
    {
        public Task<List<OrderDto>> UploadOrder(IFormFile file);
        public Task<List<OrderDetailsDto>> UploadOrderDetails(IFormFile file);
        public Task<List<PizzaDto>> UploadPizza(IFormFile file);
        public Task<List<PizzaTypeDto>> UploadPizzaType(IFormFile file);
    }
}
