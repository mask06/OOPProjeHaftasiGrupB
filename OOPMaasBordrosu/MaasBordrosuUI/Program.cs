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
                program = false;
                DosyaOku jsonOku = new DosyaOku();
                jsonOku.muzRepublic();
                MaasBordro maasBordro = new MaasBordro();
                jsonOku.PersonelListeleriniYaz();

                Console.WriteLine("Personel bilgilerini giriniz.");
                var temp = jsonOku.dosyaOku();
                Console.WriteLine("\t PERSONEL RAPORU \n ");
                maasBordro.KisaRaporYazdir(temp.Memurlar);
                maasBordro.KisaRaporYazdir(temp.Yoneticiler);

                Console.WriteLine("Yapmak İstediğiniz İşlemi Seçiniz\n\n" +
                             "150 Saatten Az Çalışan Personelleri Görmek İçin 1'e Basınız\n\n" +
                             "Maaş Bordro Klasörü OLuşturmak İçin 2'e Basınız.\n" +
                             "Programı Bitirmek için 3'e basınız.\n" +
                             "programı devam ettirmek için 4 e bas");
                int secim = Convert.ToInt32(Console.ReadLine());

                switch (secim)
                {
                    case 1:
                        Console.WriteLine("\t 150 SAATTEN AZ ÇALIŞAN PERSONELLER \n");
                        jsonOku.AzCalisan(temp.Memurlar, temp.Yoneticiler);
                        break;
                    case 2:
                        maasBordro.RaporYazdir(temp.Memurlar);
                        maasBordro.RaporYazdir(temp.Yoneticiler);
                        break;
                    case 3:
                        program = false;
                        break;
                    case 4:
                        program = true;
                        break;
                    default:
                        while (int.TryParse(Console.ReadLine(), out secim) || secim < 1 || secim > 4)
                        {
                            Console.WriteLine("Lütfen Yapmak istediğiniz işlemi tekrar seçiniz.");
                            secim = Convert.ToInt32(Console.ReadLine());
                        }
                        break;
                }

            }
        }
    }
}

