using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Store.Service;
using Store.ViewModel;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly GroupService _groupService;
        private readonly SupplierService _supplierService;

        public ProductController(ProductService productService, GroupService groupService, SupplierService supplierService)
        {
            _productService = productService;
            _groupService = groupService;
            _supplierService = supplierService;
        }

        public ActionResult Index()
        {
            ViewBag.Groups = _groupService.GetAllGroups();
            ViewBag.Suppliers = _supplierService.GetAllSuppliers();
            return View();
        }

        public ActionResult GetAllProducts([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                var result = _productService.GetAllProducts();
                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(ProductViewModel model, [DataSourceRequest] DataSourceRequest dataSourceRequest)
        {
            try
            {
                await _productService.Add(model);
                var resultData = new[] { model };
                return Json(resultData.AsQueryable().ToDataSourceResult(dataSourceRequest, ModelState));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> UpdateProduct(ProductViewModel model, [DataSourceRequest] DataSourceRequest dataSourceRequest)
        {
            try
            {
                await _productService.Update(model);
                var resultData = new[] { model };
                return Json(resultData.AsQueryable().ToDataSourceResult(dataSourceRequest, ModelState));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteProduct(ProductViewModel model, [DataSourceRequest] DataSourceRequest dataSourceRequest)
        {
            try
            {
                await _productService.Delete(model.Id);
                var resultData = new[] { model };
                return Json(resultData.AsQueryable().ToDataSourceResult(dataSourceRequest, ModelState));
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetPictureProduct(int id)
        {
            try
            {
                byte[] content = await _productService.GetPictureProduct(id);
                if (content == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                }

                using (var stream = new MemoryStream())
                {
                    MemoryStream ms = new MemoryStream(content);
                    return new FileStreamResult(ms, "image");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<string> UploadPictureProduct(HttpPostedFileBase uploadImage, int ProductId)
        {
            try
            {              
                string result = await _productService.UploadPictureProduct(uploadImage, ProductId);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task DeletePictureFromProduct(int productId)
        {
            try
            {
                await _productService.DeletePictureFromProduct(productId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}