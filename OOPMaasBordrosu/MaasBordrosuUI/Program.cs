using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CSProjeDemo2;

namespace CSProjeDemo2

{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\t \t \t \t \t Muz Cumhuriyetine Hoşgeldiniz \n ");
            Console.WriteLine("Personel listesi: \n ");
           
            DosyaOku jsonOku = new DosyaOku();
            jsonOku.PersonelListeleriniYaz();

            var temp = jsonOku.dosyaOku();
            MaasBordro maasBordro = new MaasBordro();

            maasBordro.RaporYazdir(temp.Memurlar);
            maasBordro.RaporYazdir(temp.Yoneticiler);

            //maasBordro.RaporYazdirMemur();
            //maasBordro.RaporYazdirYonetici();


            maasBordro.KisaRaporYazdir(temp.Memurlar);
            maasBordro.KisaRaporYazdir(temp.Yoneticiler);
            jsonOku.AzCalisan(temp.Memurlar, temp.Yoneticiler);



        }
    }
}

