using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tortici
{
    internal class Zagruzka
    {
        public int S_Vas;
        public string V_Itoge = "";
        public void file()
        {
            File.AppendAllText("C:\\Users\\Eliza\\OneDrive\\История заказов.txt", "\nДата: "
            + DateTime.Now + "\nСтоимость заказа: " + S_Vas + "\nСоставляющие торта - " 
            + V_Itoge + "\nСпасибо за заказ!\n");
        }
    }
}
