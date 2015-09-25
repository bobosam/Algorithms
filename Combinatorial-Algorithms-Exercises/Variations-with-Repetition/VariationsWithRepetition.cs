using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variations_with_Repetition
{
    public class VariationsWithRepetition
    {
        public static void Main(string[] args)
        {
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("K = ");
            int k = int.Parse(Console.ReadLine());
            int[] array = new int[k];

            GenerateVariations(array, n);
        }

        private static void GenerateVariations(int[] array, int sizeOfSet, int index = 0)
        {
            if (index >= array.Length)
            {
                Print(array);
            }
            else
            {
                for (int i = 1; i <= sizeOfSet; i++)
                {
                    array[index] = i;
                    GenerateVariations(array, sizeOfSet, index + 1);
                }
            }
        }

        private static void Print(int[] array)
        {
            Console.WriteLine("({0})", string.Join(", ", array));
        }
    }
}
