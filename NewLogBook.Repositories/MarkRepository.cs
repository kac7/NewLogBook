using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewLogBook.Abstracrions;
using NewLogBook.AppContext;
using NewLogBook.Entities;
using NewLogBook.Models;
using NewLogBook.Repositories.interfaces;

namespace NewLogBook.Repositories
{
    public class MarkRepository : DbRepository<Mark>, IMarkRepository
    {
        public MarkRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<MarkModel> GetAddMark(int? id, IStudentRepository studentRepository ,ITeacherRepository teacherRepository, ITeacherSubjectRepository teacherSubject)
        {

            var student = await studentRepository.GetItemAsync(id);
            if (student == null)
            {
                return null;
            }

            var teacher = await teacherRepository.ToListAsync();
            var teacherSubj = await teacherSubject.AllItems.Include(z =>z.Teacher)
                .Include(x => x.Subject).ToListAsync();
            Dictionary<Teacher, List<Subject>> dictionary = new Dictionary<Teacher, List<Subject>>();
            foreach (var VARIABLE in teacher)
            {
                dictionary.Add(VARIABLE, new List<Subject>());
                foreach (var VAR in teacherSubj)
                {
                    if (VARIABLE.Id.Equals(VAR.TeacherId))
                    {
                        dictionary[VARIABLE].Add(VAR.Subject);
                    }
                }
            }
            MarkModel model = new MarkModel
            {
                Student = student,
                TeacherSubjects = teacherSubj,
                Dictionary = dictionary
            };
            return model.Clone() as MarkModel;
        }

        public async Task<bool> GetAddMarkPost(MarkModel model, ITeacherSubjectRepository teacherSubject)
        {
            var teacSubj =
                await teacherSubject.AllItems.FirstOrDefaultAsync(z => z.SubjectId == Int32.Parse(model.SubjectId));
            Mark mark = new Mark{StudentId = model.StudentId, TeacherSubjectId = teacSubj.Id, Value = Int32.Parse(model.Value)};
            return await AddItemAsync(mark);
        }
    }
}
