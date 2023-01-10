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
           //estrazioni dei numeri
            Random rnd = new Random();
            List<int> numbers = Enumerable.Range(1, 90).ToList();

            while (numbers.Count > 0)
            {
                int a = rnd.Next(numbers.Count);
                int numero = numbers[a];
                Console.WriteLine("Il prossimo numero {0}", numero);
                numbers.RemoveAt(a);
            }
        }
    }
}
