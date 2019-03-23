using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewLogBook.Abstracrions;
using NewLogBook.Entities;
using NewLogBook.Models;

namespace NewLogBook.Repositories.interfaces
{
    public interface ISubjectRepository : IDbRepository<Subject>
    {
        Task<List<Subject>> GetListSubject();
        Task<SubjectModel> CreateSubject(ITeacherRepository teacherRepository);
        Task<bool> CreateSubjectPost(ITeacherSubjectRepository teacherSubject, SubjectModel model);
        Task<SubjectModel> EditSabject(int? id, ITeacherRepository teacherRepository);
        Task<bool> isEditSubjectPost(SubjectModel model, ITeacherSubjectRepository teacherSubject);
        Task<Subject> DetailsSubject(int? id);
        Task<bool> IsDeleteSubject(int? id);
    }
}
