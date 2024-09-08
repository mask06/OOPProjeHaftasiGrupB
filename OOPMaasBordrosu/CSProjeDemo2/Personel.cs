using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    //Ata sınıf olan abstract personel sınıfı oluşturuldu. 
    public abstract class Personel
    {
        //JSON formatında yazılacak propertylerin sırasını belirlemek için "JsonPropertyOrder" kullanıldı.
        [JsonPropertyOrder(1)]
        public string Name { get; set; }

        [JsonPropertyOrder(2)]
        public string Title { get; set; }

        [JsonPropertyOrder(3)]
        public int CalismaSaati { get; set; }

        [JsonPropertyOrder(4)]
        public decimal AnaOdeme { get; set; }

        // [JsonPropertyOrder(5)] sub classlardaki propertylere verildi.

        [JsonPropertyOrder(6)]
        public decimal ToplamOdeme { get; set; }
        protected Personel()
        {
            
        }

        //Sub sınflarda ezilmesi için abstract metot oluşturuldu.
        public abstract decimal MaasHesapla();

    }
}