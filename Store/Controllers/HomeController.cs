using Store.Infrastructure;
using Store.Models;
using Store.ViewModel;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Store.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly AppUserManager _userManager;

        public HomeController(AppUserManager userManager)
        {
            _userManager = userManager;
        }
        
        [Authorize]
        public ActionResult Index()
        {
            AppUser user = _userManager.Users.FirstOrDefault(item => item.UserName == HttpContext.User.Identity.Name);
            string name = user.UserName;
            ProfileUserViewModel profileUserViewModel = new ProfileUserViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Patronymic = user.Patronymic,
                DateBirthDay = (user.DateBirthDay == null) ? DateTime.Now.Date : user.DateBirthDay,
                Photo = user.Photo,
                Password = ""
            };
            return View(profileUserViewModel);
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            return View();
        }

    }
}