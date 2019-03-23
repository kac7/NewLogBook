using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewLogBook.Abstracrions;
using NewLogBook.Entities;
using NewLogBook.Models;

namespace NewLogBook.Repositories.interfaces
{
    public interface IDepartmentRepository : IDbRepository<Department>
    {
        Task<bool> CreateDepartamentPost(DepartmentModel model);
        Task<DepartmentModel> GetEditDepartment(int? id);
        Task<bool> EditDepartmentPost(DepartmentModel model);
        Task<Department> DetailsDepartment(int? id);
        Task<bool> IsDeleteDepartment(int? id);
    }
}
