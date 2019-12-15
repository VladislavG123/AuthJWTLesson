using AuthJWTLesson.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthJWTLesson.DataAccess
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions options) : base(options)
        {
            //автомигрирования
            Database.Migrate();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Username = "Volodya89",
                Password = "123123"
            });
        }
        /*
             Migrations
         1) Nuget: entity tools, entity design
         2) Add-Migration Initial
         
         */
    }
}
