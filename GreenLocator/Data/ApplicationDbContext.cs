using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GreenLocator.Models;

namespace GreenLocator.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Appliance>? Appliance { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<Review>? Reviews { get; set; }
        public DbSet<Rating>? Ratings { get; set; }
        public DbSet<GreenLocator.Models.Report>? Report { get; set; }
        //public DbSet<GreenLocator.Models.AspNetUser>? Users { get; set; }

        
    }
}