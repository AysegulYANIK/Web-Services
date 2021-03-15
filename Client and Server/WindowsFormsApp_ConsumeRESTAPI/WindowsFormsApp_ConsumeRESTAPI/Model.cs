using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WindowsFormsApp_ConsumeRESTAPI
{
    class Model
    {
        public int ID { get; set; }

        public string AdSoyad { get; set; }

        public int Yas { get; set; }

        public float Ortalama { get; set; }

        public string Resim { get; set; }
    }
}
