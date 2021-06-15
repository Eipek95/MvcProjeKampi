namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_myskills : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MySkills",
                c => new
                    {
                        mySkillsID = c.Int(nullable: false, identity: true),
                        mySkillsName = c.String(),
                        mySkillsPoint = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.mySkillsID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MySkills");
        }
    }
}
