namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies(Name, Genre, ReleaseDate, DateAdded, NumStocks) VALUES('Hangover', 'Comedy', CAST('06-26-2009' AS DATETIME), CAST('08-26-2019' AS DATETIME), 5)");
            Sql("INSERT INTO Movies(Name, Genre, ReleaseDate, DateAdded, NumStocks) VALUES('Die Hard', 'Action', CAST('07-12-1988' AS DATETIME), CAST('05-16-2019' AS DATETIME), 1)");
            Sql("INSERT INTO Movies(Name, Genre, ReleaseDate, DateAdded, NumStocks) VALUES('The Terminator', 'Action', CAST('10-26-1984' AS DATETIME), CAST('01-16-2009' AS DATETIME), 3)");
            Sql("INSERT INTO Movies(Name, Genre, ReleaseDate, DateAdded, NumStocks) VALUES('Toy Story', 'Family', CAST('06-21-2019' AS DATETIME), CAST('06-22-2019' AS DATETIME), 2)");
            Sql("INSERT INTO Movies(Name, Genre, ReleaseDate, DateAdded, NumStocks) VALUES('Titanic', 'Romance', CAST('11-18-1997' AS DATETIME), CAST('01-12-2018' AS DATETIME), 5)");
        }
        
        public override void Down()
        {
            Sql("TRUMCATE TABLE Movies");
        }
    }
}
