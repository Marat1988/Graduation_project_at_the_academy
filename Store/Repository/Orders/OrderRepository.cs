using Microsoft.AspNet.Identity;
using Store.Infrastructure;
using Store.Models;
using Store.Service;
using Store.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Store.Repository.Orders
{
    public class OrderRepository: IDisposable, IOrderRepository
    {
        private readonly AppIdentityDbContext db = new AppIdentityDbContext();
        private readonly AppUserManager _userManager;
        private readonly RecyclerService _recyclerService;

        public OrderRepository(AppUserManager userManager, RecyclerService recyclerService)
        {
             _userManager = userManager;
            _recyclerService = recyclerService;
        }
       
        public async Task AddOrder(SendOrderViewModel sendOrderViewModel)
        {
            string userName = HttpContext.Current.User.Identity.Name;
            if (string.IsNullOrEmpty(userName))
            {
                userName = AppIdentityDbContext.userAnonymous;
            }
            AppUser user = _userManager.FindByName(userName);
            var recyclerUser = _recyclerService.GetShowRecycler();
            if (recyclerUser != null)
            {
                Order order = new Order
                {
                    DateTimeCreate = DateTime.Now,
                    UserId = user.Id,
                    PhoneNumber = sendOrderViewModel.telephone,
                    LineOrders = new List<LineOrder>()
                };
                    
                foreach (var item in recyclerUser)
                {
                    order.LineOrders.Add(new LineOrder
                    {
                        Amount = item.Amount,
                        DisplayPrice = item.DisplayPrice,
                        ShippingPrice = item.ShippingPrice,
                        ProductId = item.ProductId,
                        OrderId = order.Id
                    });
                }
                db.Orders.Add(order);
                await db.SaveChangesAsync();
                if (db.Orders.Any(item=>order.Id==order.Id)  && db.LineOrders.Any(item => item.OrderId == order.Id))
                {
                    foreach (var item in recyclerUser)
                    {
                        db.Recyclers.Remove(db.Recyclers.FirstOrDefault(i => i.Id == item.Id));
                    }
                    await db.SaveChangesAsync();
                }
            }        
        }

        public List<OrderViewModel> GetAllOrders()
        {
            var orders = db.Orders.Select(o => new OrderViewModel
            {
                Id = o.Id,
                DateTimeCreate = o.DateTimeCreate,
                PhoneNumber = o.PhoneNumber,
                UserId = o.UserId,
                UserName = o.User.UserName,
                Processed = o.Processed,
                Quantity = o.LineOrders.Sum(i => i.Amount),
                Total = o.LineOrders.Sum(i => i.Amount * i.ShippingPrice)
            }).ToList();
            return orders;
        }

        public async Task Update(OrderViewModel orderViewModel)
        {
            var order = await db.Orders.Where(item => item.Id == orderViewModel.Id).FirstOrDefaultAsync();
            order.DateTimeCreate = orderViewModel.DateTimeCreate;
            order.PhoneNumber = orderViewModel.PhoneNumber;
            order.UserId = orderViewModel.UserId;
            order.Processed = orderViewModel.Processed;
            await db.SaveChangesAsync();
        }

        public async Task<List<SalesStatisticsUser>> SalesStatisticsUser()
        {
            var result = db.Orders
                .Join(db.Users, o => o.UserId, u => u.Id, (o, u) => new { Order = o, User = u })
                .Join(db.LineOrders, ou => ou.Order.Id, lo => lo.OrderId, (ou, lo) => new { OrderUser = ou, LineOrder = lo })
                .GroupBy(oulo => oulo.OrderUser.User.UserName)
                .Select(g => new SalesStatisticsUser
                {
                    UserName = g.Key,
                    Total = g.Sum(oulo => oulo.LineOrder.Amount * oulo.LineOrder.ShippingPrice)
                })
                .OrderBy(r => r.UserName);
            return await result.ToListAsync();
        }

        public void Dispose() => db?.Dispose();
    }
}