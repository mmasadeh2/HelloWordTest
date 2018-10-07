using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MVCHelloWorldEntity.Models.Mapping;

namespace MVCHelloWorldEntity.Models
{
    public partial class MVCHelloWorldContext : DbContext
    {
        static MVCHelloWorldContext()
        {
            Database.SetInitializer<MVCHelloWorldContext>(null);
        }

        public MVCHelloWorldContext()
            : base("Name=MVCHelloWorldContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new GenderMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
        }
    }
}
