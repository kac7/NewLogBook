using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewLogBook.Abstracrions;
using NewLogBook.Entities;
using NewLogBook.Models;

namespace NewLogBook.Repositories.interfaces
{
    public interface ITeacherRepository : IDbRepository<Teacher>
    {
        Task<List<Teacher>> GetTeacher();
        Task<TeacherModel> GetCreateTeacher(IDepartmentRepository repository);
        Task<bool> CreateTeacherPost(TeacherModel model);
        Task<TeacherModel> GetEditTeacher(int? id, IDepartmentRepository departmentRepository);
        Task<bool> EditTeacherPost(TeacherModel model);
        Task<Teacher> DetailsTeacher(int? id);
        Task<bool> IsDeleteTeacher(int? id);
    }
}
