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

        [JsonPropertyOrder(5)]
        public decimal Mesai { get; set; }


        [JsonIgnore] // MKademenin serilaze edilirken jsona yazılmaması için kullandık.
        public MemurKademesi MKademesi { get; set; }

        public Memur()
        {

        }

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
            else if (CalismaSaati >= 0)
            {
                AnaOdeme = CalismaSaati * (int)(this.MKademesi);
                Mesai = 0;
                ToplamOdeme = AnaOdeme + Mesai;
            }

            this.AnaOdeme = AnaOdeme;
            this.Mesai = Mesai;
            this.ToplamOdeme = ToplamOdeme;

            return ToplamOdeme;
        }
    }
}

