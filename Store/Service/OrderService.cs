using Store.Repository.Orders;
using Store.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Service
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository) => _orderRepository = orderRepository;

        public Task AddOrder(SendOrderViewModel orderViewModel) => _orderRepository.AddOrder(orderViewModel);

        public List<OrderViewModel> GetAllOrders() => _orderRepository.GetAllOrders();

        public Task Update(OrderViewModel orderViewModel) => _orderRepository.Update(orderViewModel);

        public Task<List<SalesStatisticsUser>> SalesStatisticsUser() => _orderRepository.SalesStatisticsUser();


    }
}