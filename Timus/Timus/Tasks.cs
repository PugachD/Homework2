using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timus
{
    public class Tasks
    {
            public static void Num1()
        {
            Console.WriteLine(@"Формулировка: Выведите 2 числа — количество банок, не простреленных Гарри и Ларри соответственно.");
            int[] listInt = new int[2];
            int sum = -1;
            for (int i = 0; i != 2; i++)
            {
                listInt[i] = Convert.ToInt32(Console.ReadLine());
                sum += listInt[i];
            }
            foreach (int i in listInt)
                Console.WriteLine((sum - i).ToString());
        }
        public static void Num2()
        {
            Console.WriteLine(@"Формулировка: Вывести на экран сообщение «Hello World!».");
            int[] listInt = new int[10000];
            int n, i, _max = 0, x;
            listInt[0] = 0;
            listInt[1] = 1;
            x = Convert.ToInt32(Console.ReadLine());
            while (x != 0)
            {
                for (i = 1; i <= x; i++)
                {
                    listInt[i * 2] = listInt[i];
                    listInt[i * 2 + 1] = listInt[i] + listInt[i + 1];
                    if (listInt[i] > _max)
                        _max = listInt[i];
                }
                Console.WriteLine( _max);
                x = Convert.ToInt32(Console.ReadLine());
            }
        }
        public static void Num3()
        {
            Console.WriteLine(@"Формулировка: Найти сумму всех целых чисел, лежащих между 1 и N включительно.");
            int N = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i != N; i += (N / Math.Abs(N)))
                sum += i;
            Console.WriteLine("Сумма равна " + sum);
        }
    }
}
