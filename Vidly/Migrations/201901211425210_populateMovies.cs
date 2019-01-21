namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies ( Name, GenreTypeId, ReleaseDate, DateAdded, NumberInStock) VALUES ( N'Shrek!', 3, NULL, NULL, 0)");
            Sql("INSERT INTO Movies ( Name, GenreTypeId, ReleaseDate, DateAdded, NumberInStock) VALUES ( N'Wall-e', 3, NULL, NULL, 0)");
            Sql("INSERT INTO Movies ( Name, GenreTypeId, ReleaseDate, DateAdded, NumberInStock) VALUES ( N'Hangover', 2, N'2009-11-06 00:00:00', N'2016-05-04 00:00:00', 5)");
            Sql("INSERT INTO Movies ( Name, GenreTypeId, ReleaseDate, DateAdded, NumberInStock) VALUES ( N'Die Hard', 1, NULL, NULL, 0)");
            Sql("INSERT INTO Movies ( Name, GenreTypeId, ReleaseDate, DateAdded, NumberInStock) VALUES ( N'The Terminator', 1, NULL, NULL, 0)");
            Sql("INSERT INTO Movies ( Name, GenreTypeId, ReleaseDate, DateAdded, NumberInStock) VALUES ( N'Toy Story', 3, NULL, NULL, 0)");
            Sql("INSERT INTO Movies ( Name, GenreTypeId, ReleaseDate, DateAdded, NumberInStock) VALUES ( N'Titanic', 4, NULL, NULL, 0)");
            Sql("INSERT INTO Movies ( Name, GenreTypeId, ReleaseDate, DateAdded, NumberInStock) VALUES ( N'New Test Movie', 1, N'2019-01-12 00:00:00', N'2019-01-12 00:00:00', 1)");
            Sql("INSERT INTO Movies ( Name, GenreTypeId, ReleaseDate, DateAdded, NumberInStock) VALUES ( N'New Test Movie2', 2, N'2019-01-11 00:00:00', N'2019-01-12 00:00:00', 1)");
            Sql("INSERT INTO Movies ( Name, GenreTypeId, ReleaseDate, DateAdded, NumberInStock) VALUES ( N'New Test Movie3', 2, N'2019-01-12 00:00:00', N'2019-01-13 00:00:00', 10)");
        }

        public override void Down()
        {
        }
    }
}
