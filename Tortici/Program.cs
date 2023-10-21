using System.Collections.Generic;
using Tortici;
using System.IO;
using System.Diagnostics;
using Menu;
using System.Linq;

internal class Program
{
    private static int С_Вас = 0;
    private static string В_Итоге = "";
    private static List<Punkt> punkts= new List<Punkt> { };
    static void Main()
    {
                
        Podpunkt krug = new Podpunkt("Круглая форма", 1100, "P");
        Podpunkt serd = new Podpunkt("Форма сердечко", 1500, "P");
        Podpunkt kvadr = new Podpunkt("Квадратная форма", 1200, "P");
        Podpunkt oval = new Podpunkt("Форма овал", 1000, "P");
        Punkt forma = new Punkt();
        forma.Name = "Форма торта";
        forma.MenuName = "Выберите форму торта";
        forma.Podpunkts = new List<Podpunkt> { krug, serd, kvadr, oval };
       

        Podpunkt mal = new Podpunkt("Диаметр - 10", 333, "P");
        Podpunkt sred = new Podpunkt("Диаметр - 20", 444, "P");
        Podpunkt bolsh = new Podpunkt("Диаметр - 30", 555, "P");
        Podpunkt ogromn = new Podpunkt("Диаметр - 40", 777, "P");
        Punkt razmer = new Punkt();
        razmer.Name = "Размер торта";
        razmer.MenuName = "Выберите размер торта";
        razmer.Podpunkts = new List<Podpunkt> { mal, sred, bolsh, ogromn };


        Podpunkt shocolad = new Podpunkt("Шоколаный вкус", 10, "P");
        Podpunkt limon = new Podpunkt("Лимонный вкус", 10, "P");
        Podpunkt ananas = new Podpunkt("Ананасовый вкус", 10, "P");
        Podpunkt klubnica = new Podpunkt("Клубничный вкус", 10, "P");
        Punkt vkys = new Punkt();
        vkys.Name = "Вкус торта";
        vkys.MenuName = "Выберите вкусы";
        vkys.Podpunkts = new List<Podpunkt> { shocolad, limon, ananas, klubnica };


        Podpunkt kol1 = new Podpunkt("1 коржик", 250, "P");
        Podpunkt kol2 = new Podpunkt("2 коржика", 500, "P");
        Podpunkt kol3 = new Podpunkt("3 коржика", 1000, "P");
        Podpunkt kol4 = new Podpunkt("4 коржика", 1500, "P");
        Punkt kolichestvo = new Punkt();
        kolichestvo.Name = "Количество коржиков";
        kolichestvo.MenuName = "Выберите количество коржей";
        kolichestvo.Podpunkts = new List<Podpunkt> { kol1, kol2, kol3, kol4 };
              
                
        Podpunkt Коричневая = new Podpunkt("Коричневая глазурь", 10, "P");
        Podpunkt Желтая = new Podpunkt("Желтая глазурь", 10, "P");
        Podpunkt Оранжевая = new Podpunkt("Оранжевая глазурь", 10, "P");
        Podpunkt Розовая = new Podpunkt("Розовая глазурь", 10, "P"  );
        Punkt glazur = new Punkt();
        glazur.Name = "Виды глазури";
        glazur.MenuName = "Выберите глазурь";
        glazur.Podpunkts = new List<Podpunkt> { Коричневая, Желтая, Оранжевая, Розовая };


        Podpunkt iagodi = new Podpunkt("Декор ягодки", 100, "P");
        Podpunkt zvezdochi = new Podpunkt("Декор звездочки", 80, "P");
        Podpunkt charici = new Podpunkt("Декор шарики", 70, "P");
        Podpunkt posipca = new Podpunkt("Декор шоколаная посыпка", 60, "P");
        Punkt decor = new Punkt();
        decor.Name = "Декор для торта";
        decor.MenuName = "Выберите декор";
        decor.Podpunkts = new List<Podpunkt> { iagodi, zvezdochi, charici, posipca};

        punkts = new List<Punkt> { forma, razmer, vkys, kolichestvo, glazur, decor };

        Menu();
    }
    
    static void Menu(int pos = 1)
    {
        Console.WriteLine("~~~ Добро пожаловать в ТОРТАЛЕТКУ - ЛУЧШУЮ КОНДИТЕРСКУЮ В МИРЕ! Создайте свой торт!! ~~~");
        foreach (Punkt item in punkts)
        
        {
            Console.WriteLine("\t" + item.Name);
        }
               
        Console.WriteLine("\t" + "Я готов сделать заказ!");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~"+
            "\nИтоговая цена: " + С_Вас + "\t"+ "\nСоставляющее вашего заказа: " + В_Итоге);

        int pos1 = Strelochka.Show(1, punkts.Count + 1, pos);
        if (pos1 > punkts.Count)
            Zagruz_In_File();
        else
            Pod_Menu(punkts[index: pos1 - 1], pos1);
       
    }
    static void Pod_Menu(Punkt podmenu, int pos)
    {
        Console.WriteLine("~~~~~  " + podmenu.MenuName + "  ~~~~~");
        foreach (Podpunkt podpunkt in podmenu.Podpunkts)
        {
            Console.WriteLine("\t" + podpunkt.Name + " - " + podpunkt.Price + " " + podpunkt.Valuta);
        }
        int pos1 = Strelochka.Show(1, podmenu.Podpunkts.Count) - 1;
        С_Вас += podmenu.Podpunkts[pos1].Price;
        В_Итоге += podmenu.Podpunkts[pos1].Name + ", ";
        Menu(pos);
    }
            
    static void Zagruz_In_File()
    {
        Console.WriteLine("\nВаш заказ принят! Спасибо за заказ!!" +
            "\nНажмите Esc для выхода :(" +
            "\nНажмите любую клавишу, если желаете сделать еще один заказ :)");

        Zagruzka Файл = new();
        Файл.V_Itoge = В_Итоге;
        Файл.S_Vas = С_Вас;
        Файл.file();
        В_Итоге = "";
        С_Вас = 0;
        ConsoleKeyInfo key = Console.ReadKey();

        if (key.Key == ConsoleKey.Escape)
        {
            Console.Clear();
            Environment.Exit(0); 
        }
        else
        {
            Console.Clear();
            Main();
        }
    }  
}


