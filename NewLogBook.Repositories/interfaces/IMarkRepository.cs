using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewLogBook.Abstracrions;
using NewLogBook.Entities;
using NewLogBook.Models;

namespace NewLogBook.Repositories.interfaces
{
    public interface IMarkRepository : IDbRepository<Mark>
    {
        Task<MarkModel> GetAddMark(int? id, IStudentRepository studentRepository ,ITeacherRepository teacherRepository, ITeacherSubjectRepository teacherSubject);
        Task<bool> GetAddMarkPost(MarkModel model, ITeacherSubjectRepository teacherSubject);
    }
}
