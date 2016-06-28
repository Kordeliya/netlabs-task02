using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Для вывода изображения введите число треугольников N: ");
                string nLines = Console.ReadLine();
                int countLines;
                while(!IsValid(nLines, out countLines))
                {
                     Console.WriteLine("Введено не валидное значение. Введите число треугольников N: ");
                     nLines = Console.ReadLine();
                }

                DrawFigure(countLines);
                Console.WriteLine(Environment.NewLine);        
            }
        }

        /// <summary>
        /// Рисует фигуру
        /// </summary>
        /// <param name="nLines">количество строк</param>
        private static void DrawFigure(int nLines)
        {
            for(int i=1; i <= nLines; i++)
            {
                for (int j = 1; j <= i; j++)
                    Console.Write("*");

                Console.WriteLine(String.Empty);
            }
        }




        /// <summary>
        /// Проверка валидности значения
        /// </summary>
        /// <param name="dimension"></param>
        /// <returns></returns>
        public static bool IsValid(string number, out int countLines)
        {
            int value;
            if (Int32.TryParse(number, out value))
                if (value > 0)
                {
                    countLines = value;
                    return true;
                }
            countLines = 0;
            return false;

        }
    }
}
