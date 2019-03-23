using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewLogBook.Abstracrions;
using NewLogBook.Entities;
using NewLogBook.Models;

namespace NewLogBook.Repositories.interfaces
{
    public interface IGroupRepository : IDbRepository<Group>
    {
        Task<List<Group>> ShowListGroups();
        Task<GroupModel> GetCreateGroup(IFacultieRepository facultieRepository);
        Task<bool> CreateGroupPost(GroupModel model);
        Task<GroupModel> GetEditGroup(IFacultieRepository facultieRepository, int? id);
        Task<bool> EditGroupPost(GroupModel model);
        Task<Group> DetailsGroup(int? id);
        Task<bool> DeleteGroup(int? id);
    }
}
