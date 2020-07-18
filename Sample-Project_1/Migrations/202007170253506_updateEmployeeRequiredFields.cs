namespace Sample_Project_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateEmployeeRequiredFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Employees", "Position", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("Employees", "Position", c => c.String(unicode: false));
        }
    }
}
