using System.Data.Entity; // cần thư viện này
using System.Data.Entity.ModelConfiguration.Conventions;
using EmployeeManager.Models; // namespace chứa class Employee
using System.Data.Entity.SqlServer;
using EmployeeManager.Data;

namespace EmployeeManager.Data
{
    public class EmployeeContext : DbContext
    {
        static EmployeeContext()
        {
            // Đảm bảo Provider được load trong project test
            var ensureDLLIsCopied = SqlProviderServices.Instance;
        }

        public DbSet<Employee> Employees { get; set; }

        public EmployeeContext() : base("name=EmployeeDB")
        {
        }
    }
}

