using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет. Ты сейчас находишься в программе, где ты можешь поработать с параллелепиедом.\n" +
                "В программе будет исползоваться 2 параллелепипеда, поэтому введи их размеры");
            Console.WriteLine("Введите параметры 1 параллелепипеда");
            Console.Write("Длина: ");
            int l = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ширина: ");
            int w = Convert.ToInt32(Console.ReadLine());
            Console.Write("Высота: ");
            int h = Convert.ToInt32(Console.ReadLine());
            Parallelepiped figure1 = new Parallelepiped(l, w, h);

            Console.WriteLine("Введите параметры 2 параллелепипеда");
            Console.Write("Длина: ");
            l = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ширина: ");
            w = Convert.ToInt32(Console.ReadLine());
            Console.Write("Высота: ");
            h = Convert.ToInt32(Console.ReadLine());
            Parallelepiped figure2 = new Parallelepiped(l, w, h);

            Console.WriteLine("Оба параллелепипед находятся в начальных координатах.");
            while (true) //меню, для работы над двумя параллелепипедами
            {
                Console.WriteLine("Ты сейчас в меню. Тебе нужно выбрать, что сделать с параллелепипедом. " +
                "В консоль введи цифру:\n" +
                "1.Переместить\n2.Изменить размер\n3.Построить наименьший параллелепипед из двух\n4.Построить общую часть");
                switch (Convert.ToInt32(Console.ReadLine())) {
                    case 1:
                        Console.Write("Какой параллелепипед вы хотите подвинуть? ");
                        switch (Convert.ToInt32(Console.ReadLine())){
                            case 1:
                                figure1.Move();
                                break;
                            case 2:
                                figure2.Move();
                                break;
                        }
                        break;
                    case 2:
                        Console.Write("У какого параллелепипеда вы хотите изменить размер? ");
                        switch (Convert.ToInt32(Console.ReadLine()))
                        {
                            case 1:
                                Console.WriteLine(figure1.ChangeSize());
                                break;
                            case 2:
                                Console.WriteLine(figure2.ChangeSize());
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine(Parallelepiped.MinFigure(ref figure1, ref figure2));
                        break;
                    case 4:
                        Console.WriteLine(Parallelepiped.General(ref figure1, ref figure2));
                        break;
                    default:
                        Console.WriteLine("Еще раз");
                        break;
                }
            }
        }
    }
}
