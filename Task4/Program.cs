using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Для вывода изображения введите число строк N: ");
                string nTriagles = Console.ReadLine();
                int countTriagles;
                while (!IsValid(nTriagles, out countTriagles))
                {
                    Console.WriteLine("Введено не валидное значение. Введите число треугольников N: ");
                    nTriagles = Console.ReadLine();
                }

                DrawFigure(countTriagles);
                Console.WriteLine(Environment.NewLine);
            }

        }

        /// <summary>
        /// Рисует фигуру
        /// </summary>
        /// <param name="nTriagles">количество треугольников</param>
        private static void DrawFigure(int nTriagles)
        {
            DrawFirstTriangle(nTriagles-1);
                 
            for (int i = 2; i <= nTriagles; i++)
            {
                for (int j = 1; j <= i + 1; j++)
                {
                    int countSpaces = nTriagles - j;
                    for (int space = 0; space <= countSpaces; space++)
                        Console.Write(" ");
                    int countStars = 2 * j - 1;
                    for (int s = 1; s <= countStars; s++)
                        Console.Write("*");

                    Console.WriteLine(String.Empty);
                }
            }
        }

        /// <summary>
        /// Не стандартный первый треугольник
        /// </summary>
        /// <param name="countSpaces"></param>
        private static void DrawFirstTriangle(int countSpaces)
        {
            for (int space = 0; space <= countSpaces; space++)
                Console.Write(" ");
            Console.Write("*");
            Console.WriteLine(String.Empty);
            for (int space = 0; space <= countSpaces; space++)
                Console.Write(" ");
            Console.Write("*");
            Console.WriteLine(String.Empty);
            for (int space = 0; space <= countSpaces - 1; space++)
                Console.Write(" ");
            Console.Write("***");
            Console.WriteLine(String.Empty);
        }


        /// <summary>
        /// Проверка валидности значения
        /// </summary>
        /// <param name="dimension"></param>
        /// <returns></returns>
        public static bool IsValid(string number, out int count)
        {
            int value;
            if (Int32.TryParse(number, out value))
                if (value > 0)
                {
                    count = value;
                    return true;
                }
            count = 0;
            return false;

        }

    }
}
