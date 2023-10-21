using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tortici
{
    internal class Podpunkt
    {
        public string Name;
        public int Price;
        public string Valuta;
        
        public Podpunkt(string name, int price, string valuta)
        {
            Name = name;
            Price = price;
            Valuta = valuta;
            
        }
    }
}