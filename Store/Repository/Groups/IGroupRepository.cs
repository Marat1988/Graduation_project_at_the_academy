using Store.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Repository
{
    public interface IGroupRepository
    {
        List<GroupViewModel> GetAllGroups();

        IQueryable GetAllGroupsChoose();

        Task Add(GroupViewModel group);

        Task Update(GroupViewModel group);

        Task Delete(int Id);
    }
}