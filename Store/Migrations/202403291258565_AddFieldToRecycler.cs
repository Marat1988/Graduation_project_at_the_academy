namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldToRecycler : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recyclers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Recyclers", new[] { "UserId" });
            AddColumn("dbo.Recyclers", "UserIdAnonymous", c => c.String());
            AlterColumn("dbo.Recyclers", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Recyclers", "UserId");
            AddForeignKey("dbo.Recyclers", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recyclers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Recyclers", new[] { "UserId" });
            AlterColumn("dbo.Recyclers", "UserId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Recyclers", "UserIdAnonymous");
            CreateIndex("dbo.Recyclers", "UserId");
            AddForeignKey("dbo.Recyclers", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
