namespace Problem01_TowerOfHanoi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TowerOfHanoi
    {
        private static int stepsTaken = 0;
        private static Stack<int> source;
        private static readonly Stack<int> destination = new Stack<int>();
        private static readonly Stack<int> spare = new Stack<int>();

        public static void Main()
        {
            bool checkInput = false;
            int countDisks = 0;

            while (!checkInput)
            {
                Console.Write("Please enter the number of disks: ");
                string inputLine = Console.ReadLine();
                Console.WriteLine();
                checkInput = int.TryParse(inputLine, out countDisks);
                bool positiveCount = countDisks > 0;
                checkInput = checkInput && positiveCount;
            }

            source = new Stack<int>(Enumerable.Range(1, countDisks).Reverse());

            PrintRods();
            Console.WriteLine();

            MoveDisks(countDisks, source, destination, spare);
        }

        private static void PrintRods()
        {
            Console.WriteLine("Source: {0}", string.Join(", ", source.Reverse()));
            Console.WriteLine("Destination: {0}", string.Join(", ", destination.Reverse()));
            Console.WriteLine("Spare: {0}", string.Join(", ", spare.Reverse()));
        }

        private static void MoveDisks(int bottomDisc, Stack<int> sourceRod, Stack<int> destinationRod, Stack<int> spareRod)
        {
            if (bottomDisc == 1)
            {
                stepsTaken++;
                destinationRod.Push(sourceRod.Pop());
                Console.WriteLine("Step #{0}: Moved disc {1}", stepsTaken, bottomDisc);
                PrintRods();
                Console.WriteLine();
            }
            else
            {
                //Move from source to spare as destination.
                MoveDisks(bottomDisc - 1, sourceRod, spareRod, destinationRod);

                stepsTaken++;
                destinationRod.Push(sourceRod.Pop());
                Console.WriteLine("Step #{0}: Moved disc {1}", stepsTaken, bottomDisc);
                PrintRods();
                Console.WriteLine();

                //Move from spare as source to destination.
                MoveDisks(bottomDisc - 1, spareRod, destinationRod, sourceRod);
            }
        }
    }
}
