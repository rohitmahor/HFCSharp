namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBirthDate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET BirthDate = CAST('1980-01-01' AS DATETIME)  WHERE Id=5");
            Sql("UPDATE Customers SET BirthDate = CAST('1986-10-01' AS DATETIME)  WHERE Id=6");
        }
        
        public override void Down()
        {
            Sql("UPDATE Customers SET BirthDate = NULL");
        }
    }
}
