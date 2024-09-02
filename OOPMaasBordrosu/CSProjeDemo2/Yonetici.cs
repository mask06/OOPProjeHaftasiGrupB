using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    internal class Yonetici : Personel
    {
        int saatlikucret = 800;
        int bonus = 1000;
        public override decimal MaasHesapla()
        {
            AnaOdeme = CalismaSaati * saatlikucret;
            ToplamOdeme = AnaOdeme + bonus;
            return ToplamOdeme;
        }
    }
}
