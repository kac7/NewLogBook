using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewLogBook.Abstracrions;
using NewLogBook.Entities;
using NewLogBook.Models;

namespace NewLogBook.Repositories.interfaces
{
    public interface IFacultieRepository : IDbRepository<Facultie>
    {
        Task<bool> CreateFacultie(FacultieModel faculty);
        Task<FacultieModel> FindFacultie(int? id);
        Task<bool> EditFacultie(FacultieModel faculty);
        Task<bool> DeleteFacultie(int? id);
        Task<Facultie> DetailsFacultie(int? id);
    }
}
