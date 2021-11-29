using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyDiem.Models
{
    [Table("QLLops")]
    public class QLLop
    {
        [Key]
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public string NienKhoa { get; set; }
        public string SiSo { get; set; }
        public string GhiChu { get; set; }
    }
}