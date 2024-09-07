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
        private List<Memur> _memurlar;
        private List<Yonetici> _yoneticiler;
        MemurKademesi memurKademesi = new MemurKademesi();

        public List<Memur> Memurlar
        {
            get { return _memurlar; }
        }

        public List<Yonetici> Yoneticiler
        {
            get { return _yoneticiler; }
        }


        public DosyaOku dosyaOku()
        {
            List<PersonInfo> tumCalisan = new List<PersonInfo>();
            _memurlar = new List<Memur>();
            _yoneticiler = new List<Yonetici>();

            string json = File.ReadAllText("personel.json");
            List<PersonInfo> people = JsonSerializer.Deserialize<List<PersonInfo>>(json);

            foreach (var personInfo in people)
            {
                Personel person = CreatePerson(personInfo);

                if (person != null)
                {

                    Console.Clear();
                    muzRepublic();
                    PersonelListeleriniYaz();


                    Console.WriteLine($"{person.Title}, {person.Name}, Çalışma Saatinizi Giriniz.");

                    int calismaSaati;

                    while (!int.TryParse(Console.ReadLine(), out calismaSaati) || calismaSaati < 0 || calismaSaati > 300)
                    {
                        Console.WriteLine("Geçerli bir çalışma saati giriniz.");
                    }

                    person.CalismaSaati = calismaSaati;

                    if (person is Memur memur)
                    {
                        MemurKademesi memurKademesi = Secim("Memur Kademenizi Giriniz. Derece1 için (1), Derece2 için (2) ve Derece3 için (3)'e basınız.",
                                                                     (1, MemurKademesi.Derece1), (2, MemurKademesi.Derece2), (3, MemurKademesi.Derece3));
                        memur.MKademesi = memurKademesi;
                        Console.WriteLine($"Seçilen Memur Kademesi: {memurKademesi}");
                        _memurlar.Add(memur);
                    }
                    else if (person is Yonetici yonetici)
                    {
                        _yoneticiler.Add(yonetici);
                    }

                    Console.WriteLine($"{person.MaasHesapla()}");

                }
            }
            return this;
        }


        private Personel CreatePerson(PersonInfo personInfo)
        {
            switch (personInfo.Title)
            {
                case "Memur":
                    return new Memur
                    {
                        Name = personInfo.Name,
                        Title = personInfo.Title
                    };
                case "Yonetici":
                    return new Yonetici
                    {
                        Name = personInfo.Name,
                        Title = personInfo.Title
                    };
                default:
                    return null;
            }
        }


        static T Secim<T>(string mesaj, params (int key, T value)[] seçenekler)
        {
            while (true)
            {
                Console.WriteLine(mesaj);
                if (int.TryParse(Console.ReadLine(), out int _secim))
                {
                    foreach (var (key, value) in seçenekler)
                    {
                        if (_secim == key)
                        {
                            return value;
                        }
                    }
                }
                Console.WriteLine("Geçersiz seçim, tekrar deneyiniz.");
            }
        }


        public void AzCalisan<T>(List<T> people) where T : Personel
        {
            foreach (var personel in people)
            {
                if (personel.CalismaSaati < 150)
                    Console.WriteLine($"{personel.Title}, {personel.Name} {personel.CalismaSaati} saat çalıştı.");

            }
        }


        public void muzRepublic()
        {
            Console.WriteLine("\t \t \t \t \t MUZ CUMHURİYETİ'NE HOŞ GELDİNİZ \n\n ");
        }


        public void PersonelListeleriniYaz()
        {
            string json = File.ReadAllText("personel.json");
            List<PersonInfo> people = JsonSerializer.Deserialize<List<PersonInfo>>(json);
            Console.WriteLine("Name" + new string(' ', 18) + "| Title ");
            Console.WriteLine(new string('-', 36));
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name,-21} | {person.Title,3}");
            }
            Console.WriteLine();
        }
    }
}

