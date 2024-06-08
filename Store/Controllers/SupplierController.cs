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
    public class SupplierController: Controller
    {
        private readonly SupplierService _supplierService;

        public SupplierController(SupplierService groupService) => _supplierService = groupService;

        public ActionResult Index() => View();

        public ActionResult GetAllSuppliers([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                var fields = _supplierService.GetAllSuppliers();
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
        public async Task<ActionResult> AddSupplier(SupplierViewModel model, [DataSourceRequest] DataSourceRequest dataSourceRequest)
        {
            try
            {
                await _supplierService.Add(model);
                var resultData = new[] { model };
                return Json(resultData.AsQueryable().ToDataSourceResult(dataSourceRequest, ModelState));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> UpdateSupplier(SupplierViewModel model, [DataSourceRequest] DataSourceRequest dataSourceRequest)
        {
            try
            {
                await _supplierService.Update(model);
                var resultData = new[] { model };
                return Json(resultData.AsQueryable().ToDataSourceResult(dataSourceRequest, ModelState));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteSupplier(SupplierViewModel model, [DataSourceRequest] DataSourceRequest dataSourceRequest)
        {
            try
            {
                await _supplierService.Delete(model.Id);
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