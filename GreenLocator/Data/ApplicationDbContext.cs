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
        public DbSet<GreenLocator.Models.Appliance>? Appliance { get; set; }
        public DbSet<GreenLocator.Models.Post>? Posts { get; set; }
        public DbSet<GreenLocator.Models.Review>? Reviews { get; set; }
        public DbSet<GreenLocator.Models.Rating>? Ratings { get; set; }
        //public DbSet<GreenLocator.Models.AspNetUser>? Users { get; set; }

        
    }
}