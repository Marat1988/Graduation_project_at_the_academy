using Store.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Store.Repository.Recyclers
{
    public interface IRecyclerRepository
    {
        List<RecyclerViewModel> GetShowRecycler();
        Task<JsonResult> Add(int productId);
        Task Update(RecyclerViewModel recyclerViewModel);
        Task Delete (int Id);
    }
}
