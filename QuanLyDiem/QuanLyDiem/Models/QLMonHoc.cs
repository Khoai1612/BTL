using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyDiem.Models
{
    [Table("QLMonHocs")]
    public class QLMonHoc
    {
        [Key]
        public string MaMH { get; set; }
        public string TenMH { get; set; }
        public string GhiChu { get; set; }
    }
}