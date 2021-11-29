namespace QuanLyDiem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_QLGiaoVies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QLGiaoViens",
                c => new
                    {
                        MaGV = c.String(nullable: false, maxLength: 128),
                        TenGV = c.String(),
                        GioiTinh = c.String(),
                        NgaySinh = c.String(),
                        SoDienThoai = c.String(),
                        DiaChi = c.String(),
                        AnhGV = c.String(),
                        MaLop = c.String(),
                    })
                .PrimaryKey(t => t.MaGV);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.QLGiaoViens");
        }
    }
}
