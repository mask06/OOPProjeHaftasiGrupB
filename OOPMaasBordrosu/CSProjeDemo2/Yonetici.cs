using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    //Personel ata sınıfını kalıtım alan Yonetici sub class oluşturuldu. 
    public class Yonetici : Personel
    {
        // Yonetici için sabit saatlik ücret belirlendi.(field)
        int saatlikucret = 800;

        //Yonetici için sabit bonus değeri belirlendi.(field)
        private decimal _bonus = 1000;

        [JsonPropertyOrder(5)]
        public decimal Bonus
        {
            get { return _bonus; }

        }

        //Create Person (dosyaoku sınıfı) metotu için boş constractor tanımladık.
        public Yonetici()
        {
            
        }

        //Constractur tanımlanarak Yonetici objesi oluşturulurken çalışma saati objenin içerisine yerleştirmiş olduk.
        public Yonetici(int calismaSaati)
        {
            CalismaSaati = calismaSaati;
        }

        //Personel sınıfında abstract olan Maas Hesapla metotu override ile ezilerek yönetici sınıfı için özelleştirildi.
        public override decimal MaasHesapla()
        {
            AnaOdeme = CalismaSaati * saatlikucret;
            ToplamOdeme = AnaOdeme + _bonus;
            return ToplamOdeme;
        }
    }
}
