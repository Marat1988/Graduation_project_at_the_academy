namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewFieldPhoneNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PhoneNumber", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "PhoneNumber");
        }
    }
}
