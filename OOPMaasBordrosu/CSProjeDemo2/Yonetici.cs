﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    public class Yonetici : Personel
    {
        private decimal _bonus = 1000;

        public string Name { get; set; }
        public string Title { get; set; }
        public int CalismaSaati { get; set; }

        public decimal AnaOdeme { get; set; }

        public decimal Bonus
        {
            get { return _bonus; }

        }

        public decimal ToplamOdeme { get; set; }


        public Yonetici()
        {
            
        }

        int saatlikucret = 800;
        
        public Yonetici(int calismaSaati)
        {
            CalismaSaati = calismaSaati;
        }

        public override decimal MaasHesapla()
        {
            AnaOdeme = CalismaSaati * saatlikucret;
            ToplamOdeme = AnaOdeme + _bonus;
            return ToplamOdeme;
        }
    }
}
