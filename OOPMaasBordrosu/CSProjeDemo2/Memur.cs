﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static CSProjeDemo2.Memur;

namespace CSProjeDemo2
{
    public class Memur : Personel
    {
        public decimal Mesai { get; set; }

        public Memur()
        {
            
        }

        public MemurKademesi MKademesi { get; set; }

        public Memur(int calismaSaati, MemurKademesi memurKademesi)
        {
            CalismaSaati = calismaSaati;
            MKademesi = memurKademesi;
        }

        public override decimal MaasHesapla()
        {
            if (CalismaSaati > 180)
            {
                AnaOdeme = 180 * (int)(this.MKademesi);
                Mesai = (CalismaSaati - 180) * (int)(this.MKademesi) * (15 / 10);
                ToplamOdeme = AnaOdeme + Mesai;
            }
            else if (CalismaSaati > 0)
            {
                AnaOdeme = CalismaSaati * (int)(this.MKademesi);
                Mesai = 0;
                ToplamOdeme = AnaOdeme + Mesai;
            }
            else // (CalismaSaati <=0)
            {
                throw new Exception("Hatalı Çalışma Saati");
            }
            

            this.AnaOdeme = AnaOdeme;
            this.Mesai = Mesai;
            this.ToplamOdeme = ToplamOdeme;
            
            return ToplamOdeme;
        }
    }
}

