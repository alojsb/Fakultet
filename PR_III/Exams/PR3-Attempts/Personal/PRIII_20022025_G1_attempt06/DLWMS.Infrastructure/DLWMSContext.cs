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
        public DbSet<StipendijaBrojIndeksa> StipendijeBrojIndeksa { get; set; }
        public DbSet<StipendijaGodinaBrojIndeksa> StipendijeGodineBrojIndeksa{ get; set; }
        public DbSet<StudentStipendijaBrojIndeksa> StudentiStipendijeBrojIndeksa { get; set; }
    }
}
