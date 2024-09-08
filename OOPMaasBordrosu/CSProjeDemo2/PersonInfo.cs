using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    //Personel sınıfı abstract olduğu için bu sınıftan obje oluşturamıyorduk. Bu sebeple "PersonInfo" sınıfı oluşturularak json dosyasını okuayabildik.
    public class PersonInfo
    {
        public string Name { get; set; }

        public string Title { get; set; }


    }
}
