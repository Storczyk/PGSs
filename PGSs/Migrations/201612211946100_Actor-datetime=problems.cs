namespace PGSs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Actordatetimeproblems : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Actors", "DateOfBirth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Actors", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
