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

        public MaasBordro()
        {

        }

        public void RaporYazdir<T>(List<T> list) where T : Personel
        {
            foreach (T item in list)
            {
                Directory.CreateDirectory(item.Name.Replace(" ", "_"));
                Directory.CreateDirectory($"{item.Name.Replace(" ", "_")}\\{DateTime.Now.Month}-{DateTime.Now.Year}");

                string dosyaAdi = $"{item.Name.Replace(" ", "_")}\\{DateTime.Now.Month}-{DateTime.Now.Year}\\{item.Name}.json";
                string json = JsonSerializer.Serialize(item, new JsonSerializerOptions { WriteIndented = true }); //json formatında propları alt alta yazmasını sağlar
                File.WriteAllText(dosyaAdi, json);
            }
        }

        public void KisaRaporYazdir<T>(List<T> people) where T : Personel
        {
            
            foreach (var personel in people)
            {
                Console.WriteLine($"Adı: {personel.Name}");
                Console.WriteLine($"Unvanı: {personel.Title}");
                Console.WriteLine($"Çalışma Saati: {personel.CalismaSaati}");
                Console.WriteLine($"Ana Ödeme: {personel.AnaOdeme}");

                if (personel is Memur memur)
                {
                    Console.WriteLine($"Mesai: {memur.Mesai}");
                }
                else if (personel is Yonetici yonetici)
                { Console.WriteLine($"Bonus: {yonetici.Bonus}"); }
                Console.WriteLine($"Toplam Ödeme: {personel.ToplamOdeme}\n");
                
                Console.WriteLine(new string('-', 36) + "\n");

            }
        }

    }

    
}

