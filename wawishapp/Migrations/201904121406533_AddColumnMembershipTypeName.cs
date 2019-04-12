namespace wawishapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "MembershipName", c => c.String());
            Sql("UPDATE MembershipTypes SET MembershipName = 'No Pay' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET MembershipName = 'Basic' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET MembershipName = 'Premium' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET MembershipName = 'VIP' WHERE Id = 4");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "MembershipName");
        }
    }
}
