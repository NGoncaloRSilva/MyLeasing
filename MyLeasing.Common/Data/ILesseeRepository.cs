using MyLeasing.Common.Data.Ententies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeasing.Common.Data
{
    public interface ILesseeRepository : IGenericRepository<Lessee>
    {
        public IQueryable GetAllWithUsers();

        //Task<Lessee> GetByIdAsyncWithUser(int id);
    }
}
