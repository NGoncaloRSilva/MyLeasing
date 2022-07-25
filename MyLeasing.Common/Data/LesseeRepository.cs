using Microsoft.EntityFrameworkCore;
using MyLeasing.Common.Data.Ententies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeasing.Common.Data
{
    public class LesseeRepository : GenericRepository<Lessee>, ILesseeRepository
    {
        private readonly DataContext _context;

        public LesseeRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return _context.Lessees.Include(p => p.User);
        }

        public async Task<Lessee> GetByIdAsyncWithUser(int id)
        {
            return await _context.Set<Lessee>().Include(p => p.User).FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
