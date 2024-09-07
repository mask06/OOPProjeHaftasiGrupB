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
                                      "\nPersonel Raporu'nu Görüntülemek için M'ye Basınız.\n" + new string(' ', 71) + "*" +
                                      "\n150 Saatten Az Çalışan Personelleri Görmek İçin A'ya Basınız.\n" + new string(' ', 71) + "*" +
                                      "\nMaaş Bordro Klasörü OLuşturmak İçin C'ye Basınız.\n" + new string(' ', 71) + "*" +
                                      "\nProgramı tekrar başlatmak veya sonlandırmak için öncelikle K'ye Basınız.\n" + new string(' ', 71) + "*\n" + new string('*', 72) + "\n");


                    string secim = Console.ReadLine().Trim().ToUpper();


                    if (secim == "M")
                    {
                        Console.WriteLine("\n\t PERSONEL RAPORU \n\n");

                        maasBordro.KisaRaporYazdir(temp.Memurlar);
                        maasBordro.KisaRaporYazdir(temp.Yoneticiler);

                        continue;
                    }
                    else if (secim == "A")
                    {
                        Console.WriteLine("\n\t 150 SAATTEN AZ ÇALIŞAN PERSONELLER \n");

                        jsonOku.AzCalisan(temp.Memurlar, temp.Yoneticiler);

                        continue;

                    }
                    else if (secim == "C")
                    {
                        Console.WriteLine("\t KLASÖRLERİNİZ OLUŞTURULDU. LÜTFEN PROJE DOSYANIZI KONTROL EDİNİZ. \n");

                        maasBordro.RaporYazdir(temp.Memurlar);
                        maasBordro.RaporYazdir(temp.Yoneticiler);

                        continue;
                    }
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

                Console.WriteLine("\n" + new string('*', 72) + "\n" + new string(' ', 71) + "*\n" +
                                  "Programı yeniden başlatmak için Y'ye basınız.\n" + new string(' ', 71) + "*\n" +
                                  "Programı sonlandırmak için 'Y' haricindeki herhangi bir tuşa basınız.\n" + new string(' ', 71) + "*\n" + new string('*', 72) + "\n");

                string secim2 = Console.ReadLine().Trim().ToUpper();

                if (secim2 == "Y")
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

