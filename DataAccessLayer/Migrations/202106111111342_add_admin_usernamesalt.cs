namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_admin_usernamesalt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "PasswordSalt", c => c.String());
            AddColumn("dbo.Admins", "UsernameSalt", c => c.String());
            AlterColumn("dbo.Admins", "AdminUserName", c => c.String(maxLength: 100));
            DropColumn("dbo.Admins", "Salt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "Salt", c => c.String());
            AlterColumn("dbo.Admins", "AdminUserName", c => c.String(maxLength: 50));
            DropColumn("dbo.Admins", "UsernameSalt");
            DropColumn("dbo.Admins", "PasswordSalt");
        }
    }
}
