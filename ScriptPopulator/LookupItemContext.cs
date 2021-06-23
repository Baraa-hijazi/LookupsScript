using Microsoft.EntityFrameworkCore;

namespace ScriptPopulator
{
    public class LookupItemContext : DbContext
    {
        public DbSet<LookupItem> LookupItems { get; set; }
        public DbSet<LookupType> LookupTypes { get; set; }
        
        private const string ConnectionString = "Server=.;Database=PSILookup;User=sa;Password=P@ssw0rd";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}