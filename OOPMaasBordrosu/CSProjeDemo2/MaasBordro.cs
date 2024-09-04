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
        private List<PersonInfo> _people;

        public MaasBordro(List<PersonInfo> person)
        {
            _people = person;
        }

        //string json = File.ReadAllText("personel.json");
        //List<PersonInfo> people = JsonSerializer.Deserialize<List<PersonInfo>>(json);

        public void PersonelleriYukle()
        {
           
            string json = File.ReadAllText("personel.json");
            //List<PersonInfo> people = JsonSerializer.Deserialize<List<PersonInfo>>(json);
            _people = JsonSerializer.Deserialize<List<PersonInfo>>(json);

        }


        public void RaporYazdir()
        {
            foreach (PersonInfo personel in _people)
            {
                Directory.CreateDirectory(personel.Name);
                string dosyaAdi = $"{personel.Name}\\{personel.Name}.json";
                string json = JsonSerializer.Serialize(personel);
                File.WriteAllText(dosyaAdi, json);
            }
        }


        public void KisaRaporYazdir()
        {


            Console.WriteLine("Personel Raporu");

            foreach (PersonInfo personel in _people)
            {
                if (personel.Title == "Memur")
                {
                    Memur memur = new Memur();
                    {
                        Console.WriteLine($"Adı: {memur.Name}");
                        Console.WriteLine($"Unvanı: {memur.Title}");
                        Console.WriteLine($"Çalışma Saati: {memur.CalismaSaati}");
                        Console.WriteLine($"Toplam Ödeme: {memur.AnaOdeme}");
                        Console.WriteLine($"Çalışma Saati: {memur.Mesai}");
                        Console.WriteLine($"Toplam Ödeme: {memur.ToplamOdeme}");
                    }
                }
                else if (personel.Title == "Yonetici")
                {
                    Yonetici yonetici = new Yonetici();
                    {
                        Console.WriteLine($"Adı: {yonetici.Name}");
                        Console.WriteLine($"Unvanı: {yonetici.Title}");
                        Console.WriteLine($"Çalışma Saati: {yonetici.CalismaSaati}");
                        Console.WriteLine($"Toplam Ödeme: {yonetici.AnaOdeme}");
                        Console.WriteLine($"Çalışma Saati: {yonetici.Bonus}");
                        Console.WriteLine($"Toplam Ödeme: {yonetici.ToplamOdeme}");
                    }
                }

            }




            //public void maasBordro()
            //{
            //    string json = File.ReadAllText("personel.json");
            //    List<PersonInfo> people = JsonSerializer.Deserialize<List<PersonInfo>>(json);



            //foreach (var person in people)
            //{
            //    if (person.Title == "Memur")
            //    {
            //        Memur memur = new Memur();
            //        {
            //            string _name = memur.Name;
            //            string _title = memur.Title;
            //            int _calismaSaati = memur.CalismaSaati;
            //            decimal _anaOdeme = memur.AnaOdeme;
            //            decimal _toplamOdeme = memur.ToplamOdeme;
            //            decimal _mesai = memur.Mesai;
            //        }

            //        string jsonBordro = JsonSerializer.Serialize(memur);

            //        StreamWriter yazici = new StreamWriter("maasBordro.json");
            //        yazici.WriteLine(jsonBordro);

            //        yazici.Close();

            //    }
            //    else if (person.Title == "Yonetici")
            //    {
            //        Yonetici yonetici = new Yonetici();
            //        string _name = yonetici.Name;
            //        string _title = yonetici.Title;
            //        int _calismaSaati = yonetici.CalismaSaati;
            //        decimal _anaOdeme = yonetici.AnaOdeme;
            //        decimal _toplamOdeme = yonetici.ToplamOdeme;
            //    }
            //}



            //}

            //public void MaasBordroOlustur(List<Personel> personelListesi)
            //{
            //    Console.WriteLine("----------------------- Maaş Bordrosu -----------------------");

            //    // Calculate and display payroll for each personnel
            //    foreach (var personel in personelListesi)
            //    {
            //        Console.WriteLine($"Ad: {personel.Name} Title: {personel.Title}");

            //        Console.WriteLine($"Hesaplanan Maaş: {personel.MaasHesapla()}");
            //        Console.WriteLine("----------------------------------------------------------");
            //    }
            //}
        }
    }
}
