using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    public class MaasBordro
    {
        private List<Memur> _memurlar;
        private List<Yonetici> _yoneticiler;

        public MaasBordro(List<Memur> memurlar, List<Yonetici> yoneticiler)
        {
            _memurlar = memurlar;
            _yoneticiler = yoneticiler;
        }

        public void RaporYazdirMemur()
        {
            foreach (Memur personel in _memurlar)
            {
                Directory.CreateDirectory(personel.Name.Replace(" ","_"));
                Directory.CreateDirectory($"{personel.Name.Replace(" ", "_")}\\{DateTime.Now.Month}-{DateTime.Now.Year}");

                string dosyaAdi = $"{personel.Name.Replace(" ", "_")}\\{DateTime.Now.Month}-{DateTime.Now.Year}\\{personel.Name}.json";
                string json = JsonSerializer.Serialize(personel, new JsonSerializerOptions{WriteIndented=true}); //json formatında propları alt alta yazmasını sağlar
                File.WriteAllText(dosyaAdi, json);
            }
        }
        public void RaporYazdirYonetici()
        {
            foreach (Yonetici personel in _yoneticiler)
            {
                Directory.CreateDirectory(personel.Name.Replace(" ", "_"));
                Directory.CreateDirectory($"{personel.Name.Replace(" ", "_")}\\{DateTime.Now.Month}-{DateTime.Now.Year}");

                string dosyaAdi = $"{personel.Name.Replace(" ", "_")}\\{DateTime.Now.Month}-{DateTime.Now.Year}\\{personel.Name}.json";          
                string json = JsonSerializer.Serialize(personel, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(dosyaAdi, json);
            }
        }


        public void KisaRaporYazdir()
        {

            Console.WriteLine("Personel Raporu");

            foreach (Memur personel in _memurlar)
            {
                if (personel.Title == "Memur")
                {
                    {
                        Console.WriteLine($"Adı: {personel.Name}");
                        Console.WriteLine($"Unvanı: {personel.Title}");
                        Console.WriteLine($"Çalışma Saati: {personel.CalismaSaati}");
                        Console.WriteLine($"Ana Ödeme: {personel.AnaOdeme}");
                        Console.WriteLine($"Mesai: {personel.Mesai}");
                        Console.WriteLine($"Toplam Ödeme: {personel.ToplamOdeme}");
                    }
                }
            }
            foreach (Yonetici personel in _yoneticiler)
            {
                if (personel.Title == "Memur")
                {
                    {
                        Console.WriteLine($"Adı: {personel.Name}");
                        Console.WriteLine($"Unvanı: {personel.Title}");
                        Console.WriteLine($"Çalışma Saati: {personel.CalismaSaati}");
                        Console.WriteLine($"Ana Ödeme: {personel.AnaOdeme}");
                        Console.WriteLine($"Mesai: {personel.Bonus}");
                        Console.WriteLine($"Toplam Ödeme: {personel.ToplamOdeme}");
                    }
                }
            }



        }




            //        //public void maasBordro()
            //        //{
            //        //    string json = File.ReadAllText("personel.json");
            //        //    List<PersonInfo> people = JsonSerializer.Deserialize<List<PersonInfo>>(json);



            //        //foreach (var person in people)
            //        //{
            //        //    if (person.Title == "Memur")
            //        //    {
            //        //        Memur memur = new Memur();
            //        //        {
            //        //            string _name = memur.Name;
            //        //            string _title = memur.Title;
            //        //            int _calismaSaati = memur.CalismaSaati;
            //        //            decimal _anaOdeme = memur.AnaOdeme;
            //        //            decimal _toplamOdeme = memur.ToplamOdeme;
            //        //            decimal _mesai = memur.Mesai;
            //        //        }

            //        //        string jsonBordro = JsonSerializer.Serialize(memur);

            //        //        StreamWriter yazici = new StreamWriter("maasBordro.json");
            //        //        yazici.WriteLine(jsonBordro);

            //        //        yazici.Close();

            //        //    }
            //        //    else if (person.Title == "Yonetici")
            //        //    {
            //        //        Yonetici yonetici = new Yonetici();
            //        //        string _name = yonetici.Name;
            //        //        string _title = yonetici.Title;
            //        //        int _calismaSaati = yonetici.CalismaSaati;
            //        //        decimal _anaOdeme = yonetici.AnaOdeme;
            //        //        decimal _toplamOdeme = yonetici.ToplamOdeme;
            //        //    }
            //        //}



            //        //}

            //        //public void MaasBordroOlustur(List<Personel> personelListesi)
            //        //{
            //        //    Console.WriteLine("----------------------- Maaş Bordrosu -----------------------");

            //        //    // Calculate and display payroll for each personnel
            //        //    foreach (var personel in personelListesi)
            //        //    {
            //        //        Console.WriteLine($"Ad: {personel.Name} Title: {personel.Title}");

            //        //        Console.WriteLine($"Hesaplanan Maaş: {personel.MaasHesapla()}");
            //        //        Console.WriteLine("----------------------------------------------------------");
            //        //    }
            //        //}
            //    }
            //}
        }
    }

