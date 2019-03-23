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
    public class DepartmentRepository : DbRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<bool> CreateDepartamentPost(DepartmentModel model)
        {
            Department departament = new Department{Name = model.Name};
            return await AddItemAsync(departament);
        }

        public async Task<DepartmentModel> GetEditDepartment(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var departament = await GetItemAsync(id);
            if (departament == null)
            {
                return null;
            }
            return new DepartmentModel{Name = departament.Name};
        }

        public async Task<bool> EditDepartmentPost(DepartmentModel model)
        {
            var departament = await GetItemAsync(model.Id);
            departament.Name = model.Name;
            return await UpdateItem(departament);
        }

        public async Task<Department> DetailsDepartment(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var departament = AllItems.Include(t => t.Teachers).FirstOrDefaultAsync(z => z.Id == id);
            return await departament;
        }

        public async Task<bool> IsDeleteDepartment(int? id)
        {
            if (id == null)
            {
                return false;
            }

            return await DeleteItemAsync(id);
        }
    }
}
