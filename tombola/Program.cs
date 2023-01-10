using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tombola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            //tabellone
            List<int> numbers = Enumerable.Range(1, 90).ToList();

            for (int t = 90; t < 300; t++)
            {
                int a = rnd.Next(numbers.Count);
                int numero = numbers[a];
                Thread.Sleep(1000);
                if (a == 10 || a == 20 || a == 30 || a == 40 || a == 50 || a == 60 || a == 70 || a == 80 || a == 90)
                {
                    Console.SetCursorPosition(18, ((a / 10) - 1));
                    Console.WriteLine(a+" ");
                }
                else
                {
                    int b = a - ((a / 10) * 10);
                    int c = ((b * 2) - 2);
                    int d = a / 10;
                    Console.SetCursorPosition(c, d);
                    Console.WriteLine(a+" ");
                }
                numbers.RemoveAt(numero);

            }
        }
    }
}
