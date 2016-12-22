namespace PGSs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActorDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "Birthdate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actors", "Birthdate");
        }
    }
}
