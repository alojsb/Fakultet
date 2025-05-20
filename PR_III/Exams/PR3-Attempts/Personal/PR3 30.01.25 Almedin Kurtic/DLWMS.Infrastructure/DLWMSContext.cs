using DLWMS.Data;
using DLWMS.Data.IB220347;
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
        public DbSet<Predmet> Predmeti { get; set; }
        public DbSet<Spol> Spolovi { get; set; }
        public DbSet<Grad> Gradovi { get; set; }
        public DbSet<Drzava> Drzave { get; set; }
        public DbSet<Univerziteti> Univerziteti { get; set; }
        public DbSet<Razmjene> Razmjene { get; set; }
    }
}
