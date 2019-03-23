using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewLogBook.Abstracrions;
using NewLogBook.Entities;
using NewLogBook.Models;

namespace NewLogBook.Repositories.interfaces
{
    public interface IStudentRepository : IDbRepository<Student>
    {
        Task<StudentModel> CreateStudent(IGroupRepository groupRepository);
        Task<bool> CreateStudentPost(StudentModel model);
        Task<StudentModel> GetEditStudent(IGroupRepository groupRepository, int? id);
        Task<bool> EditStudentPost(StudentModel model);
        Task<Student> DetailsStudent(int? id);
        Task<bool> IsDeleteStudent(int? id);
    }
}
