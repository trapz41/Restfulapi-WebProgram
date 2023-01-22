using System.Data.Entity;

namespace WebApplication2.Models
{
    public class HaberdBContext:DbContext
    {

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Haberler> Haberlers { get; set; }
    }
}
