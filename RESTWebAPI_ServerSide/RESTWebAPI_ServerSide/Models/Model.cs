using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RESTWebAPI_ServerSide.Models
{
    [DataContract]
    public class Model
    {
        [DataMember(Name = "ID")]
        public int ID { get; set; }

        [DataMember(Name = "AdSoyad")]
        public string AdSoyad { get; set; }

        [DataMember(Name = "Yas")]
        public int Yas { get; set; }

        [DataMember(Name = "ortalama")]
        public float Ortalama { get; set; }

        [DataMember(Name = "Resim")]
        public string Resim { get; set; }
    }
}