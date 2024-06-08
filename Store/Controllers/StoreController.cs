using Store.Infrastructure;
using Store.Service;
using Store.ViewModel;
using System.Web.Mvc;
using System;
using System.Threading.Tasks;

namespace Store.Controllers
{
    [AllowAnonymous]
    public class StoreController: Controller
    {
        private readonly ProductService _productService;
        private readonly GroupService _groupService;
        private readonly SupplierService _supplierService;
        private readonly RecyclerService _recyclerService;

        public StoreController(ProductService productService, GroupService groupService, SupplierService supplierService, RecyclerService recyclerService)
        {
            _productService = productService;
            _groupService = groupService;
            _supplierService = supplierService;
            _recyclerService = recyclerService;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            string userName = HttpContext.User.Identity.Name;
            if (string.IsNullOrEmpty(userName) && CookieHelper.isExistCookie() == false) //Аноном
            {
                CookieHelper.AddCookie();
            }
            var products = _productService.GetAllProducts();
            ViewBag.AllGroups = _groupService.GetAllGroupsChoose();
            ViewBag.AllSuppliers = _supplierService.GetAllSuppliersChoose();
            return View(products);
        }


        [AllowAnonymous]
        [HttpGet]
        public JsonResult Search(SearchViewModel searchFilter)
        {
            var products = _productService.GetChooseProducts(searchFilter);
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> Buy(int productId)
        {
            try
            {
                return await _recyclerService.Add(productId);
            }
            catch (Exception ex)
            {
                return Json( new { success = false, message = ex.Message });
            }
        }
    }
}