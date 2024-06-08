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
    public class GroupController : Controller
    {
        private readonly GroupService _groupService;

        public GroupController(GroupService groupService) => _groupService = groupService;

        public ActionResult Index() => View();

        public ActionResult GetAllGroups([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                var fields = _groupService.GetAllGroups();
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
        public async Task<ActionResult> AddGroup(GroupViewModel model, [DataSourceRequest] DataSourceRequest dataSourceRequest)
        {
            try
            {
                await _groupService.Add(model);
                var resultData = new[] { model };
                return Json(resultData.AsQueryable().ToDataSourceResult(dataSourceRequest, ModelState));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> UpdateGroup(GroupViewModel model, [DataSourceRequest] DataSourceRequest dataSourceRequest)
        {
            try
            {
                await _groupService.Update(model);
                var resultData = new[] { model };
                return Json(resultData.AsQueryable().ToDataSourceResult(dataSourceRequest, ModelState));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteGroup(GroupViewModel model, [DataSourceRequest] DataSourceRequest dataSourceRequest)
        {
            try
            {
                await _groupService.Delete(model.Id);
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