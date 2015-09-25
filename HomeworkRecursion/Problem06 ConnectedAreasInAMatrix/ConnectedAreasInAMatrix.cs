using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem06_ConnectedAreasInAMatrix
{
    public class ConnectedAreasInAMatrix
    {
        static char[,] matrix = new char[,]
        {
            {' ', ' ', ' ', '*', ' ', ' ' , ' ', '*', ' ' },
            {' ', ' ', ' ', '*', ' ', ' ' , ' ', '*', ' ' },
            {' ', ' ', ' ', '*', ' ', ' ' , ' ', '*', ' ' },
            {' ', ' ', ' ', ' ', '*', ' ' , '*', ' ', ' ' }
        };

        //static char[,] matrix = new char[,]
        //{
        //    {'*', ' ', ' ', '*', ' ', ' ' , ' ', '*', ' ', ' '},
        //    {'*', ' ', ' ', '*', ' ', ' ' , ' ', '*', ' ', ' '},
        //    {'*', ' ', ' ', '*', '*', '*' , '*', '*', ' ', ' '},
        //    {'*', ' ', ' ', '*', ' ', ' ' , ' ', '*', ' ', ' '},
        //    {'*', ' ', ' ', '*', ' ', ' ' , ' ', '*', ' ', ' '}
        //};

        static SortedSet<ConnectedArea> areas = new SortedSet<ConnectedArea>();

        public static void Main()
        {
            int[] startPoint = FindStartPoint();

            while (startPoint != null)
            {
                ConnectedArea newArea = new ConnectedArea()
                {
                    Row = startPoint[0],
                    Col = startPoint[1],
                    Size = 0
                };

                FindConnectedCells(startPoint[0], startPoint[1], newArea);

                areas.Add(newArea);
                startPoint = FindStartPoint();
            }

            PrintAreas(areas);
        }

        private static void PrintAreas(SortedSet<ConnectedArea> areas)
        {
            Console.WriteLine("Total areas found: {0}", areas.Count);
            int counter = 0;
            foreach (var area in areas)
            {
                counter++;
                Console.WriteLine("Area #{0} at ({1}, {2}), size: {3}", counter, area.Row, area.Col, area.Size);
            }
        }

        private static void FindConnectedCells(int row, int col, ConnectedArea newArea)
        {
            if (
                row < 0 ||
                col < 0 ||
                row >= matrix.GetLength(0) ||
                col >= matrix.GetLength(1)
                )
            {
                return;
            }

            if (matrix[row, col] == '*' || matrix[row, col] == 'v')
            {
                return;
            }

            newArea.Size++;
            matrix[row, col] = 'v';

            FindConnectedCells(row, col + 1, newArea);
            FindConnectedCells(row, col - 1, newArea);
            FindConnectedCells(row + 1, col, newArea);
            FindConnectedCells(row - 1, col, newArea);
        }

        private static int[] FindStartPoint()
        {
            int[] startPoint = new int[2];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == ' ')
                    {
                        startPoint[0] = row;
                        startPoint[1] = col;

                        return startPoint;
                    }
                }
            }

            return null;
        }
    }
}
