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
        public string Name { get; set; }
        public string Title { get; set; }
        public int CalismaSaati { get; set; }

        public decimal AnaOdeme { get; set; }

        public decimal ToplamOdeme { get; set; }
        protected Personel()
        {
            
        }
        public abstract decimal MaasHesapla();

    }
}