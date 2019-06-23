namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMovie : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MOVIES(Id, Name, Genre, ReleasedDate, DateAdded, NumStocks) VALUES(1, Hangover, Comedy, )")
        }
        
        public override void Down()
        {
        }
    }
}
