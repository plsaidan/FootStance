namespace FootStance.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class soup : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MovieReview", "MovieTitle", c => c.String(nullable: false));
            AlterColumn("dbo.MovieReview", "MovieReleaseYear", c => c.String(nullable: false));
            AlterColumn("dbo.MovieReview", "Director", c => c.String(nullable: false));
            AlterColumn("dbo.MovieReview", "MovieStance", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MovieReview", "MovieStance", c => c.String());
            AlterColumn("dbo.MovieReview", "Director", c => c.String());
            AlterColumn("dbo.MovieReview", "MovieReleaseYear", c => c.String());
            AlterColumn("dbo.MovieReview", "MovieTitle", c => c.String());
        }
    }
}
