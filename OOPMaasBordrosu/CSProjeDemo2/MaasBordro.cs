﻿using System;
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



        //İç içe klasörlere json formatındaki dosyayı ekleme işlemleri bu generic list metotta yer alır. 
        public void RaporYazdir<T>(List<T> people) where T : Personel
        {
            foreach (var personel in people)
            {
                Directory.CreateDirectory(personel.Name.Replace(" ", "_"));
                Directory.CreateDirectory($"{personel.Name.Replace(" ", "_")}\\{DateTime.Now.Month}-{DateTime.Now.Year}");

                string dosyaAdi = $"{personel.Name.Replace(" ", "_")}\\{DateTime.Now.Month}-{DateTime.Now.Year}\\{personel.Name}.json";
                string json = JsonSerializer.Serialize(personel, new JsonSerializerOptions { WriteIndented = true }); //json formatında propları alt alta yazmasını sağlar
                File.WriteAllText(dosyaAdi, json);
            }
        }

        //Bu generic list metotta personel raporunun konsola yazılmasını sağlar.
        public void KisaRaporYazdir<T>(List<T> people) where T : Personel
        {

            foreach (var personel in people)
            {
                Console.WriteLine($"Adı: {personel.Name}");
                Console.WriteLine($"Unvanı: {personel.Title}");
                Console.WriteLine($"Çalışma Saati: {personel.CalismaSaati}");
                Console.WriteLine($"Ana Ödeme: {personel.AnaOdeme}");

                switch (personel)
                {
                    case Memur memur:
                        Console.WriteLine($"Mesai: {memur.Mesai}");
                        break;
                    case Yonetici yonetici:
                        Console.WriteLine($"Bonus: {yonetici.Bonus}");
                        break;
                }

                Console.WriteLine($"Toplam Ödeme: {personel.ToplamOdeme}\n");

                Console.WriteLine(new string('-', 36) + "\n");
            }

        }

    }

    
}

