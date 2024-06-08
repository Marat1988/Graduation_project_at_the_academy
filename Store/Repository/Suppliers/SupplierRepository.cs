using Store.Infrastructure;
using Store.Models;
using Store.Service;
using Store.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Repository.Suppliers
{
    public class SupplierRepository : IDisposable, ISupplierRepository
    {
        private readonly AppIdentityDbContext db = new AppIdentityDbContext();

        public List<SupplierViewModel> GetAllSuppliers()
        {
            List<SupplierViewModel> supplierViewModels = new List<SupplierViewModel>();
            foreach (var item in db.Suppliers)
            {
                supplierViewModels.Add(new SupplierViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                });
            }
            return supplierViewModels;
        }

        public IQueryable GetAllSuppliersChoose()
        {
            return (from p in db.Suppliers
                    select new { p.Id, p.Name })
                                    .Union(from p in db.Suppliers
                                           select new { Id = 0, Name = "Все поставщики" })
                                    .OrderBy(x => x.Id)
                                    .ThenBy(x => x.Name);
        }

        public async Task Add(SupplierViewModel SupplierViewModel)
        {
            Supplier supplier = new Supplier()
            {
                Name = SupplierViewModel.Name,
            };
            db.Suppliers.Add(supplier);
            await db.SaveChangesAsync();
        }

        public async Task Update(SupplierViewModel SupplierViewModel)
        {
            Supplier supplier = await db.Suppliers.Where(item=> item.Id == SupplierViewModel.Id).FirstAsync();
            supplier.Name = SupplierViewModel.Name;
            await db.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var entity = await db.Suppliers.FindAsync(Id);
            db.Suppliers.Remove(entity);
            await db.SaveChangesAsync();
        }

        public void Dispose() => db?.Dispose();
    }
}