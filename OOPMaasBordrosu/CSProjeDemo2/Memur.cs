using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static CSProjeDemo2.Memur;

namespace CSProjeDemo2
{
    //Personel ata sınıfını kalıtım alan Memur sub class oluşturuldu. 
    public class Memur : Personel
    { 

        [JsonPropertyOrder(5)]
        public decimal Mesai { get; set; }

        // Memur Kademesinin serilaze edilirken jsona yazılmaması için kullandık.

        [JsonIgnore] 
        public MemurKademesi MKademesi { get; set; }

        //Create Person (dosyaoku sınıfı) metotu için boş constractor tanımladık.
        public Memur()
        {

        }
        //Constractur tanımlanarak Memur objesi oluşturulurken çalışma saati ve memur kademeleri objenin içerisine yerleştirmiş olduk.
        public Memur(int calismaSaati, MemurKademesi memurKademesi)
        {
            CalismaSaati = calismaSaati;
            MKademesi = memurKademesi;
        }
        //Personel sınıfında abstract olan Maas Hesapla metotu override ile ezilerek memur sınıfı için özelleştirildi.
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

