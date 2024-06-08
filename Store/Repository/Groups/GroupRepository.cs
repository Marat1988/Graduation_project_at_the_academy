using Store.Infrastructure;
using Store.Models;
using Store.Service;
using Store.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Repository
{
    public class GroupRepository : IDisposable, IGroupRepository
    {
        private readonly AppIdentityDbContext db = new AppIdentityDbContext();

        public List<GroupViewModel> GetAllGroups()
        {
            List<GroupViewModel> groups = new List<GroupViewModel>();
            foreach (var item in db.Groups)
            {
                groups.Add(new GroupViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                });
            }
            return groups;
        }

        public IQueryable GetAllGroupsChoose()
        {
            return (from p in db.Groups
                    select new { p.Id, p.Name })
                                .Union(from p in db.Groups
                                       select new { Id = 0, Name = "Все группы" })
                                .OrderBy(x => x.Id)
                                .ThenBy(x => x.Name);
        }

        public async Task Add(GroupViewModel group)
        {
            db.Groups.Add(new Group()
            {
                Name = group.Name,
            });
            await db.SaveChangesAsync();
        }

        public async Task Update(GroupViewModel groupViewModel)
        {
            var group = await db.Groups.Where(item => item.Id == groupViewModel.Id).FirstOrDefaultAsync();
            group.Name = groupViewModel.Name;
            await db.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var entity = await db.Groups.FindAsync(Id);
            db.Groups.Remove(entity);
            await db.SaveChangesAsync();
        }

        public void Dispose() => db?.Dispose();
    }
}