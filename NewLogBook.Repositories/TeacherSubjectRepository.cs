using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewLogBook.AppContext;
using NewLogBook.Entities;
using NewLogBook.Repositories.interfaces;

namespace NewLogBook.Repositories
{
    public class TeacherSubjectRepository : DbRepository<TeacherSubject>, ITeacherSubjectRepository
    {
        public TeacherSubjectRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<bool> SaveCreateSubject(int teacherId, int subjectId)
        {
            TeacherSubject teacherSubject = new TeacherSubject{TeacherId = teacherId, SubjectId = subjectId};
            return await AddItemAsync(teacherSubject);
        }
    }
}
