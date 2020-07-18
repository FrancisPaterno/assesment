namespace Sample_Project_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateEmployeeColumns : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Employees", "Firstname", c => c.String(nullable: false, unicode: false));
            AlterColumn("Employees", "Lastname", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("Employees", "Lastname", c => c.String(unicode: false));
            AlterColumn("Employees", "Firstname", c => c.String(unicode: false));
        }
    }
}
