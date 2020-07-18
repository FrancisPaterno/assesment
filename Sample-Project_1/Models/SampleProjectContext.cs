using MySql.Data.Entity;
using System.Data.Entity;
using Sample_Project_1.Models;

namespace Sample_Project_1.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class SampleProjectContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeStatus> EmployeeStatus { get; set; }

        public SampleProjectContext()
            : base("SampleProject") {
        }

        public static SampleProjectContext Create()
        {
            return new SampleProjectContext();
        }
    }
}