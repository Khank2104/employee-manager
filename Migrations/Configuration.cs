namespace EmployeeManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using EmployeeManager.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeManager.Data.EmployeeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EmployeeManager.Data.EmployeeContext context)
        {
            // Thêm dữ liệu mẫu nếu cần sau khi migrate
        }
    }
}
