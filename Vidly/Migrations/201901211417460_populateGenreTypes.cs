namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenreTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GenreTypes ( Name) VALUES ( N'Action')");
            Sql("INSERT INTO GenreTypes ( Name) VALUES ( N'Comedy')");
            Sql("INSERT INTO GenreTypes ( Name) VALUES ( N'Family')");
            Sql("INSERT INTO GenreTypes ( Name) VALUES ( N'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
