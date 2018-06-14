namespace unclespace_ver3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "Category_Id", newName: "CategoryId");
            RenameIndex(table: "dbo.Products", name: "IX_Category_Id", newName: "IX_CategoryId");
            DropColumn("dbo.Products", "CatId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "CatId", c => c.Int());
            RenameIndex(table: "dbo.Products", name: "IX_CategoryId", newName: "IX_Category_Id");
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "Category_Id");
        }
    }
}
