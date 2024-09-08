using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CSProjeDemo2;
using System.Xml;

namespace CSProjeDemo2

{
    internal class Program
    {
        public static void Main(string[] args)
        {

            bool program = true;
            // Kullanıcın isteğine bağlı olarak programı devam ettirir ya da sonlandırır.
            while (program)
            {
                DosyaOku jsonOku = new DosyaOku();
                MaasBordro maasBordro = new MaasBordro();
                // Dosya oku metotunda geri döndürülen bilgileri değişkende sakladık. 
                var temp = jsonOku.dosyaOku();
                //Karşılama yapılır.
                Console.Clear();
                jsonOku.muzRepublic();
                jsonOku.PersonelListeleriniYaz();

                bool program2 = true;
                // Kullanıcının konsolda seçim yapmasını ve her seçimden sonra seçeneklerin tekrar sunulmasını sağlar.
                while (program2)
                {
                    // Konsol tasarımı ile seçenekler sunulur.
                    Console.WriteLine("\n\n" + new string('*', 72) + "\n" + new string(' ', 71) + "*" +
                                      "\nPersonel Raporu'nu Görüntülemek için M'ye Basınız.\n" + new string(' ', 71) + "*" +
                                      "\n150 Saatten Az Çalışan Personelleri Görmek İçin A'ya Basınız.\n" + new string(' ', 71) + "*" +
                                      "\nMaaş Bordro Klasörü OLuşturmak İçin C'ye Basınız.\n" + new string(' ', 71) + "*" +
                                      "\nProgramı tekrar başlatmak veya sonlandırmak için öncelikle K'ye Basınız.\n" + new string(' ', 71) + "*\n" + new string('*', 72) + "\n");

                    // Kullanıcıdan alınan değerin kontrolünü yapar. ( Boşluk ve harf boyutu.)
                    string secim = Console.ReadLine().Trim().ToUpper();

                    //Personel raporunu ekrana yazdıran metotu çağırır ve parametre olarak list verilir. 
                    if (secim == "M")
                    {
                        Console.WriteLine("\n\t PERSONEL RAPORU \n\n");

                        maasBordro.KisaRaporYazdir(temp.Memurlar);
                        maasBordro.KisaRaporYazdir(temp.Yoneticiler);

                        continue;
                    }

                    //150 saatten az çalışan personlleri ekrana yazdıran metotu çağırır ve parametre olarak list verilir. 
                    else if (secim == "A")
                    {
                        Console.WriteLine("\n\t 150 SAATTEN AZ ÇALIŞAN PERSONELLER \n");

                        jsonOku.AzCalisan(temp.Memurlar);
                        jsonOku.AzCalisan(temp.Yoneticiler);
                        continue;

                    }

                    //Personel raporunu json formatına yazdıran ve iç içe klasörleri oluşturan  metotu çağırır ve parametre olarak list verilir. 
                    else if (secim == "C")
                    {
                        Console.WriteLine("\n\t KLASÖRLERİNİZ OLUŞTURULDU. LÜTFEN PROJE DOSYANIZI KONTROL EDİNİZ. \n");

                        maasBordro.RaporYazdir(temp.Memurlar);
                        maasBordro.RaporYazdir(temp.Yoneticiler);

                        continue;
                    }

                    //Programı devam ettirme ve sonlandırma seçeneğini sunan koşuldur.
                    else if (secim == "K")
                    {
                        program2 = false;
                    }
                    else
                    {
                        Console.WriteLine("\nGeçersiz Seçim. Lütfen M, A, C veya K'ye Basınız.\n");

                        program2 = true;
                    }

                }

                // Konsol tasarımı ile seçenekler sunulur.
                Console.WriteLine("\n" + new string('*', 72) + "\n" + new string(' ', 71) + "*\n" +
                                  "Programı yeniden başlatmak için Y'ye basınız.\n" + new string(' ', 71) + "*\n" +
                                  "Programı sonlandırmak için 'Y' haricindeki herhangi bir tuşa basınız.\n" + new string(' ', 71) + "*\n" + new string('*', 72) + "\n");

                string secim2 = Console.ReadLine().Trim().ToUpper();

                // Programı baştan başlatarak devam ettiren koşul. 
                if (secim2 == "Y")
                {
                    program = true;
                }
                // Programı sonlandıran koşul. 
                else
                {
                    program = false;
                }
            }
            Console.WriteLine("\nProgramı sonlandırdınız.\n");

        }
        
    }
}

