using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyDiem.Models
{
    [Table("QLGiaoViens")]
    public class QLGiaoVien
    {
        [Key]
        public string MaGV { get; set; }
        public string TenGV { get; set; }
        public string GioiTinh { get; set; }
        public string NgaySinh { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string AnhGV { get; set; }
        public string MaLop { get; set; }
    }
}