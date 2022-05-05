using Microsoft.EntityFrameworkCore;
using MigrationExample.Helpers;

namespace MigrationExample.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(AppSettingsHelper.GetValue("ConnectionString:Context"));
        }


        //Initial Data 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departmant>().HasData(
                SeedDataHelper.GetInitialDepartmantData()
            );

            modelBuilder.Entity<Employee>().HasData(
                SeedDataHelper.GetInitialEmployeeData()
            );
        }

        public DbSet<Departmant> Departmant { get; set; }
        public DbSet<Employee> Employee { get; set; }
    }
}
