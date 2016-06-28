using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            
            for (int i = 1; i < 1000; i++)
            {
                int remainderOf3 = i % 3;
                int remainderOf5 = i % 5;
                if (remainderOf3 == 0 || remainderOf5 == 0)
                    sum += i;

            }
            Console.WriteLine("Сумма всех чисел меньше 1000 и кратных 3 и 5 равняется: {0}", sum);
            Console.ReadKey();
        }
    }
}
