using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    public abstract class Personel
    {
        [JsonPropertyOrder(1)]
        public string Name { get; set; }

        [JsonPropertyOrder(2)]
        public string Title { get; set; }

        [JsonPropertyOrder(3)]
        public int CalismaSaati { get; set; }

        [JsonPropertyOrder(4)]
        public decimal AnaOdeme { get; set; }

        [JsonPropertyOrder(6)]
        public decimal ToplamOdeme { get; set; }
        protected Personel()
        {
            
        }
        public abstract decimal MaasHesapla();

    }
}