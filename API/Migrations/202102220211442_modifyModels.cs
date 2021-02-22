namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tb_M_Item", "supplierId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tb_M_Item", "supplierId", c => c.Int(nullable: false));
        }
    }
}
