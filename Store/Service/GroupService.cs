using Store.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.ViewModel;
using System.Linq;

namespace Store.Service
{
    public class GroupService
    {
        private readonly IGroupRepository _groupRepository;

        public GroupService(IGroupRepository groupRepository) => _groupRepository = groupRepository;

        public List<GroupViewModel> GetAllGroups() => _groupRepository.GetAllGroups();

        public IQueryable GetAllGroupsChoose() => _groupRepository.GetAllGroupsChoose();

        public Task Add(GroupViewModel group) => _groupRepository.Add(group);

        public Task Update(GroupViewModel group) => _groupRepository.Update(group);

        public Task Delete (int Id) => _groupRepository.Delete(Id); 
    }
}