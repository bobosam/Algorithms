using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCombinationsWithRepetition
{
    public class CombinationsWithRepetition
    {
        public static void Main(string[] args)
        {
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("K = ");
            int k = int.Parse(Console.ReadLine());
            int[] array = new int[k];

            GenerateCombinations(array, n, 0);
        }

        private static void GenerateCombinations(int[] array, int sizeOfSet, int index, int start = 1)
        {
            if (index >= array.Length)
            {
                Print(array);
            }
            else
            {
                for (int i = start; i <= sizeOfSet; i++)
                {
                    array[index] = i;
                    GenerateCombinations(array, sizeOfSet, index + 1, i);
                }
            }

        }

        private static void Print(int[] array)
        {
            Console.WriteLine("({0})", string.Join(", ", array));
        }
    }
}
