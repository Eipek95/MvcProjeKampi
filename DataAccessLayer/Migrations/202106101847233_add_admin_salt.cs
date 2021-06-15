namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_admin_salt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Salt", c => c.String());
            AlterColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 50));
            DropColumn("dbo.Admins", "Salt");
        }
    }
}
