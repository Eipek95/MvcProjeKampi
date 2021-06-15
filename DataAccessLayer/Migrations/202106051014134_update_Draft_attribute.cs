namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_Draft_attribute : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drafts", "RecieverMail", c => c.String(maxLength: 50));
            AddColumn("dbo.Drafts", "MessageContent", c => c.String());
            DropColumn("dbo.Drafts", "Reciever");
            DropColumn("dbo.Drafts", "Message");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drafts", "Message", c => c.String());
            AddColumn("dbo.Drafts", "Reciever", c => c.String());
            DropColumn("dbo.Drafts", "MessageContent");
            DropColumn("dbo.Drafts", "RecieverMail");
        }
    }
}
