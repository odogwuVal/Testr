using Testr.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Testr.Infrastructure.Authentication
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .Property("Id").UseIdentityColumn();

            builder.Entity<ApplicationRole>()
                .Property("Id").UseIdentityColumn();

            builder.Entity<Candidate>()
                .HasOne(c => c.User)
                .WithOne();

            builder.Entity<Administrator>()
               .HasOne(a => a.User)
               .WithOne();

            builder.Entity<Cycle>()
               .HasOne(c => c.CreatedBy)
               .WithMany();
        }

           public DbSet<Candidate> Candidates { get; set; }
        
           public DbSet<Administrator> Administrators { get; set; }
        
           public DbSet<Cycle> Cycles { get; set; }
    }
}
