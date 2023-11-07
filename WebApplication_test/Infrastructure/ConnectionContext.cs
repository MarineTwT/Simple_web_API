using Microsoft.EntityFrameworkCore;
using WebAPI.Domains.Model.EmployeeAggregate;

namespace WebApplication_test.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(
            "Server=DESKTOP-TP5UL0K\\SQLEXPRESS;" +
            "Database=Empresa_teste;" +
            "Trusted_Connection=True;" +
            "MultipleActiveResultSets=true;" +
            "TrustServerCertificate=true");
            
        
    }
}
