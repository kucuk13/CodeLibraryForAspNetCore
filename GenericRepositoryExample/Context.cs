using GenericRepositoryExample.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericRepositoryExample
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host = localhost; Database = code_library; Username = postgres; Password = 123");

        public DbSet<Departmant> Departmant { get; set; }
        public DbSet<Employee> Employee { get; set; }
    }
}
