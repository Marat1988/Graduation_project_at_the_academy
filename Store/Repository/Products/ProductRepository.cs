using Microsoft.AspNet.Identity;
using Store.Infrastructure;
using Store.Models;
using Store.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Store.Repository.Products
{
    public class ProductRepository : IDisposable, IProductRepository
    {
        private readonly AppIdentityDbContext db = new AppIdentityDbContext();
        private readonly AppUserManager _userManager;

        public ProductRepository(AppUserManager userManager) => _userManager = userManager;
        
        public List<ProductViewModel> GetAllProducts()
        {
            int personalDiscount = 0;
            string userName = HttpContext.Current.User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                AppUser user = _userManager.FindByName(userName);
                personalDiscount = user.PersonalDiscount ?? 0;
            }
            var products = new List<ProductViewModel>();
            foreach (var product in db.Products)
            {
                products.Add(new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    PersonalPrice = Math.Round((product.Price - ((product.Price * personalDiscount) / 100.0M)), 2),
                    GroupId = product.GroupId,
                    GroupName = product.Group.Name,
                    SupplierId = product.SupplierId,
                    SupplierName = product.Supplier.Name,
                    IsPicture = (product.Photo != null) ? true : false
                });
            }
            return products;
        }


        public List<ProductViewModel> GetChooseProducts(SearchViewModel search)
        {
            int personalDiscount = 0;
            string userName = HttpContext.Current.User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                AppUser user = _userManager.FindByName(userName);
                personalDiscount = user.PersonalDiscount ?? 0;
            }

            var query = (from p in db.Products
                         where Math.Round((p.Price - ((p.Price * personalDiscount) / 100.0M)), 2) >= search.BeginPrice && Math.Round((p.Price - ((p.Price * personalDiscount) / 100.0M)), 2) <= search.EndPrice
                         && (search.GroupId == 0 || p.GroupId == search.GroupId)
                         && (search.SupplierId == 0 || p.SupplierId == search.SupplierId)
                         select new ProductViewModel
                         {
                             Id = p.Id,
                             Name = p.Name,
                             Price = p.Price,
                             PersonalPrice = Math.Round((p.Price - ((p.Price * personalDiscount) / 100.0M)), 2),
                             GroupId = p.Group.Id,
                             GroupName = p.Group.Name,
                             SupplierId = p.SupplierId,
                             SupplierName = p.Supplier.Name,
                             IsPicture = (p.Photo != null) ? true : false
                         });
            return query.ToList();
        }



        public async Task Add(ProductViewModel productViewModel)
        {
            db.Products.Add(new Product
            {
                Name = productViewModel.Name,
                Price = productViewModel.Price,
                GroupId = productViewModel.GroupId,
                SupplierId = productViewModel.SupplierId,
            });
            await db.SaveChangesAsync();
        }

        public async Task Update(ProductViewModel productViewModel)
        {
            var product = await db.Products.Where(item => item.Id == productViewModel.Id).FirstOrDefaultAsync();
            product.Name = productViewModel.Name;
            product.Price = productViewModel.Price;
            product.GroupId = productViewModel.GroupId;
            product.SupplierId = productViewModel.SupplierId;
            await db.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var entity = await db.Products.FindAsync(Id);
            db.Products.Remove(entity);
            await db.SaveChangesAsync();
        }

        public async Task<byte[]> GetPictureProduct(int productId)
        {
             return (await db.Products.FindAsync(productId))?.Photo;
        }

        public async Task<string> UploadPictureProduct(HttpPostedFileBase uploadImage, int ProductId)
        {
            if (uploadImage != null)
            {
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    byte[] imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    Product p = await db.Products.Where(item => item.Id == ProductId).FirstOrDefaultAsync();
                    p.Photo = imageData;
                    await db.SaveChangesAsync();
                }
                return "ОК";
            }
            else
            {
                throw new FileLoadException("Ошибка при загрузке изображения");
            }
        }

        public async Task DeletePictureFromProduct(int productId)
        {
            var product = await db.Products.Where(item => item.Id == productId).FirstOrDefaultAsync();
            product.Photo = null;
            await db.SaveChangesAsync();
        }

        public void Dispose() => db?.Dispose();
    }
}