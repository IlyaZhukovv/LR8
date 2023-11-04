using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размер матрицы: ");
            int size = Convert.ToInt32(Console.ReadLine());

            int[,] adjacencyMatrix = GenerateAdjacencyMatrix(size);

            Console.WriteLine("Матрица смежности для графа G1:");
            PrintMatrix(adjacencyMatrix);

            Console.Write("Введите вершину, с которой начать обход: ");
            int startVertex = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Результат обхода в ширину:");
            BreadthFirstSearch(adjacencyMatrix, startVertex); 
        }
        //Метод GenerateAdjacencyMatrix генерирует случайную матрицу смежности для графа.
        private static int[,] GenerateAdjacencyMatrix(int size)
        {
            Random r = new Random();

            int[,] matrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i != j)
                    {
                        //для каждой пары вершин (i, j) генерируется случайное число 0 или 1, которое указывает наличие или отсутствие ребра между вершинами.
                        matrix[i, j] = r.Next(2);
                        matrix[j, i] = matrix[i, j];
                    }
                }
            }
            return matrix;
        }
        //Метод PrintMatrix выводит матрицу смежности на экран.
        static void PrintMatrix(int[,] matrix)
        {
            int size = matrix.GetLength(0);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        //метод, выполняющий обход в ширину графа, начиная с указанной начальной вершины
        //В процессе обхода каждая посещенная вершина выводится на экран.Обход осуществляется с помощью очереди:
        //начальная вершина добавляется в очередь, затем извлекается из очереди и все её смежные не посещенные
        //вершины добавляются в очередь.Этот процесс продолжается, пока очередь не опустеет.
        private static void BreadthFirstSearch(int[,] adjacencyMatrix, int startVertex)
        {
            int size = adjacencyMatrix.GetLength(0);
            bool[] visited = new bool[size];
            Queue<int> queue = new Queue<int> ();

            //Помечаем начальную вершину как посещенную
            visited[startVertex] = true;

            //Добавляем начальную вершину в очередь
            queue.Enqueue(startVertex);

            while(queue.Count > 0)
            {
                //Извлекаем следующую вершину из очереди
                int currentVertex = queue.Dequeue();

                Console.WriteLine("Посещена вершина: №" + currentVertex);

                for (int i = 0; i < size; i++)
                {
                    if (adjacencyMatrix[currentVertex,i] == 1 && !visited[i])
                    {
                        //Помечаем смежную вершину как посещенную
                        visited[i] = true;
                        //Добавляем смежную вершину в очередь
                        queue.Enqueue(i);
                    }
                }
            }
        }
    }
}
