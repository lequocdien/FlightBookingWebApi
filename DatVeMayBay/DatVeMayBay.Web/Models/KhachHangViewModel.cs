using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DatVeMayBay.Web.Models
{
    //[DataContract(Name = "khachhang", Namespace = "http://datvemaybay")]
    [JsonObject("khachhang")]
    public class KhachHangViewModel
    {
        //[DataMember(Name = "cmnd")]
        [JsonProperty("cmnd")]
        public string CMND { get; set; }

        //[DataMember(Name = "ho")]
        [JsonProperty("ho")]
        public string Ho { get; set; }

        //[DataMember(Name = "ten")]
        [JsonProperty("ten")]
        public string Ten { get; set; }

        //[DataMember(Name = "sdt")]
        [JsonProperty("sdt")]
        public string SDT { get; set; }

        //[DataMember(Name = "gioitinh")]
        [JsonProperty("gioitinh")]
        public bool? GioiTinh { get; set; }

        //[DataMember(Name = "email")]
        [JsonProperty("email")]
        public string Email { get; set; }

        //[DataMember(Name = "ghichu")]
        [JsonProperty("ghichu")]
        public string GhiChu { get; set; }

        [JsonProperty("hoadons")]
        public virtual IEnumerable<HoaDonViewModel> HoaDons { get; set; }
    }
}