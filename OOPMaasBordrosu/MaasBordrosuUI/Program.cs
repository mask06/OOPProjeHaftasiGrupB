﻿using System;
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
            jsonOku.dosyaOku();

            MaasBordro maasBordro = new MaasBordro();
            maasBordro.PersonelleriYukle("personel.json");

            maasBordro.RaporYazdir("raporlar");
            maasBordro.KisaRaporYazdir();
        }
    }
}

