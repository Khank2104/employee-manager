namespace EmployeeManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddParkingLotNameToEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "ParkingLotName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "ParkingLotName");
        }
    }
}
