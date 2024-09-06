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

            while (program)
            {
                DosyaOku jsonOku = new DosyaOku();
                MaasBordro maasBordro = new MaasBordro();

                var temp = jsonOku.dosyaOku();
                Console.Clear();
                jsonOku.muzRepublic();
                jsonOku.PersonelListeleriniYaz();

                bool program2 = true;

                while (program2)
                {
                    Console.WriteLine("\n\n" + new string('*', 72) + "\n" + new string(' ', 71) + "*" +
                                      "\nPersonel Raporu'nu Görüntülemek için 1'e Basınız.\n" + new string(' ', 71) + "*" +
                                      "\n150 Saatten Az Çalışan Personelleri Görmek İçin 2'ye Basınız.\n" + new string(' ', 71) + "*" +
                                      "\nMaaş Bordro Klasörü OLuşturmak İçin 3'e Basınız.\n" + new string(' ', 71) + "*" +
                                      "\nProgramı tekrar başlatmak veya sonlandırmak için öncelikle 4'e Basınız.\n" + new string(' ', 71) + "*\n" + new string('*', 72) + "\n");

                    string secim = Console.ReadLine();

                    //CLEAR ??

                    if (secim == "1")
                    {
                        Console.WriteLine("\n\t PERSONEL RAPORU \n\n");

                        maasBordro.KisaRaporYazdir(temp.Memurlar);
                        maasBordro.KisaRaporYazdir(temp.Yoneticiler);
                        continue;
                    }
                    else if (secim == "2")
                    {
                        Console.WriteLine("\n\t 150 SAATTEN AZ ÇALIŞAN PERSONELLER \n");

                        jsonOku.AzCalisan(temp.Memurlar, temp.Yoneticiler);
                        continue;

                    }
                    else if (secim == "3")
                    {
                        Console.WriteLine("\t KLASÖRLERİNİZ OLUŞTURULDU. PROJE DOSYANIZI KONTROL EDİNİZ. \n");

                        maasBordro.RaporYazdir(temp.Memurlar);
                        maasBordro.RaporYazdir(temp.Yoneticiler);
                        continue;
                    }
                    else if (secim == "4")
                    {
                        program2 = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nGeçersiz Seçim. Lütfen 1, 2, 3 veya 4'e Basınız.\n");
                        program2 = true;
                    }

                }

                Console.WriteLine("\n" + new string('*', 72) + "\n" + new string(' ', 71) + "*\n" +
                                  "Programı yeniden başlatmak için 5'e basınız.\n" + new string(' ', 71) + "*\n" +
                                  "Programı sonlandırmak için 5 haricindeki herhangi bir tuşa basınız.\n" + new string(' ', 71) + "*\n" + new string('*', 72) + "\n");

                string tus = Console.ReadLine();

                if (tus == "5")
                {
                    program = true;
                }

                else
                {
                    program = false;
                }
            }
            Console.WriteLine("\nProgramı sonlandırdınız.\n");

        }
        
    }
}

