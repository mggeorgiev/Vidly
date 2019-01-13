namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameGenre1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GenreTypes", "Name", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.GenreTypes", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GenreTypes", "Genre", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.GenreTypes", "Name");
        }
    }
}
