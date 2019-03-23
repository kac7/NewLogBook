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
    public class StudentRepository : DbRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<StudentModel> CreateStudent(IGroupRepository groupRepository)
        {
            var groups = await groupRepository.ToListAsync();
            StudentModel model = new StudentModel{Groups =  groups};
            return model.Clone() as StudentModel;
        }

        public async Task<bool> CreateStudentPost(StudentModel model)
        {
            Student student = new Student{FirstName = model.FirstName, LastName = model.LastName,
                GroupId = Int32.Parse(model.GroupId)};
            return await AddItemAsync(student);
        }

        public async Task<StudentModel> GetEditStudent(IGroupRepository groupRepository, int? id)
        {
            if (id == null)
            {
                return null;
            }

            var student = await AllItems.Include(g => g.Group)
                .Include(m => m.Marks).FirstOrDefaultAsync(z => z.Id == id);
            if (student == null)
            {
                return null;
            }
            StudentModel model = new StudentModel
            {
                Id = student.Id, FirstName = student.FirstName, LastName = student.LastName, 
                Group = student.Group, Groups = await groupRepository.ToListAsync()
            };
            return model.Clone() as StudentModel;
        }

        public async Task<bool> EditStudentPost(StudentModel model)
        {
            var student = await GetItemAsync(model.Id);
            student.FirstName = model.FirstName;
            student.LastName = model.LastName;
            student.GroupId = Int32.Parse(model.GroupId);
            return await SaveChangesAsync() > 0;
        }

        public async Task<Student> DetailsStudent(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var student = await AllItems.Include(g => g.Group)
                .Include(m => m.Marks).ThenInclude(z =>z.TeacherSubject).ThenInclude(x =>x.Subject).FirstOrDefaultAsync(z => z.Id == id);
            return student;
        }

        public async Task<bool> IsDeleteStudent(int? id)
        {
            if (id == null)
            {
                return false;
            }

            return await DeleteItemAsync(id);
        }
    }
}
