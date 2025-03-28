
using gp_backend.Core.Models;
using gp_backend.EF.MySql.Data;
using gp_backend.EF.MySql.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace gp_backend.EF.MySql.Repositories
{
    public class PharmacyRepo : IPharmacyRepo
    {
        private readonly MySqlDbContext _context;
        public PharmacyRepo(MySqlDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pharmacy>> GetAll(string location)
        {
            var pharmacies = await _context.Pharmacies.Include(p => p.Doctor).Where(p => p.Location == location).ToListAsync();
            return pharmacies;
        }

        public async Task<Pharmacy> GetById(int id)
        {
            var pharmacy = await _context.Pharmacies.Include(p => p.Doctor).FirstOrDefaultAsync(p => p.Id == id);
            return pharmacy;
        }

        public async Task Insert(Pharmacy model)
        {
           var ph = await _context.Pharmacies.AddAsync(model);
        }
        public async Task<int> SaveChanges()
        {
            int rows = await _context.SaveChangesAsync();
            return rows;
        }
    }
}
