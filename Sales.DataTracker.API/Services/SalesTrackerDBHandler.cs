using Sales.DataTracker.API.Dto;
using Sales.DataTracker.API.Interface;
using Sales.DataTracker.API.Mappers;
using Sales.DataTracker.DataCore.Entities;
using Sales.DataTracker.DataCore.Repositories;

namespace Sales.DataTracker.API.Services
{
    public class SalesTrackerDBHandler : ISalesTrackerDBHandler
    {
        private IUnitOfWork _unitOfWork;
        public SalesTrackerDBHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void SaveOrder(List<OrderDto> orderListDto)
        {
            List<Order> orderList = new List<Order>();

            foreach (var orderDto in orderListDto)
            {
                Order order = OrderDataMapper.Map(orderDto);
                orderList.Add(order);
            }

            _unitOfWork.OrderRepository.InsertRange(orderList);
            _unitOfWork.Save();
        }

        public void SaveOrderDetails(List<OrderDetailsDto> orderDetailsListDto)
        {
            List<OrderDetails> orderDetailsList = new List<OrderDetails>();

            foreach (var orderDetailDto in orderDetailsListDto)
            {
                OrderDetails orderDetails = OrderDetailsDataMappers.Map(orderDetailDto);
                orderDetailsList.Add(orderDetails);
            }

            _unitOfWork.OrderDetailsRepository.InsertRange(orderDetailsList);
            _unitOfWork.Save();
        }

        public void SavePizza(List<PizzaDto> pizzaListDto)
        {
            List<Pizza> pizzaList = new List<Pizza>();

            foreach (var pizzaDto in pizzaListDto)
            {
                Pizza pizza = PizzaDataMapper.Map(pizzaDto);
                pizzaList.Add(pizza);
            }

            _unitOfWork.PizzaRepository.InsertRange(pizzaList);
            _unitOfWork.Save();
        }

        public void SavePizzaTypes(List<PizzaTypeDto> pizzaTypeListDto)
        {
            List<PizzaType> pizzaTypesList = new List<PizzaType>();

            foreach (var pizzaTypeDto in pizzaTypeListDto)
            {
                PizzaType pizza = PizzaTypeDataMapper.Map(pizzaTypeDto);
                pizzaTypesList.Add(pizza);
            }

            _unitOfWork.PizzaTypeRepository.InsertRange(pizzaTypesList);
            _unitOfWork.Save();
        }

        public IEnumerable<Order> GetOrders()
        {
            IEnumerable<Order> Orders = _unitOfWork.OrderRepository.GetAll();

            return Orders;

        }



    }
}
