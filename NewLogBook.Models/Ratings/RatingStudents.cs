using NewLogBook.AppContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewLogBook.Entities;

namespace NewLogBook.Models.Ratings
{
    public class RatingStudents
    {
        private AppDbContext _context;

        public RatingStudents(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetSortStudent()
        {
            List<Student> student = await _context.Students.Include(g => g.Group)
                .Include(m => m.Marks).ToListAsync();
            Student[] s = student.ToArray();
            Array.Sort(s, new SortedStudents());

            return s.ToList();
        }

        
    }
}
