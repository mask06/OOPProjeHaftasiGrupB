using CSProjeDemo2;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Text.Json;

namespace CSProjeDemo2
{
    public class DosyaOku
    {
        int mCalismaSaati, yCalismaSaati;
        private List<Memur> _memurlar;
        private List<Yonetici> _yoneticiler;

        public List<Memur> Memurlar
        {
            get { return _memurlar; }
        }

        public List<Yonetici> Yoneticiler
        {
            get { return _yoneticiler; }
        }

        //public dönecek bu listeleri

        public DosyaOku dosyaOku()
        {

            List<PersonInfo> tumCalisan = new List<PersonInfo>();
            _memurlar = new List<Memur>();
            _yoneticiler = new List<Yonetici>();

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

                    Console.WriteLine($"{item.Title},{item.Name} Çalışma Saatini Giriniz.");
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
                    memur.Name = item.Name;
                    memur.Title = item.Title;
                    _memurlar.Add(memur);



                }

                else if (item.Title == "Yonetici")
                {
                    Console.WriteLine($"{item.Title},{item.Name} Çalışma Saatini Giriniz.");
                    yCalismaSaati = Convert.ToInt32(Console.ReadLine());

                    Yonetici yonetici = new Yonetici(yCalismaSaati);
                    Console.WriteLine(yonetici.MaasHesapla());
                    yonetici.Name = item.Name;
                    yonetici.Title = item.Title;
                    _yoneticiler.Add(yonetici);
                }
            }

            return this;
        }

        public void AzCalisan(List<Memur> _memurlar, List<Yonetici> _yoneticiler)
        {

            Console.WriteLine("150 Saat'ten Az Çalışan Personeller");

            foreach (var items in _memurlar)
            {
                if (items.CalismaSaati < 150)
                    Console.WriteLine($"{items.Title}, {items.Name} {items.CalismaSaati} saat çalıştı.");

            }
            foreach (var items in _yoneticiler)
            {
                if (items.CalismaSaati < 150)
                    Console.WriteLine($"{items.Title}, {items.Name} {items.CalismaSaati} saat çalıştı.");

            }
        }


    }
}
