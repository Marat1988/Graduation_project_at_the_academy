namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyForRecycler : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Recyclers", "ProductId");
            AddForeignKey("dbo.Recyclers", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recyclers", "ProductId", "dbo.Products");
            DropIndex("dbo.Recyclers", new[] { "ProductId" });
        }
    }
}
