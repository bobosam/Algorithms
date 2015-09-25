namespace CombinationsWithRepetition
{
    using System;
    using System.Linq;

    class CombinationsWithRepetition
    {
        static int countOfSelectedElements;
        static int countOfSetElements;
        static int[] elements;
        static int[] vector;
        
        public static void Main()
        {
            bool checkInput = false;

            while (!checkInput)
            {
                Console.Write("Please enter the count of set elements N: ");
                string inputNLine = Console.ReadLine();
                Console.Write("Please enter the count of selected elements K: ");
                string inputKLine = Console.ReadLine();
                Console.WriteLine();

                checkInput = int.TryParse(inputKLine, out countOfSelectedElements) && int.TryParse(inputNLine, out countOfSetElements);
                bool positiveCount = countOfSelectedElements > 0 && countOfSetElements > countOfSelectedElements;
                checkInput = checkInput && positiveCount;
            }

            vector = new int[countOfSelectedElements];
            elements = Enumerable.Range(1, countOfSetElements).ToArray();
            NestedLoops(0, 0);

        }

        static void NestedLoops(int vectorIndex, int elementIndex)
        {
            if (vectorIndex == countOfSelectedElements)
            {
                PrintLoops();
                return;
            }

            for (int counter = elementIndex; counter < countOfSetElements; counter++)
            {
                vector[vectorIndex] = counter;
                NestedLoops(vectorIndex + 1, counter);
            }
        }

        static void PrintLoops()
        {
            Console.Write("( ");
            for (int i = 0; i < countOfSelectedElements; i++)
            {
                Console.Write("{0} ", elements[vector[i]]);
            }

            Console.WriteLine(")");
        }
    }
}
