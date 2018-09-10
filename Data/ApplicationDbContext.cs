using JobberApp.Data.Models;
using JobberApp.Data.Models.Employee;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobberApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Message> Messages { get; set; }    
        public DbSet<Card> Cards { get; set; }    
        public DbSet<JobAd> JobAds { get; set; }
        public DbSet<Location> Locations { get; set; }        
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Token> Tokens { get; set; }

    }
}