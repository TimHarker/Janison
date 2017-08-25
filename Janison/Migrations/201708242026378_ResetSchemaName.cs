namespace Janison.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResetSchemaName : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "janison.Course", newSchema: "dbo");
            MoveTable(name: "janison.Module", newSchema: "dbo");
        }
        
        public override void Down()
        {
            MoveTable(name: "dbo.Module", newSchema: "janison");
            MoveTable(name: "dbo.Course", newSchema: "janison");
        }
    }
}
