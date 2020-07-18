namespace Sample_Project_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Employee_Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(unicode: false),
                        Lastname = c.String(unicode: false),
                        MiddleInitial = c.String(unicode: false),
                        BasicSalary = c.Double(nullable: false),
                        Position = c.String(unicode: false),
                        SSS = c.String(unicode: false),
                        PhilHealth = c.String(unicode: false),
                        EmployeeStatusStatus_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Employee_Id)
                .ForeignKey("dbo.EmployeeStatus", t => t.EmployeeStatusStatus_id, cascadeDelete: true)
                .Index(t => t.EmployeeStatusStatus_id);
            
            CreateTable(
                "dbo.EmployeeStatus",
                c => new
                    {
                        Status_id = c.Int(nullable: false, identity: true),
                        Status = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Status_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "EmployeeStatusStatus_id", "dbo.EmployeeStatus");
            DropIndex("dbo.Employees", new[] { "EmployeeStatusStatus_id" });
            DropTable("dbo.EmployeeStatus");
            DropTable("dbo.Employees");
        }
    }
}
