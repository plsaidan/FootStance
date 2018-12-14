namespace FootStance.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieReview",
                c => new
                    {
                        MovieReviewId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        MovieTitle = c.String(),
                        MovieReleaseYear = c.String(),
                        Director = c.String(),
                        MovieGenre = c.Int(nullable: false),
                        MovieStance = c.String(),
                        MovieRating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieReviewId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MovieReview");
        }
    }
}
