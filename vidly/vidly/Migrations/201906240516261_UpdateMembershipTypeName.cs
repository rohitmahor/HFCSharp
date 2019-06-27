namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Membershiptypes SET Name='PAY AS YOU GO' WHERE Id = 1");
            Sql("UPDATE Membershiptypes SET Name='MONTHLY' WHERE Id = 2");
            Sql("UPDATE Membershiptypes SET Name='QUARTERLY' WHERE Id = 3");
            Sql("UPDATE Membershiptypes SET Name='ANNUAL' WHERE Id = 4");
        }
        
        public override void Down()
        {
            Sql("UPDATE MembershipTypes SET Name=''");
        }
    }
}
