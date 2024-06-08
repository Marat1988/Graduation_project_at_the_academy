using Store.Repository.Recyclers;
using Store.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Store.Service
{
    public class RecyclerService
    {
        private readonly IRecyclerRepository _recyclerRepository;

        public RecyclerService(IRecyclerRepository recyclerRepository) => _recyclerRepository = recyclerRepository;
        public List<RecyclerViewModel> GetShowRecycler() => _recyclerRepository.GetShowRecycler();
        public Task<JsonResult> Add(int productId) => _recyclerRepository.Add(productId);
        public Task Update(RecyclerViewModel recyclerViewModel) => _recyclerRepository.Update(recyclerViewModel);
        public Task Delete(int Id) => _recyclerRepository.Delete(Id);
    }
}