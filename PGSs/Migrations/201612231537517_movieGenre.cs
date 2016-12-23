namespace PGSs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movieGenre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Genre", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Genre");
        }
    }
}
