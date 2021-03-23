namespace GeneralStoreMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.Transactions", "InventoryCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "InventoryCount", c => c.Int(nullable: false));
            DropColumn("dbo.Transactions", "Quantity");
        }
    }
}
