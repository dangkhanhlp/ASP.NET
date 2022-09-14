namespace onthi2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [Key]
        [StringLength(10)]
        [Required(ErrorMessage = "Mã nhân viên không được để trống")]
        [DisplayName("Mã nhân viên")]
        public string MaNV { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Họ tên nhân viên không được để trống")]
        [DisplayName("Họ tên")]
        public string HoTen { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Phòng không được để trống")]
        [DisplayName("Tên Phòng")]
        public string Phong { get; set; }

        [Required(ErrorMessage = "Lương không được để trống")]
        [DisplayName("Lương")]
        public double? Luong { get; set; }
    }
}
