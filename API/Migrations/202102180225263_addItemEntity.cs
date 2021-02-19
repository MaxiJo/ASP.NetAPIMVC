namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addItemEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tb_M_Item",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        quantity = c.Int(nullable: false),
                        supplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Tb_M_Supplier", t => t.supplierId, cascadeDelete: true)
                .Index(t => t.supplierId);
            
            CreateTable(
                "dbo.Tb_M_Supplier",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nama = c.String(maxLength: 6),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tb_M_Item", "supplierId", "dbo.Tb_M_Supplier");
            DropIndex("dbo.Tb_M_Item", new[] { "supplierId" });
            DropTable("dbo.Tb_M_Supplier");
            DropTable("dbo.Tb_M_Item");
        }
    }
}
