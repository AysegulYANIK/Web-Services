using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_ConsumeRESTAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //image initialize - resmi scope dışında bir varsayılan değer olarak oluşturmalıyım
            Image image = Image.FromFile("C:\\Images\\placeholder.png");

            pictureBox1.Image = image;

        }
        private void button1_Click(object sender, EventArgs e)
        {

            //string kacinciOgrenci = "/0";
            string kacinciOgrenci = comboBox1.Text;
            //" + kacinciOgrenci
            var client = new RestClient("https://localhost:44373/api/Values/"+kacinciOgrenci);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            // Yanıt JSON Formatında Gelecektir. >> { "id":123,"ad soyad":"Ali Yanık","yaş":46,"ortalama":3.01,"resim":"00 01 ..."}
            string result = response.Content;
            textBox1.Text = result;

            Model ogrenci = new Model();
            ogrenci = JsonConvert.DeserializeObject<Model>(result);

            textBox2.Text = ogrenci.AdSoyad;
            textBox3.Text = ogrenci.Ortalama.ToString();
            textBox4.Text = ogrenci.ID.ToString();
            textBox5.Text = ogrenci.Yas.ToString();

            string resimSTR = ogrenci.Resim;
            textBox6.Text = resimSTR;

            //String gelen resmi byte türüne çevirmek
            String[] arr = resimSTR.Split('-');
            byte[] array = new byte[arr.Length];
            for (int i = 0; i < arr.Length; i++) array[i] = Convert.ToByte(arr[i], 16);


            //resmi byte türünden image türüne çevirmek DESERIALIZE
            using (MemoryStream ms = new MemoryStream(array))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                List<Image> output_images = ((List<Image>)formatter.Deserialize(ms));

                Image image = output_images[0];
                pictureBox1.Image = image;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Form üzerindeki tüm alanları boşaltır
            Image image = Image.FromFile("C:\\Images\\placeholder.png");
            pictureBox1.Image = image;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var client = new RestClient("https://localhost:44373/api/Values");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);

            //Resmin Formatlanması
            List<Image> image_0 = new List<Image>();
            image_0.Add(Image.FromFile("C:\\Images\\daisy.png"));

            byte[] bytes;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, image_0);
                bytes = ms.ToArray();
            }
            string resim = BitConverter.ToString(bytes, 0);

            //CUSTOM REQUEST ICIN AŞAĞIDAKİ YAPIYLA YENİ BİR ÖRNEK GELİŞTİRİLEBİLİR
            //request.AddParameter("application/x-www-form-urlencoded", " \"ID\" : "+ textBox4.Text + ", \"AdSoyad\" : \" "+ textBox2.Text +" \" , \"Yas\" : "+ textBox5  +" , \"Ortalama\" : "+ textBox3 +"  , \"Resim\" : \""+ resim +"\" ", ParameterType.RequestBody);
            
            //RESMİN BINARY HALİYLE BERABER KUNYE BİLGİLERİNİ YOLLARKEN AŞAĞIDAKİ ÇALIŞIYOR
            request.AddParameter("application/x-www-form-urlencoded", "ID=111&AdSoyad=abcDEF&Yas=22&Ortalama=1.01&Resim="+resim, ParameterType.RequestBody);


            //SADECE RESİM YOLLARKEN AŞAĞIDAKİ KOD ÇALIŞIYOR
            //request.AddFile("daisy.png", "C:\\Images\\daisy.png");

            IRestResponse response = client.Execute(request);


            string result = response.Content;
            textBox1.Text = result;

        }
    }
}
