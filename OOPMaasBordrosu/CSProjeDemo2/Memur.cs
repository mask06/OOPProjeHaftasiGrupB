using System;
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
                Mesai = (CalismaSaati - 180) * (int)(this.MKademesi) * (150 / 100);
                ToplamOdeme = AnaOdeme + Mesai;
            }
            else
            {
                AnaOdeme = CalismaSaati * (int)(this.MKademesi);
                ToplamOdeme = AnaOdeme;
            }
            this.AnaOdeme = AnaOdeme;
            this.ToplamOdeme = ToplamOdeme;
            
            return ToplamOdeme;
        }
    }
}

