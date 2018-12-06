namespace FootStance.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameReview",
                c => new
                    {
                        GameReviewId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        GameTitle = c.String(nullable: false),
                        GameDeveloper = c.String(nullable: false),
                        Platform = c.Int(nullable: false),
                        GameGenre = c.Int(nullable: false),
                        GameReleaseYear = c.Int(nullable: false),
                        GameStance = c.String(nullable: false),
                        GameRating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameReviewId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GameReview");
        }
    }
}
