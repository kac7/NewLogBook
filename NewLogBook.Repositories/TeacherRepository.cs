using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewLogBook.AppContext;
using NewLogBook.Entities;
using NewLogBook.Models;
using NewLogBook.Repositories.interfaces;

namespace NewLogBook.Repositories
{
    public class TeacherRepository : DbRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<List<Teacher>> GetTeacher()
        {
            return await AllItems.Include(d => d.Department).Include(t => t.TeacherSubjects).ThenInclude(s => s.Subject).ToListAsync();
        }

        public async Task<TeacherModel> GetCreateTeacher(IDepartmentRepository repository)
        {
            var departaments = await repository.ToListAsync();
            TeacherModel model = new TeacherModel{Departments = departaments};
            return model.Clone() as TeacherModel;
        }

        public async Task<bool> CreateTeacherPost(TeacherModel model)
        {
            Teacher teacher = new Teacher
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DepartmentId = Int32.Parse(model.DepartmentId)
            };
            return await AddItemAsync(teacher);
        }

        public async Task<TeacherModel> GetEditTeacher(int? id, IDepartmentRepository departamentRepository)
        {
            if (id == null)
            {
                return null;
            }

            var teacher = await AllItems.Include(d => d.Department).FirstOrDefaultAsync(z => z.Id == id);
            if (teacher == null)
            {
                return null;
            }
            TeacherModel model = new TeacherModel
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Department = teacher.Department,
                Departments = await departamentRepository.ToListAsync()
            };
            return model.Clone() as TeacherModel;
        }

        public async Task<bool> EditTeacherPost(TeacherModel model)
        {
            var teacher = await GetItemAsync(model.Id);
            teacher.LastName = model.LastName;
            teacher.FirstName = model.FirstName;
            teacher.DepartmentId = Int32.Parse(model.DepartmentId);
            return await UpdateItem(teacher);
        }

        public async Task<Teacher> DetailsTeacher(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return await AllItems.Include(d => d.Department)
                .Include(t => t.TeacherSubjects)
                .ThenInclude(s => s.Subject)
                .FirstOrDefaultAsync(z => z.Id == id);
        }

        public async Task<bool> IsDeleteTeacher(int? id)
        {
            if (id == null)
            {
                return false;
            }

            return await DeleteItemAsync(id);
        }
    }
}
