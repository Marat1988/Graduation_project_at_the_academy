using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Store.Service;
using Store.ViewModel;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace Store.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class OrderController: Controller
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService) => _orderService = orderService;
        
        public ActionResult Index() => View();
        

        public ActionResult GetAllOrders([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                var result = _orderService.GetAllOrders();
                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult> UpdateOrder(OrderViewModel model, [DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                await _orderService.Update(model);
                var resultData = new[] { model };
                return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}