using Microsoft.EntityFrameworkCore;
using RpaChallengeImpacta.Domain.Models;
using RpaChallengerImpacta.DataAccess.Map;


namespace RpaChallengerImpacta.DataAccess.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Proxy> Proxies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProxyMap());
        }
    }
}
