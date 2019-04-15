namespace wawishapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnBirthdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birthdate", c => c.DateTime(nullable: false));
            Sql("UPDATE Customers SET Birthdate = '2012-07-11' WHERE Id = 1");
            Sql("UPDATE Customers SET Birthdate = '2016-10-25' WHERE Id = 2");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Birthdate");
        }
    }
}
