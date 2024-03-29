
using CsvHelper;
using Sales.DataTracker.API.Dto;
using Sales.DataTracker.API.Interface;
using System.Formats.Asn1;
using System.Net.Http;

namespace Sales.DataTracker.API.Services
{
    public class SalesUpload : ISalesUpload
    {

        private List<PizzaDto> _pizzaList = new List<PizzaDto>();
        private List<OrderDto> _orderList = new List<OrderDto>();
        private List<OrderDetailsDto> _orderDetailsList = new List<OrderDetailsDto>();
        private List<PizzaTypeDto> _pizzaTypeList = new List<PizzaTypeDto>();

        public async Task<List<OrderDto>> UploadOrder(IFormFile file)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                using (var csv = new CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)))
                {
                    var records = csv.GetRecords<OrderDto>().ToList();
                    _orderList.AddRange(records);
                }
            }
            return _orderList;
        }

        public async Task<List<OrderDetailsDto>> UploadOrderDetails(IFormFile file)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                using (var csv = new CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)))
                {
                    var records = csv.GetRecords<OrderDetailsDto>().ToList();
                    _orderDetailsList.AddRange(records);
                }
            }
            return _orderDetailsList;
        }

        public async Task<List<PizzaTypeDto>> UploadPizzaType(IFormFile file)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                using (var csv = new CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)))
                {
                    var records = csv.GetRecords<PizzaTypeDto>().ToList();
                    _pizzaTypeList.AddRange(records);
                }
            }
            return _pizzaTypeList;
        }

        public async Task<List<PizzaDto>> UploadPizza(IFormFile file)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                using (var csv = new CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)))
                {
                    var records = csv.GetRecords<PizzaDto>().ToList();
                    _pizzaList.AddRange(records);
                }
            }
            return _pizzaList;
        }

        
    }
}
