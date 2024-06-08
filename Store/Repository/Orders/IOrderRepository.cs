using Store.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Orders
{
    public interface IOrderRepository
    {
        Task AddOrder(SendOrderViewModel sendOrderViewModel);
        List<OrderViewModel> GetAllOrders();
        Task Update(OrderViewModel orderViewModel);
        Task<List<SalesStatisticsUser>> SalesStatisticsUser();

    }
}
