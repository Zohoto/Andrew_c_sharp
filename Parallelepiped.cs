using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Parallelepiped
    {
        private int x;
        private int y;
        private int z;
        private int l;
        private int w;
        private int h;
        public Parallelepiped(int l, int w, int h)
        { //конструктор для создания параллелепипедов
            Console.WriteLine("Параллелепипед находится в начале координат");
            x = 0; y = 0; z = 0;
            this.l = l;
            this.w = w;
            this.h = h;

        }

        public void Move()
        {//переносим параллелепипе на начальные координаты
            Console.WriteLine("Введите координаты, куда вы хотите его переместить. Учтите знаки");
            Console.Write("x: ");
            int dx = Convert.ToInt32(Console.ReadLine());
            Console.Write("y: ");
            int dy = Convert.ToInt32(Console.ReadLine());
            Console.Write("z: ");
            int dz = Convert.ToInt32(Console.ReadLine());
            x = dx;
            y = dy;
            z = dz;
            Console.WriteLine("x: {0}, y: {1}, z: {2}", x, y, z);
        }

        public string ChangeSize()
        {//изменение размеров в несколько раз
            Console.WriteLine("Вы хотите уменьшить или увеличить?(1 - уменьшить, 2 - увеличить)");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Во сколько раз вы хотите изменить размеры?(если укажете \"0\", то размеры не изменятся)");
            int mult = Convert.ToInt32(Console.ReadLine());
            string con;
            if (mult == 0)
            {
                con = string.Format("length: {0}, width: {1}, height: {2}", l, w, h);
                return con;
            }
            else if (choice == 1)
            {
                l /= mult;
                w /= mult;
                h /= mult;
                return string.Format("length: {0}, width: {1}, height: {2}", l, w, h);
            }
            else
            {
                l *= mult;
                w *= mult;
                h *= mult;
                return string.Format("length: {0}, width: {1}, height: {2}", l, w, h);
            }
        }
        //выбираем параллелепипед меньшего размера по объему фигур
        public static string MinFigure(ref Parallelepiped figure1, ref Parallelepiped figure2) 
        {
            int x0 = Math.Min(figure1.x, figure2.x);
            int y0 = Math.Min(figure1.y, figure2.x);
            int z0 = Math.Min(figure1.z, figure2.z);
            int l0 = Math.Max(figure1.l + figure1.x, figure2.l + figure2.x);
            int w0 = Math.Max(figure1.y + figure1.w, figure2.y + figure2.w);
            int h0 = Math.Max(figure1.z + figure1.h, figure2.z + figure2.h);
            return string.Format("x: {0}, y: {1}, z: {2}, length: {3}, width: {4}, height: {5}", x0, y0, z0, l0-x0, w0-y0, h0-z0);

        }

        //находим общую часть между двумя параллелепипедами, учитывается, что фигуры могут и вовсе не пересекаться
        public static string General(ref Parallelepiped figure1, ref Parallelepiped figure2)
        {
            int x0, y0, z0;
            int l0, w0, h0;
            if ((Math.Abs(figure1.x) + figure1.l >= Math.Abs(figure2.x)) && (figure2.x >= figure1.x))
            {//здесь знак
                x0 = figure2.x;
                l0 = Math.Abs(figure1.x) + figure1.l - Math.Abs(figure2.x);
            }
            else if ((Math.Abs(figure2.x) + figure2.l >= Math.Abs(figure1.x)) && (figure2.x <= figure1.x))
            {
                x0 = figure1.x;
                l0 = Math.Abs(figure2.x) + figure2.l - Math.Abs(figure1.x);
            }
            else
                return string.Format("Не пересекается");

            if ((Math.Abs(figure1.y) + figure1.w >= Math.Abs(figure2.y)) && (figure2.y >= figure1.y))
            {
                y0 = figure2.y;
                w0 = Math.Abs(figure1.y) + figure1.w - Math.Abs(figure2.y);
            }
            else if ((Math.Abs(figure2.y) + figure2.w >= Math.Abs(figure1.y)) && (figure2.y <= figure1.y))
            {
                y0 = figure1.y;
                w0 = Math.Abs(figure2.y) + figure2.w - Math.Abs(figure1.y);
            }
            else
                return string.Format("Не пересекается");

            if ((Math.Abs(figure1.z) + figure1.h >= Math.Abs(figure2.z)) && (figure2.z >= figure1.z))
            {
                z0 = figure2.z;
                h0 = Math.Abs(figure1.z) + figure1.h - Math.Abs(figure2.z);
            }
            else if ((Math.Abs(figure2.z) + figure2.h >= Math.Abs(figure1.z)) && (figure2.z <= figure1.z))
            {
                z0 = figure1.z;
                h0 = Math.Abs(figure2.z) + figure2.h - Math.Abs(figure1.z);
            }
            else
                return string.Format("Не пересекается");
            return string.Format("Начальные координаты пересечения: x: {0}, y: {1}, z: {2}. Размеры:\n" +
                "Длина: {3}\nШирина: {4}\nВысота: {5}", x0, y0, z0, l0, w0, h0);
        }
    }
}