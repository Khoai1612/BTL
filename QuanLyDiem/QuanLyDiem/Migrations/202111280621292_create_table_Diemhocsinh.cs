namespace QuanLyDiem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_Diemhocsinh : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiemHocSinhs",
                c => new
                    {
                        DiemMieng = c.String(nullable: false, maxLength: 128),
                        Diem15Phut = c.String(),
                        Diem1Tiet = c.String(),
                        DiemHK = c.String(),
                        DiemTBHK = c.String(),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.DiemMieng);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DiemHocSinhs");
        }
    }
}
