using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using OnlineBanking.Models;

namespace OnlineBanking.DAL
{
    public class BankingContext : DbContext
    {

        public BankingContext() : base("BankingContext")
        {
        }

        public DbSet<Konto> Konto { get; set; }
        public DbSet<KontoTyp> KontoTyp { get; set; }
        public DbSet<Kunde> Kunde { get; set; }
        public DbSet<KundeKonto> KundeKonto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}