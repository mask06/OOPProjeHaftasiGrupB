using CSProjeDemo2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


public class DosyaOku
{
    int mCalismaSaati, yCalismaSaati;

    public void dosyaOku()
    {
        List<PersonInfo> azCalisan = new List<PersonInfo>();

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
                Console.WriteLine("Memur Çalışma Saatini Giriniz.");
                mCalismaSaati = Convert.ToInt32(Console.ReadLine());
                if (mCalismaSaati < 150)
                {
                    azCalisan.Add(item);
                }
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
            }

            else if (item.Title == "Yonetici")
            {
                Console.WriteLine("Yönetici Çalışma Saatini Giriniz.");
                yCalismaSaati = Convert.ToInt32(Console.ReadLine());
                if (yCalismaSaati < 150)
                {
                    azCalisan.Add(item);
                }
                Yonetici yonetici = new Yonetici(yCalismaSaati);
                Console.WriteLine(yonetici.MaasHesapla());
            }
        }    
    }

    public void AzCalisan(List<PersonInfo> azCalisan)
    {
        Console.WriteLine("150 Saat'ten Az Çalışan Personeller");

        foreach (var items in azCalisan)
        {
            if (items.Title == "Memur")
            {
                Console.WriteLine($"{items.Name}, {items.Title}");
            }

            else if (items.Title == "Yonetici")
            {
                Console.WriteLine($"{items.Name}, {items.Title}");
            }
        }
    }

    
}
