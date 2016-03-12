using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Timus
{
    class Program
    {
        static void Main(string[] args)
        {
            char repeat = 'Y', TaskKey = ' ';
            do
            {
                Console.Clear();
                Console.WriteLine(Timus.Description.description);
                int key = Convert.ToInt32( Console.ReadLine());

                while (TaskKey != 'N')
                {
                    //if (TaskKey != ' ') Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("#" + key);
                    MethodInfo Method = Type.GetType("Timus.Tasks").GetMethod("Num" + key.ToString());
                    Method.Invoke(null, null);
                    Console.WriteLine("\nХотите ввести новый набор данных?(Y/N): ");
                    TaskKey = Convert.ToChar(Console.Read());
                    Console.ReadLine();
                }
                TaskKey = ' ';

                Console.WriteLine("Перейти к выбору задачи: Y - да");
                repeat = Console.ReadKey().KeyChar;
            } while (repeat == 'Y');
        }
    }
}
