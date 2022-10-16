using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        public DbSet<ProLang> ProLangs { get; set; }
        public DbSet<ProTechnology> ProTechnologies{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProLang>(p =>
            {
                p.ToTable("ProLangs").HasKey(k => k.Id);
                p.Property(k => k.Id).HasColumnName("Id");
                p.Property(k => k.Name).HasColumnName("Name");
                p.HasIndex(k => k.Name).IsUnique();
            });
            modelBuilder.Entity<ProTechnology>(p =>
            {
                p.ToTable("ProTechnologies").HasKey(k => k.Id);
                p.Property(k => k.Id).HasColumnName("Id");
                p.Property(k => k.Name).HasColumnName("Name");
                p.HasIndex(k => k.Name).IsUnique();
                p.HasOne(k => k.ProLang).WithMany(k => k.ProTechnologies).HasForeignKey(k => k.ProLangId);
            });
        }
    }
}
