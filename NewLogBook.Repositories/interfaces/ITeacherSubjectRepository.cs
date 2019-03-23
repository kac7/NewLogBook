using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewLogBook.Abstracrions;
using NewLogBook.Entities;

namespace NewLogBook.Repositories.interfaces
{
    public interface ITeacherSubjectRepository : IDbRepository<TeacherSubject>
    {
        Task<bool> SaveCreateSubject(int teacherId, int subjectId);
    }
}
