using RESTWebAPI_ServerSide.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Http;

namespace RESTWebAPI_ServerSide.Controllers
{
    public class ValuesController : ApiController
    {
        
        // GET api/values
        public IEnumerable<Model> Get()
        {
            var ogrenciListesi = new List<Model>();

            //Birinci Öğrencinin Bilgileri
            var ogrenci_1 = new Model
            {
                ID = 123,
                AdSoyad = "Ali Yanık",
                Ortalama = 3.01f,
                Yas = 46,

                Resim = ""
            };
            ogrenciListesi.Add(ogrenci_1);

            //İkinci Öğrencinin Bilgileri
            var ogrenci_2 = new Model
            {
                ID = 234,
                AdSoyad = "Mertkan Yanık",
                Ortalama = 3.29f,
                Yas = 28 ,

                Resim = ""

            };
            ogrenciListesi.Add(ogrenci_2);

            //Üçüncü Öğrencinin Bilgileri
            var ogrenci_3 = new Model
            {
                ID = 345,
                AdSoyad = "Ayşegül Yanık",
                Ortalama = 3.12f,
                Yas = 27 ,

                Resim = ""
            };
            ogrenciListesi.Add(ogrenci_3);

            return ogrenciListesi;
        }
        

        // GET api/values/id (where id in {0,1,2} )
        public Model Get(int id)
        {
            var ogrenciListesi = new List<Model>();

            //Resmin Formatlanması
            List<Image> image_0 = new List<Image>();
            image_0.Add(Image.FromFile("C:\\Images\\alyssum.png"));

            byte[] bytes;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, image_0);
                bytes = ms.ToArray();
            }

            //Birinci Öğrencinin Bilgileri
            var ogrenci_0 = new Model
            {
                ID = 123,
                AdSoyad = "Ali Yanık",
                Ortalama = 3.01f,
                Yas = 46,

                Resim = BitConverter.ToString(bytes, 0)

            };
            ogrenciListesi.Add(ogrenci_0);

            //İkinci Öğrencinin Bilgileri
            List<Image> image_1 = new List<Image>();
            image_1.Add(Image.FromFile("C:\\Images\\dandelion.png"));

            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, image_1);
                bytes = ms.ToArray();
            }

            var ogrenci_1 = new Model
            {
                ID = 234,
                AdSoyad = "Mertkan Yanık",
                Ortalama = 3.29f,
                Yas = 28,
                Resim = BitConverter.ToString(bytes, 0)

            };
            ogrenciListesi.Add(ogrenci_1);

            //Üçüncü Öğrencinin Bilgileri
            List<Image> image_2 = new List<Image>();
            image_2.Add(Image.FromFile("C:\\Images\\lily.png"));

            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, image_2);
                bytes = ms.ToArray();
            }
            var ogrenci_2 = new Model
            {
                ID = 345,
                AdSoyad = "Ayşegül Yanık",
                Ortalama = 3.12f,
                Yas = 27,
                Resim = BitConverter.ToString(bytes, 0)

            };
            ogrenciListesi.Add(ogrenci_2);

            var ogrenci = ogrenciListesi[id];

            return ogrenci;
        }

        /*
           // POST api/values
           // DENEME 1
           public Model Post(Model ogrenci)
           {
               var postData = new Model();

               //Birinci Öğrencinin Bilgileri
               postData= new Model
               {
                   ID = ogrenci.ID,
                   AdSoyad = ogrenci.AdSoyad,
                   Ortalama = ogrenci.Ortalama,
                   Yas = ogrenci.Yas,
                   Resim = ""
               };

               return postData;
           }
        */

        
        // STACKOVERFLOW Kod Önerisi 1 : https://stackoverflow.com/questions/28369529/how-to-set-up-a-web-api-controller-for-multipart-form-data
        [HttpPost]
        // public string UploadFile()
        public string UploadFile([FromBody] Model request)
        {
            /*
            var file = HttpContext.Current.Request.Files.Count > 0 ?
                HttpContext.Current.Request.Files[0] : null;
            var fileName = "";
            var path = "";
            if (file != null && file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);

                path = Path.Combine(
                    HttpContext.Current.Server.MapPath("~/uploads"),
                    fileName
                );

                file.SaveAs(path);
            }

            //Dosyanın Byte Şeklinde Formatlanması
            byte[] readFile = File.ReadAllBytes(path);
            string binary = BitConverter.ToString(readFile, 0);

            //string prm = request.ID.ToString();
            string sonuc = "Gönderilen Resmin; Adı : " + fileName + " ve Binary Hali Şöyle : " + binary ;

            //return file != null ? "/uploads/" + file.FileName : null;
            return sonuc;
            */

            string resim = request.Resim;
            float ortalama = request.Ortalama;
            int id = request.ID;
            string ad_soyad = request.AdSoyad;

            return "Bir PArametre olarak da örneğin ID : "+ id +" ve Resmin binary hali :" + resim ;

        }
        
        /*
       // PUT api/values/5
       public void Put(int id, [FromBody] string value)
       {
       }

       // DELETE api/values/5
       public void Delete(int id)
       {
       }
       */
    }
}
