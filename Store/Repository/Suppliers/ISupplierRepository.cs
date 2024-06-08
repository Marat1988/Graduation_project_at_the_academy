using Store.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Repository.Suppliers
{
    public interface ISupplierRepository
    {
        List<SupplierViewModel> GetAllSuppliers();

        IQueryable GetAllSuppliersChoose();

        Task Add(SupplierViewModel SupplierViewModel);

        Task Update(SupplierViewModel SupplierViewModel);

        Task Delete(int Id);
    }
}