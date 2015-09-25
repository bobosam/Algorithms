namespace Problem05_PathsBetweenCellsInMatrix
{
    using System;
    using System.Collections.Generic;

    public class PathsBetweenCellsInMatrix
    {
        //static char[,] lab =
        //{
        //    {'s', ' ', ' ', ' '},
        //    {' ', '*', '*', ' '},
        //    {' ', '*', '*', ' '},
        //    {' ', '*', 'e', ' '},
        //    {' ', ' ', ' ', ' '}
        //};

        static char[,] lab =
        {
            {'s', ' ', ' ', ' ', ' ', ' '},
            {' ', '*', '*', ' ', '*', ' '},
            {' ', '*', '*', ' ', '*', ' '},
            {' ', '*', 'e', ' ', ' ', ' '},
            {' ', ' ', ' ', '*', ' ', ' '}
        };

        static List<char> path = new List<char>();
        static int[] startCellPosition = new int[2];
        static int pathsCount = 0;

        static void FindPath(int row, int col, char direction)
        {
            if (
                col < 0 ||
                row < 0 ||
                col >= lab.GetLength(1) ||
                row >= lab.GetLength(0)
                )
            {
                //out of labyrinth
                return;
            }

            if (lab[row, col] == '*' || lab[row, col] == 'v')
            {
                return;
            }

            if (lab[row, col] == 'e')
            {
                pathsCount++;
                PrintPath(path, direction);
                return;
            }

            path.Add(direction);

            //mark visited
            lab[row, col] = 'v';

            FindPath(row, col - 1, 'L'); //left
            FindPath(row, col + 1, 'R'); // right
            FindPath(row - 1, col, 'U'); //up
            FindPath(row + 1, col, 'D'); // down

            lab[row, col] = ' ';

            //remove direction from path
            path.RemoveAt(path.Count - 1);
        }

        private static void PrintPath(List<char> path, char direction)
        {
            for (int i = 1; i < path.Count; i++)
            {
                Console.Write(path[i]);
            }

            Console.WriteLine(direction);
        }

        public static void Main()
        {
            try
            {
                startCellPosition = FindStart();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            FindPath(startCellPosition[0], startCellPosition[1], 'S');
            Console.WriteLine("Total paths found: {0}", pathsCount);
        }

        private static int[] FindStart()
        {
            for (int row = 0; row < lab.GetLength(0); row++)
            {
                for (int col = 0; col < lab.GetLength(1); col++)
                {
                    if (lab[row, col] == 's')
                    {
                        return new int[] { row, col };
                    }
                }
            }

            throw new InvalidOperationException("Failed to find starting position");
        }
    }
}


