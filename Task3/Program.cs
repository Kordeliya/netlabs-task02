using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Для вывода изображения введите число строк N: ");
                string nLines = Console.ReadLine();
                int countLines;
                while (!IsValid(nLines, out countLines))
                {
                    Console.WriteLine("Введено не валидное значение. Введите число строк N: ");
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
            for (int i = 1; i <= nLines; i++)
            {
                int countSpaces = nLines - i - 1;
                for (int space = 0; space <= countSpaces; space++)
                    Console.Write(" ");
                int countStars = 2*i - 1;
                for (int j = 1; j <= countStars; j++)
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
