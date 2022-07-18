using MyLeasing.Web.Data.Ententies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyLeasing.Common.Data
{
    public interface IRepository
    {
        void AddProducts(Owner owner);
        Owner GetOwner(int id);
        IEnumerable<Owner> GetOwners();
        bool OwnerExists(int id);
        void RemoveProduct(Owner owner);
        Task<bool> SaveAllAsync();
        void UpdateProduct(Owner owner);
    }
}