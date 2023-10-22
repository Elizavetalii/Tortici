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
    private static int mainPosition = 1;
    private static List<Punkt> punkts = new() { };
    static void Main()
    {
                
        Podpunkt krug = new("Круглая форма", 1100);
        Podpunkt serd = new("Форма сердечко", 1500);
        Podpunkt kvadr = new("Квадратная форма", 1200);
        Podpunkt oval = new("Форма овал", 1000);
        Punkt forma = new()
        {
            Name = "Форма торта",
            MenuName = "Выберите форму торта",
            Podpunkts = new List<Podpunkt> { krug, serd, kvadr, oval }
        };

        Podpunkt mal = new("Диаметр - 10", 333);
        Podpunkt sred = new("Диаметр - 20", 444);
        Podpunkt bolsh = new("Диаметр - 30", 555);
        Podpunkt ogromn = new("Диаметр - 40", 777);
        Punkt razmer = new()
        {
            Name = "Размер торта",
            MenuName = "Выберите размер торта",
            Podpunkts = new List<Podpunkt> { mal, sred, bolsh, ogromn }
        };

        Podpunkt shocolad = new("Шоколаный вкус", 10);
        Podpunkt limon = new("Лимонный вкус", 10);
        Podpunkt ananas = new("Ананасовый вкус", 10);
        Podpunkt klubnica = new("Клубничный вкус", 10);
        Punkt vkys = new()
        {
            Name = "Вкус торта",
            MenuName = "Выберите вкусы",
            Podpunkts = new List<Podpunkt> { shocolad, limon, ananas, klubnica }
        };

        Podpunkt kol1 = new("1 коржик", 250);
        Podpunkt kol2 = new("2 коржика", 500);
        Podpunkt kol3 = new("3 коржика", 1000);
        Podpunkt kol4 = new("4 коржика", 1500);
        Punkt kolichestvo = new()
        {
            Name = "Количество коржиков",
            MenuName = "Выберите количество коржей",
            Podpunkts = new List<Podpunkt> { kol1, kol2, kol3, kol4 }
        };

        Podpunkt Коричневая = new("Коричневая глазурь", 10);
        Podpunkt Желтая = new("Желтая глазурь", 10);
        Podpunkt Оранжевая = new("Оранжевая глазурь", 10);
        Podpunkt Розовая = new("Розовая глазурь", 10);
        Punkt glazur = new()
        {
            Name = "Виды глазури",
            MenuName = "Выберите глазурь",
            Podpunkts = new List<Podpunkt> { Коричневая, Желтая, Оранжевая, Розовая }
        };

        Podpunkt iagodi = new("Декор ягодки", 100);
        Podpunkt zvezdochi = new("Декор звездочки", 80);
        Podpunkt charici = new("Декор шарики", 70);
        Podpunkt posipca = new("Декор шоколаная посыпка", 60);
        Punkt decor = new()
        {
            Name = "Декор для торта",
            MenuName = "Выберите декор",
            Podpunkts = new List<Podpunkt> { iagodi, zvezdochi, charici, posipca }
        };

        punkts = new List<Punkt> { forma, razmer, vkys, kolichestvo, glazur, decor };

        Menu();
    }
    
    static void Menu()
    {
        Console.WriteLine("~~~ Добро пожаловать в ТОРТАЛЕТКУ - ЛУЧШУЮ КОНДИТЕРСКУЮ В МИРЕ! Создайте свой торт!! ~~~");
        foreach (Punkt item in punkts)
        
        {
            Console.WriteLine("\t" + item.Name);
        }
               
        Console.WriteLine("\t" + "Я готов сделать заказ!");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~"+
            "\nИтоговая цена: " + С_Вас + "\t"+ "\nСоставляющее вашего заказа: " + В_Итоге);
        
        mainPosition = Strelochka.Show(1, punkts.Count + 1, mainPosition);
        if (mainPosition > punkts.Count)
            Zagruz_In_File();
        else
            Pod_Menu(punkts[index: mainPosition - 1]);
       
    }
    static void Pod_Menu(Punkt podmenu)
    {
        Console.WriteLine("~~~~~  " + podmenu.MenuName + "  ~~~~~");
        foreach (Podpunkt podpunkt in podmenu.Podpunkts)
        {
            Console.WriteLine("\t" + podpunkt.Name + " - " + podpunkt.Price + " " + podpunkt.Valuta);
        }
        int pos1 = Strelochka.Show(1, podmenu.Podpunkts.Count) - 1;
        С_Вас += podmenu.Podpunkts[pos1].Price;
        В_Итоге += podmenu.Podpunkts[pos1].Name + ", ";
        Menu();
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


