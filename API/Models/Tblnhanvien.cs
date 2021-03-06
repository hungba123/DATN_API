using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Tblnhanvien
    {
        public Tblnhanvien()
        {
            Tblboiduongs = new HashSet<Tblboiduong>();
            Tblcongtacs = new HashSet<Tblcongtac>();
            Tbllyliches = new HashSet<Tbllylich>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Hoten { get; set; }
        public string Bidanh { get; set; }
        public string Hinhanh { get; set; }
        public int? Gioitinh { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string Noisinh { get; set; }
        public string Cmnd { get; set; }
        public string Ncapcmnd { get; set; }
        public string Dantoc { get; set; }
        public string Tongiao { get; set; }
        public string Quoctich { get; set; }
        public int? Tthonnhan { get; set; }
        public string Quequan { get; set; }
        public string Dcttru { get; set; }
        public string Noiohnay { get; set; }
        public string Dienthoai { get; set; }
        public string Email { get; set; }
        public int? Idpban { get; set; }
        public int? Idchucvu { get; set; }
        public string Tdhocvan { get; set; }
        public string Datotnghiep { get; set; }
        public string Tdcaonhat { get; set; }
        public string Ngdaotao { get; set; }
        public string Cngdaotao { get; set; }
        public string Noidaotao { get; set; }
        public string Htdaotao { get; set; }
        public int? Mantn { get; set; }
        public int? Tinhtrang { get; set; }
        public string Trinhdonn { get; set; }
        public string Tinhoc { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual Tblchucvu IdchucvuNavigation { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual Tblphongban IdpbanNavigation { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual ICollection<Tblboiduong> Tblboiduongs { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual ICollection<Tblcongtac> Tblcongtacs { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual ICollection<Tbllylich> Tbllyliches { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
