using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    public class MaasBordro
    {
        public void MaasBordroOlustur(List<Personel> personelListesi)
        {
            Console.WriteLine("----------------------- Maaş Bordrosu -----------------------");

            // Calculate and display payroll for each personnel
            foreach (var personel in personelListesi)
            {
                Console.WriteLine($"Ad: {personel.Name} Title: {personel.Title}");
               
                Console.WriteLine($"Hesaplanan Maaş: {personel.MaasHesapla()}");
                Console.WriteLine("----------------------------------------------------------");
            }
        }
    }
}
