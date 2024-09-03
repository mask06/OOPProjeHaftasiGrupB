using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    public class Yonetici : Personel
    {
        
        int saatlikucret = 800;
        int bonus = 1000;
        public Yonetici(int calismaSaati)
        {
            CalismaSaati = calismaSaati;    
        }

        public override decimal MaasHesapla()
        {
            AnaOdeme = CalismaSaati * saatlikucret;
            ToplamOdeme = AnaOdeme + bonus;
            return ToplamOdeme;
        }
    }
}
