namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_Draft_attribute2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Drafts", "RecieverMail", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Drafts", "RecieverMail", c => c.String(maxLength: 50));
        }
    }
}
