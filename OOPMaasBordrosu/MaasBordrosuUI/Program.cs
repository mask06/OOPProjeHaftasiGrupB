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
            DosyaOku jsonOku = new DosyaOku();
            var temp = jsonOku.dosyaOku();

            MaasBordro maasBordro = new MaasBordro(temp.Memurlar,temp.Yoneticiler);
            //maasBordro.PersonelleriYukle();

            maasBordro.RaporYazdirMemur();
            maasBordro.RaporYazdirYonetici();
            maasBordro.KisaRaporYazdir();
            jsonOku.AzCalisan(temp.Memurlar, temp.Yoneticiler);
        }
    }
}

