using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewLogBook.AppContext;
using NewLogBook.Entities;
using NewLogBook.Models;
using NewLogBook.Repositories.interfaces;

namespace NewLogBook.Repositories
{
    public class SubjectRepository : DbRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<List<Subject>> GetListSubject()
        {
            return await AllItems.Include(t => t.TeachersSubjects).ThenInclude(z => z.Teacher)
                .Include(x => x.TeachersSubjects).ThenInclude(c =>c.Subject).ToListAsync();
        }

        public async Task<SubjectModel> CreateSubject(ITeacherRepository teacherRepository)
        {
            SubjectModel model = new SubjectModel{Teachers = await teacherRepository.GetTeacher()};
            return model.Clone() as SubjectModel;
        }

        public async Task<bool> CreateSubjectPost(ITeacherSubjectRepository teacherSubject, SubjectModel model)
        {
            Subject subject = new Subject{Name = model.Name};
            if (!await AddItemAsync(subject))
            {
                return false;
            }

            Subject subjectId = await AllItems.OrderByDescending(z => z.Id).FirstOrDefaultAsync();
            return await teacherSubject.SaveCreateSubject(Int32.Parse(model.TeacherId), subjectId.Id);
        }

        public async Task<SubjectModel> EditSabject(int? id, ITeacherRepository teacherRepository)
        {
            if (id == null)
            {
                return null;
            }

            var subject = await AllItems.Include(t => t.TeachersSubjects).ThenInclude(z => z.Teacher)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (subject == null)
            {
                return null;
            }
            return new SubjectModel
            {
                Id = subject.Id, Name = subject.Name, TeachersSubjects = subject.TeachersSubjects,
                Teachers = await teacherRepository.GetTeacher()
            };
        }

        public async Task<bool> isEditSubjectPost(SubjectModel model, ITeacherSubjectRepository teacherSubject)
        {
            var subject = await GetItemAsync(model.Id);
            subject.Name = model.Name;
            if (!await UpdateItem(subject))
            {
                return false;
            }

            var teacherSub = await teacherSubject.AllItems.FirstOrDefaultAsync(z => z.SubjectId == subject.Id);
            teacherSub.TeacherId = Int32.Parse(model.TeacherId);
            return await teacherSubject.UpdateItem(teacherSub);
        }

        public async Task<Subject> DetailsSubject(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var subject = await AllItems.Include(t => t.TeachersSubjects).ThenInclude(z => z.Marks)
                .ThenInclude(x => x.Student).Include(z => z.TeachersSubjects).ThenInclude(x => x.Teacher)
                .FirstOrDefaultAsync(z => z.Id == id);
            return subject;
        }

        public async Task<bool> IsDeleteSubject(int? id)
        {
            if (id == null)
            {
                return false;
            }

            return await DeleteItemAsync(id);
        }
    }
}
