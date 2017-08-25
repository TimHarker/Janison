namespace Janison.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "janison.Course",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Duration = c.Int(),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateModified = c.DateTime(precision: 7, storeType: "datetime2"),
                        Enabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID);
            
            CreateTable(
                "janison.Module",
                c => new
                    {
                        ModuleID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Duration = c.Int(),
                        DateCreated = c.DateTime(precision: 7, storeType: "datetime2"),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModuleID)
                .ForeignKey("janison.Course", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("janison.Module", "CourseID", "janison.Course");
            DropIndex("janison.Module", new[] { "CourseID" });
            DropTable("janison.Module");
            DropTable("janison.Course");
        }
    }
}
