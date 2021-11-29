using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QuanLyDiem.Models
{
    public class QuanLyDiemDbContext : DbContext
    {
        public QuanLyDiemDbContext() : base("QuanLyDiemDbContext")
        {
        }

        public DbSet<QLGiaoVien> QLGiaoViens { get; set; }
        public DbSet<QLHocSinh> QLHocSinhs { get; set; }
        public DbSet<QLLop> QLLops { get; set; }
        public DbSet<QLMonHoc> QLMonHocs { get; set; }
        public DbSet<DiemHocSinh> DiemHocSinhs { get; set; }
        public  DbSet<Account> Accounts { get; set; }
        public  DbSet<Role> Roles { get; set; }
        

        internal static void SetAuthCookie(string useName, bool v)
        {
            throw new NotImplementedException();
        }
    }
}