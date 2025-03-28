
using gp_backend.Core.Models;

namespace gp_backend.EF.MySql.Repositories.Interfaces
{
    public interface IPharmacyRepo
    {
        Task Insert(Pharmacy model);
        Task<List<Pharmacy>> GetAll(string location);
        Task<Pharmacy> GetById(int id);
        Task<int> SaveChanges();
    }
}
