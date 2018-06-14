namespace unclespace_ver3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "Category_Id1");
            RenameIndex(table: "dbo.Products", name: "IX_CategoryId", newName: "IX_Category_Id1");
            AddColumn("dbo.Products", "Category_Id", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Category_Id");
            RenameIndex(table: "dbo.Products", name: "IX_Category_Id1", newName: "IX_CategoryId");
            RenameColumn(table: "dbo.Products", name: "Category_Id1", newName: "CategoryId");
        }
    }
}
