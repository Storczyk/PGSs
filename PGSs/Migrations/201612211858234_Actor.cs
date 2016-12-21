namespace PGSs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Actor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Forename = c.String(),
                        Surname = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ActorMovies",
                c => new
                    {
                        Actor_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Actor_Id, t.Movie_Id })
                .ForeignKey("dbo.Actors", t => t.Actor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.Actor_Id)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActorMovies", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.ActorMovies", "Actor_Id", "dbo.Actors");
            DropIndex("dbo.ActorMovies", new[] { "Movie_Id" });
            DropIndex("dbo.ActorMovies", new[] { "Actor_Id" });
            DropTable("dbo.ActorMovies");
            DropTable("dbo.Actors");
        }
    }
}
