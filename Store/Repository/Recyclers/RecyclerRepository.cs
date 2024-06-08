using Microsoft.AspNet.Identity;
using Store.Infrastructure;
using Store.Models;
using Store.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Store.Repository.Recyclers
{
    [AllowAnonymous]
    public class RecyclerRepository: IDisposable, IRecyclerRepository
    {
        private readonly AppIdentityDbContext db = new AppIdentityDbContext();
        private readonly AppUserManager _userManager;

        public RecyclerRepository(AppUserManager userManager)
        {
            _userManager = userManager;
        }
      
        public List<RecyclerViewModel> GetShowRecycler()
        {
            string userName = HttpContext.Current.User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                AppUser user =  _userManager.FindByName(userName);
                var recyclerUser = db.Recyclers.Where(item => item.UserId == user.Id);
                if (recyclerUser != null)
                {
                    List<RecyclerViewModel> list = new List<RecyclerViewModel>();

                    foreach (var item in recyclerUser)
                    {
                        list.Add(new RecyclerViewModel
                        {
                            Id = item.Id,
                            Amount = item.Amount,
                            DisplayPrice = item.DisplayPrice,
                            ShippingPrice = item.ShippingPrice,
                            ProductId = item.ProductId,
                            ProductName = db.Products.FirstOrDefault(p => p.Id == item.ProductId).Name
                        });
                    }
                    return list;
                }
            }
            else
            {
                string userId = CookieHelper.GetValueFromCookie();
                var recyclerUser = db.Recyclers.Where(item => item.UserIdAnonymous == userId);
                if (recyclerUser != null)
                {
                    List<RecyclerViewModel> list = new List<RecyclerViewModel>();
                    foreach (var item in recyclerUser)
                    {
                        list.Add(new RecyclerViewModel
                        {
                            Id = item.Id,
                            Amount = item.Amount,
                            DisplayPrice = item.DisplayPrice,
                            ShippingPrice = item.ShippingPrice,
                            ProductId = item.ProductId,
                            ProductName = db.Products.FirstOrDefault(p => p.Id == item.ProductId).Name
                        });
                    }
                    return list;
                }
            }
            return null;
        }


        public async Task<JsonResult> Add(int productId)
        {
            string userName = HttpContext.Current.User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                AppUser user = _userManager.FindByName(userName);
                int personalDiscount = user.PersonalDiscount ?? 0;
                var recycler = db.Recyclers.Where(item => item.UserId == user.Id && item.ProductId == productId).FirstOrDefault();
                if (recycler != null)
                {
                    recycler.Amount += 1;
                }
                else
                {
                    var displayPriceProduct = db.Products.FirstOrDefault(p => p.Id == productId).Price;
                    db.Recyclers.Add(new Recycler
                    {
                        Amount = 1,
                        DisplayPrice = displayPriceProduct,
                        ShippingPrice = Math.Round((displayPriceProduct - ((displayPriceProduct * personalDiscount) / 100.0M)), 2),
                        ProductId = productId,
                        UserId = user.Id,
                        UserIdAnonymous = null
                    });
                }
                await db.SaveChangesAsync();
                var amountProduct = db.Recyclers.Where(i => i.UserId==user.Id).Sum(t => t.Amount);
                return new JsonResult { Data = new {success = true, Amount = amountProduct }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                string userId = CookieHelper.GetValueFromCookie();
                var recycler = db.Recyclers.Where(item => item.UserIdAnonymous == userId && item.ProductId == productId).FirstOrDefault();
                if (recycler != null)
                {
                    recycler.Amount += 1;
                }
                else
                {
                    var displayPriceProduct = db.Products.FirstOrDefault(p => p.Id == productId).Price;
                    db.Recyclers.Add(new Recycler
                    {
                        Amount = 1,
                        DisplayPrice = displayPriceProduct,
                        ShippingPrice = displayPriceProduct,
                        ProductId = productId,
                        UserId = null,
                        UserIdAnonymous = userId
                    });
                }
                await db.SaveChangesAsync();
                var amountProduct = db.Recyclers.Where(i => i.UserIdAnonymous == userId).Sum(t => t.Amount);
                return new JsonResult { Data = new { success = true, Amount = amountProduct }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }

        public async Task Update(RecyclerViewModel recyclerViewModel)
        {
            var recycler = await db.Recyclers.Where(item => item.Id == recyclerViewModel.Id).FirstOrDefaultAsync();
            recycler.Amount = recyclerViewModel.Amount;
            recycler.DisplayPrice = recyclerViewModel.DisplayPrice;
            recycler.ShippingPrice = recyclerViewModel.ShippingPrice;
            recycler.ProductId = recyclerViewModel.ProductId;
            await db.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var entity = await db.Recyclers.FindAsync(Id);
            db.Recyclers.Remove(entity);
            await db.SaveChangesAsync();
        }

        public void Dispose() => db?.Dispose(); 
    }
}