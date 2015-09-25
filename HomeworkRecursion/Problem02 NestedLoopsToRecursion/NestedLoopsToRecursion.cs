namespace Problem02_NestedLoopsToRecursion
{
    using System;

    public class NestedLoopsToRecursion
    {
        static int countLoops;
        static int[] loops;

        public static void Main()
        {
            bool checkInput = false;

            while (!checkInput)
            {
                Console.Write("Please enter the number of loops: ");
                string inputLine = Console.ReadLine();
                Console.WriteLine();
                checkInput = int.TryParse(inputLine, out countLoops);
                bool positiveCount = countLoops > 0;
                checkInput = checkInput && positiveCount;
            }
            loops = new int[countLoops];
            NestedLoops(0);

        }

        static void NestedLoops(int currentLoop)
        {
            if (currentLoop == countLoops)
            {
                PrintLoops();
                return;
            }

            for (int counter = 1; counter <= countLoops; counter++)
            {
                loops[currentLoop] = counter;
                NestedLoops(currentLoop + 1);
            }
        }

        static void PrintLoops()
        {
            for (int i = 0; i < countLoops; i++)
            {
                Console.Write("{0} ", loops[i]);
            }
            Console.WriteLine();
        }
    }
}
