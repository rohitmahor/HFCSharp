namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomerData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers(Name, IsSubscribedToNewsLetter, MembershipTypeId, BirthDate) VALUES('Jhon Williams', 0, 1, CAST('01-10-2010' AS DATETIME))");
            Sql("INSERT INTO Customers(Name, IsSubscribedToNewsLetter, MembershipTypeId, BirthDate) VALUES('Rowan Miller', 1, 2, CAST('10-12-2000' AS DATETIME))");
            Sql("INSERT INTO Customers(Name, IsSubscribedToNewsLetter, MembershipTypeId, BirthDate) VALUES('Baredly Cooper', 1, 3, CAST('02-05-1985' AS DATETIME))");
            Sql("INSERT INTO Customers(Name, IsSubscribedToNewsLetter, MembershipTypeId, BirthDate) VALUES('Jasprit Bumrah', 1, 4, CAST('06-06-2000' AS DATETIME))");
        }
        
        public override void Down()
        {
            Sql("TRUNCATE TABLE Customers");
        }
    }
}
