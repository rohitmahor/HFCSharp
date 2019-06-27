namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCheckOnNumStock : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Movies " +
                "ADD CONSTRAINT CheckNumStocks CHECK(NumStocks >= 0)");
        }
        
        public override void Down()
        {
            Sql("ALTER TABLE Movies" +
                "DROP CONSTRAINT CheckNumStocks");
        }
    }
}
