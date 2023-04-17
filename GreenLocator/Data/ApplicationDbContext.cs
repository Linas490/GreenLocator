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
        public DbSet<GreenLocator.Models.Shareable>? Shareable { get; set; }
        public DbSet<GreenLocator.Models.User>? User { get; set; }
    }
}