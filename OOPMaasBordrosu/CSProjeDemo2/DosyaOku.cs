using CSProjeDemo2;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Text.Json;


public class DosyaOku
{
    int mCalismaSaati, yCalismaSaati;
    
    public List<PersonInfo> dosyaOku()
    {
        
        List<PersonInfo> tumCalisan = new List<PersonInfo>();

        string json = File.ReadAllText("personel.json");
        List<PersonInfo> people = JsonSerializer.Deserialize<List<PersonInfo>>(json);

        foreach (var person in people)
        {
            Console.WriteLine($"Name: {person.Name}, Title: {person.Title}");
        }
        foreach (var item in people)
        {
            if (item.Title == "Memur")
            {

                Console.WriteLine($"{item.Title}, {item.Name}, Çalışma Saatinizi Giriniz.");
                mCalismaSaati = Convert.ToInt32(Console.ReadLine());
                MemurKademesi memurKademesi = new MemurKademesi();

                bool kademeBool = false;

                do
                {
                    kademeBool = false;
                    Console.WriteLine("Memur Kademesinizi Giriniz. Derece1 için (1), Derece2 için (2) ve Derece3 için (3)'e basınız.");
                    int secim = Convert.ToInt32(Console.ReadLine());

                    switch (secim)
                    {
                        case 1:
                            memurKademesi = MemurKademesi.Derece1;
                            break;
                        case 2:
                            memurKademesi = MemurKademesi.Derece2;
                            break;
                        case 3:
                            memurKademesi = MemurKademesi.Derece3;
                            break;
                        default:
                            kademeBool = true;
                            break;
                    }
                } while (kademeBool);

                Memur memur = new Memur(mCalismaSaati, memurKademesi);
                Console.WriteLine(memur.MaasHesapla());

                MemurInfo memurInfo = new MemurInfo();
                memurInfo.AnaOdeme = memur.AnaOdeme;
                memurInfo.ToplamOdeme = memur.ToplamOdeme;
                memurInfo.CalismaSaati = memur.CalismaSaati;
                memurInfo.Mesai = memur.Mesai;
                tumCalisan.Add(memurInfo);


            }

            else if (item.Title == "Yonetici")
            {
                Console.WriteLine($"{item.Title}, {item.Name}, Çalışma Saatinizi Giriniz.");
                yCalismaSaati = Convert.ToInt32(Console.ReadLine());
                
                Yonetici yonetici = new Yonetici(yCalismaSaati);
                Console.WriteLine(yonetici.MaasHesapla());
                tumCalisan.Add(item);
            }
        }

        return tumCalisan;
    }


    public void AzCalisan(List<PersonInfo> tumCalisan)
    {

        Console.WriteLine("150 Saat'ten Az Çalışan Personeller");

        foreach (var items in tumCalisan)
        {
            if (items.CalismaSaati < 150)
            {
                Console.WriteLine($"{items.Name}, {items.Title}, {items.CalismaSaati}");
            }


        }
    }


}
