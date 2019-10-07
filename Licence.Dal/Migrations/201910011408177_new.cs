namespace Licence.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_OpenLessons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NumberofRecords = c.Int(nullable: false),
                        LessonInfo = c.String(),
                        LessonCreateUser = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_ProfileInfo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Expertise = c.String(),
                        Interest = c.String(),
                        SchoolInfo = c.String(),
                        BusinessInfo = c.String(),
                        Balance = c.Single(nullable: false),
                        IsBanned = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_StartUserInfo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        Telephone = c.Int(nullable: false),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_StartUserInfo");
            DropTable("dbo.tbl_ProfileInfo");
            DropTable("dbo.tbl_OpenLessons");
        }
    }
}
