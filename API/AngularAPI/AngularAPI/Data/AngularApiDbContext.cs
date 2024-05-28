using AngularAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AngularAPI.Data
{
    public class AngularApiDbContext : DbContext
    {
        public AngularApiDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
