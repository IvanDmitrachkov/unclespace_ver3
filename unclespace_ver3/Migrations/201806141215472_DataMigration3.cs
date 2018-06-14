namespace unclespace_ver3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "Category_Id1", newName: "CategoryId");
            RenameIndex(table: "dbo.Products", name: "IX_Category_Id1", newName: "IX_CategoryId");
            DropColumn("dbo.Products", "Category_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Category_Id", c => c.Int());
            RenameIndex(table: "dbo.Products", name: "IX_CategoryId", newName: "IX_Category_Id1");
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "Category_Id1");
        }
    }
}
