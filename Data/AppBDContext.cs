using Lifestyle_Preference_survey.Models;
using Microsoft.EntityFrameworkCore;

namespace Lifestyle_Preference_survey.Data
{
    public class AppBDContext:DbContext
    {
        public AppBDContext(DbContextOptions<AppBDContext> options):base(options)
        {
        }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Foods> Foods { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
