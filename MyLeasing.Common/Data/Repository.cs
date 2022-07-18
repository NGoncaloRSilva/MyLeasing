using MyLeasing.Web.Data.Ententies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeasing.Common.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Owner> GetOwners()
        {
            return _context.Owners.OrderBy(p => p.FirstName);
        }

        public Owner GetOwner(int id)
        {
            return _context.Owners.Find(id);
        }

        public void AddProducts(Owner owner)
        {
            _context.Owners.Add(owner);
        }

        public void UpdateProduct(Owner owner)
        {
            _context.Owners.Update(owner);
        }

        public void RemoveProduct(Owner owner)
        {
            _context.Owners.Remove(owner);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool OwnerExists(int id)
        {
            return _context.Owners.Any(p => p.Id == id);
        }
    }
}
