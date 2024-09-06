using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    public class Yonetici : Personel
    {
        private decimal _bonus = 1000;

        [JsonPropertyOrder(5)]
        public decimal Bonus
        {
            get { return _bonus; }

        }



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
