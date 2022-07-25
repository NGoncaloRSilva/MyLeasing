using Microsoft.EntityFrameworkCore;
using MyLeasing.Web.Data.Ententies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeasing.Common.Data
{
    public class OwnerRepository : GenericRepository<Owner>, IOwnerRepository
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext Context): base(Context)
        {
            _context = Context;
        }

        public IQueryable GetAllWithUsers()
        {
            return _context.Owners.Include(p => p.User);
        }

        public  async Task<Owner> GetByIdAsyncWithUser(int id)
        {
            return await _context.Set<Owner>().Include(p => p.User).FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
