using DLWMS.Data;

using Microsoft.EntityFrameworkCore;

using System.Configuration;

namespace DLWMS.Infrastructure
{
    public class DLWMSContext : DbContext
    {
      
        //private string konekcijskiString = ConfigurationManager.ConnectionStrings["DLWMSBaza"].ConnectionString;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConfigurationManager.ConnectionStrings["DLWMSBaza"].ConnectionString);
        }

        public DbSet<Student> Studenti { get; set; }
        public DbSet<Drzava> Drzave { get; set; }
        public DbSet<Spol> Spol { get; set; }
        public DbSet<Grad> Gradovi { get; set; }


    }
}
