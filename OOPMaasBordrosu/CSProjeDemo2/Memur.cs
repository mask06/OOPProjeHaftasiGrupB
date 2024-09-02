﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CSProjeDemo2.Memur;

namespace CSProjeDemo2
{
    public class Memur : Personel
    {
        public MemurKademesi MKademesi { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int CalismaSaati { get; set; }

        public decimal AnaOdeme { get; set; }

        public decimal Mesai { get; set; }

        public decimal ToplamOdeme { get; set; }
        
        public Memur(string name, int calismaSaati, MemurKademesi memurKademesi)
        {
            Name = name;
            CalismaSaati = calismaSaati;
            MKademesi = memurKademesi;  

        }

        public override decimal MaasHesapla()
        {

            if (CalismaSaati > 180)
            {
                AnaOdeme = 180 * (int)(this.MKademesi);
                Mesai = (CalismaSaati - 180) * (int)(this.MKademesi) * (150 / 100);
                ToplamOdeme = AnaOdeme + Mesai;
            }
            else
                ToplamOdeme = CalismaSaati * (int)(this.MKademesi);
            return ToplamOdeme;
        }
    }
}
