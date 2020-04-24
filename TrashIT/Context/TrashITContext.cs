using Microsoft.EntityFrameworkCore;
using TrashIT.Models;

namespace TrashIT.Context
{
    public class TrashITContext : DbContext
    {

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<ObjectToRecycle> Objects { get; set; }


        public TrashITContext()
        {
        }

        public TrashITContext(DbContextOptions<TrashITContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            builder.UseLazyLoadingProxies();
        }
    }
}
