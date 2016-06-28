using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Для вычисления площади прямоугольника необходимо ввести данные.");
                Console.WriteLine("Введите ширину: ");
                int width = CheckValue(Console.ReadLine(), "Ширина");
                Console.WriteLine("Введите длину: ");
                int length = CheckValue(Console.ReadLine(), "Длина");
                var area = GetArea(width, length);
                Console.WriteLine("Площадь прямоугольника равняется:  {0}", area);
                Console.WriteLine(Environment.NewLine);
            }


        }
        /// <summary>
        /// Получение площади прямоугольника
        /// </summary>
        /// <param name="width">ширина</param>
        /// <param name="length">длина</param>
        /// <returns></returns>
        public static int GetArea(int width, int length)
        {
            int area = width * length;
            return area;

        }
        /// <summary>
        /// Проверка значения параметра
        /// </summary>
        /// <param name="value">значение</param>
        /// <param name="nameValue">имя параметра</param>
        /// <returns></returns>
        public static int CheckValue(string value, string nameValue)
        {
            bool isNotSuccess = true;
            int dimension;
            do
            {
                if (Int32.TryParse(value, out dimension))
                {
                    if (!IsValid(dimension))
                    {
                        Console.WriteLine(String.Format("{0} не может иметь отрицательное значение или значение 0", nameValue));
                        Console.WriteLine("Введите валидное значение: ");
                        value = Console.ReadLine();
                    }
                    else
                        isNotSuccess = false;
                }
                else
                {
                    Console.WriteLine("Не валидное значение. Введите целое число");
                    value = Console.ReadLine();
                }

            }
            while (isNotSuccess);

            return dimension;
        }

        /// <summary>
        /// Проверка валидности значения
        /// </summary>
        /// <param name="dimension"></param>
        /// <returns></returns>
        public static bool IsValid(int dimension)
        {
            if (dimension > 0)
                return true;

            return false;

        }
    }
}
