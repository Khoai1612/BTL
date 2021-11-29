namespace QuanLyDiem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_QLMonHocs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QLLops",
                c => new
                    {
                        MaLop = c.String(nullable: false, maxLength: 128),
                        TenLop = c.String(),
                        NienKhoa = c.String(),
                        SiSo = c.String(),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.MaLop);
            
            CreateTable(
                "dbo.QLMonHocs",
                c => new
                    {
                        MaMH = c.String(nullable: false, maxLength: 128),
                        TenMH = c.String(),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.MaMH);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.QLMonHocs");
            DropTable("dbo.QLLops");
        }
    }
}
