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
    [AllowAnonymous]
    public class RecyclerController: Controller
    {
        private readonly RecyclerService _recyclerService;
        private readonly OrderService _orderService;

        public RecyclerController(RecyclerService recyclerService, OrderService orderService)
        {
            _recyclerService = recyclerService;
            _orderService = orderService;
        }

        public ActionResult Index() => View();


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(SendOrderViewModel sendOrderViewModel)
        {
            var recyclers = _recyclerService.GetShowRecycler();
            if (recyclers.Count == 0)
            {
                ModelState.AddModelError("", "Ваша корзина пуста");
            }
            else
            {
                await _orderService.AddOrder(sendOrderViewModel);
                TempData["Message"] = "Спасибо за отправку заявки!";
            }
            return View(sendOrderViewModel);
        }

        public ActionResult GetShowRecycler([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                var fields = _recyclerService.GetShowRecycler();
                var result = fields.ToDataSourceResult(request);
                var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
                return jsonResult;
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost]
        public async Task<ActionResult> UpdateProductFromRecycler(RecyclerViewModel model, [DataSourceRequest] DataSourceRequest dataSourceRequest)
        {
            try
            {
                await _recyclerService.Update(model);
                var resultData = new[] { model };
                return Json(resultData.AsQueryable().ToDataSourceResult(dataSourceRequest, ModelState));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteProductFromRecycler(RecyclerViewModel model, [DataSourceRequest] DataSourceRequest dataSourceRequest)
        {
            try
            {
                await _recyclerService.Delete(model.Id);
                var resultData = new[] { model };
                return Json(resultData.AsQueryable().ToDataSourceResult(dataSourceRequest, ModelState));

            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}