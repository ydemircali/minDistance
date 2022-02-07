using System;
using System.Collections.Generic;

namespace minDistance
{
    public class QItem
    {
        public int Col {get;set;}
        public int Row {get;set;}
        public int Dist{get;set;}

        public QItem(int row, int col, int dist)
        {
            Row = row;
            Col = col;
            Dist = dist;
        }
    }

    class Program
    {
        static int minDistance(List<List<int>> area)
        {
            Queue<QItem> queue = new Queue<QItem>();
            queue.Enqueue(new QItem(0, 0 , 0)); //  starting from top-left corner

            bool[,] visited = new bool[area.Count , area[0].Count];
            visited[0, 0] = true;

            while (queue.Count != 0)
            {
                QItem itemDequeue = queue.Dequeue();

                //dest found
                if (area[itemDequeue.Row][itemDequeue.Col] == 9)
                {
                    return itemDequeue.Dist;
                }
                //moving up
                if (isValid(itemDequeue.Row - 1, itemDequeue.Col, area, visited)) 
                {
                    queue.Enqueue(new QItem(itemDequeue.Row - 1, itemDequeue.Col,
                                        itemDequeue.Dist + 1));
                    visited[itemDequeue.Row - 1, itemDequeue.Col] = true;
                }

                //moving rigth
                if (isValid(itemDequeue.Row, itemDequeue.Col+1, area, visited)) 
                {
                    queue.Enqueue(new QItem(itemDequeue.Row, itemDequeue.Col+1,
                                        itemDequeue.Dist + 1));
                    visited[itemDequeue.Row, itemDequeue.Col+1] = true;
                }

                //moving left
                if (isValid(itemDequeue.Row, itemDequeue.Col-1, area, visited)) 
                {
                    queue.Enqueue(new QItem(itemDequeue.Row, itemDequeue.Col-1,
                                        itemDequeue.Dist + 1));
                    visited[itemDequeue.Row, itemDequeue.Col-1] = true;
                }

                //moving down
                if (isValid(itemDequeue.Row+1, itemDequeue.Col, area, visited)) 
                {
                    queue.Enqueue(new QItem(itemDequeue.Row+1, itemDequeue.Col,
                                        itemDequeue.Dist + 1));
                    visited[itemDequeue.Row+1, itemDequeue.Col] = true;
                }


            }

            return -1;
        }

        private static bool isValid(int row, int col, List<List<int>> area, bool[,] visited)
        {
            if (row >= 0 && col >= 0 && row < area.Count
                && col < area[0].Count && area[row][col] != 0
                && visited[row, col] == false) 
            {
                return true;
            }

            return false;
        }

        static void Main(string[] args)
        {
            List<List<int>> grid = new List<List<int>>();
            grid.Add(new List<int>{1, 0 ,0 ,0});
            grid.Add(new List<int>{1, 0 ,9 ,0});
            grid.Add(new List<int>{1, 1 ,1 ,0});
            grid.Add(new List<int>{1, 1 ,1 ,0});
            var dateStart = DateTime.Now;
            Console.WriteLine(minDistance(grid));
            Console.WriteLine((DateTime.Now - dateStart).TotalSeconds);
        }
    }
}
