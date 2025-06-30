using DLWMS.Data;
using DLWMS.Data.IspitBrojIndeksa;
using Microsoft.EntityFrameworkCore;

using System.Configuration;

namespace DLWMS.Infrastructure
{
    public class DLWMSContext : DbContext
    {
      
        private string konekcijskiString = ConfigurationManager.ConnectionStrings["DLWMSBaza"].ConnectionString;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(konekcijskiString);
        }

        public DbSet<Student> Studenti { get; set; }
        public DbSet<Drzava> Drzave { get; set; }
        public DbSet<Grad> Gradovi { get; set; }
        public DbSet<Spol> SpoloviBrojIndeksa { get; set; }
        public DbSet<UniverzitetBrojIndeksa> UniverzitetiBrojIndeksa { get; set; }
        public DbSet<RazmjenaBrojIndeksa> RazmjeneBrojIndeksa { get; set; }

    }
}
