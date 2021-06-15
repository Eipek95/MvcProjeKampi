﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_contact_readstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContactReadStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "ContactReadStatus");
        }
    }
}
