using Store.Repository.Suppliers;
using Store.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Service
{
    public class SupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository) => _supplierRepository = supplierRepository;

        public List<SupplierViewModel> GetAllSuppliers() => _supplierRepository.GetAllSuppliers();

        public IQueryable GetAllSuppliersChoose() => _supplierRepository.GetAllSuppliersChoose();

        public Task Add(SupplierViewModel supplier) => _supplierRepository.Add(supplier);

        public Task Update(SupplierViewModel supplier) => _supplierRepository.Update(supplier);

        public Task Delete(int Id) => _supplierRepository.Delete(Id);
    }
}