namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyItemEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tb_M_Item", "nama", c => c.String());
            DropColumn("dbo.Tb_M_Item", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tb_M_Item", "Name", c => c.String());
            DropColumn("dbo.Tb_M_Item", "nama");
        }
    }
}
