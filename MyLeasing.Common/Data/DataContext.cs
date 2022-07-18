using Microsoft.EntityFrameworkCore;
using MyLeasing.Web.Data.Ententies;

namespace MyLeasing.Common
{
    public class DataContext : DbContext
    {
        public DbSet<Owner> Owners { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
