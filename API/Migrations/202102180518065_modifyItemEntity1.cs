namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyItemEntity1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tb_M_Item", "price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tb_M_Item", "price");
        }
    }
}
