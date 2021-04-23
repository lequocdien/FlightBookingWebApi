using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DatVeMayBay.Web.Models
{
    //[DataContract(Name = "maybay", Namespace = "http://datvemaybay")]
    [JsonObject("maybay", IsReference = true)]
    public class MayBayViewModel
    {
        //[DataMember(Name = "mamb")]
        [JsonProperty("mamb")]
        public string MaMayBay { get; set; }

        //[DataMember(Name = "tenmb")]
        [JsonProperty("tenmb")]
        public string TenMayBay { get; set; }

        //[DataMember(Name = "slghe")]
        [JsonProperty("slghe")]
        public int? TongSoGhe { get; set; }

        //[DataMember(Name = "slghehang1")]
        [JsonProperty("slghang1")]
        public int? SoGheHang1 { get; set; }

        //[DataMember(Name = "slghehang2")]
        [JsonProperty("slghang2")]
        public int? SoGheHang2 { get; set; }

        //[DataMember(Name = "chuyenbays")]
        //[IgnoreDataMember]
        [JsonProperty("chuyenbays")]
        public virtual IEnumerable<ChuyenBayViewModel> ChuyenBays { get; set; }
    }
}