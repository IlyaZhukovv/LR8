using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размер марицы: ");
            int size = Convert.ToInt32(Console.ReadLine());

            int[,] adjacencyMatrix = GenerateAdjacencyMatrix(size);

            Console.WriteLine("Матрица смежности для графа G1:");
            PrintMatrix(adjacencyMatrix);

            Console.Write("Введите вершину, с которой начать обход: ");
            int startVertex = Convert.ToInt32(Console.ReadLine());

            DateTime startTime = DateTime.Now;

            Console.WriteLine("Результат обхода в ширину(List): ");
            BFS(adjacencyMatrix, startVertex);

            DateTime endTime = DateTime.Now;
            TimeSpan listTime = endTime - startTime;

            Console.WriteLine("Время работы обхода в ширину(с использованием класса List): " + listTime.TotalMilliseconds + " миллисекунд");

            DateTime startTime2 = DateTime.Now;

            Console.WriteLine("\n" + "Результат обхода в ширину(Queue):");
            BreadthFirstSearch(adjacencyMatrix, startVertex);

            DateTime endTime2 = DateTime.Now;
            TimeSpan listTime2 = endTime2 - startTime2;

            Console.WriteLine("Время работы обхода в ширину(с использованием класса Queue): " + listTime2.TotalMilliseconds + " миллисекунд");
        }

        static void BFS(int[,] graph, int startVertex)
        {
            int size = graph.GetLength(0);

            //Создается массив "visited" размером "size", который будет хранить информацию о посещенных вершинах.
            bool[] visited = new bool[size];
            for (int i = 0; i < size; i++)
            {
                //В начале все элементы массива устанавливаются в значение "false".
                visited[i] = false;
            }
            //Создается пустой список "queue", который будет использоваться для хранения вершин, ожидающих обработки.
            List<int> queue = new List<int>();

            //Метод начинает с посещения стартовой вершины "startVertex", устанавливая соответствующий элемент в массиве "visited" в значение "true" и добавляя вершину в "queue".
            visited[startVertex] = true;
            queue.Add(startVertex);

            //пока "queue" не пуст, выполняется следующее: 
            while (queue.Count > 0)
            {
                //Извлекается первая вершина из "queue" и сохраняется в переменной "currentVertex".
                int currentVertex = queue[0];

                //Посещенная вершина "currentVertex" выводится на консоль.
                Console.WriteLine("Посещена вершина: №" + currentVertex);
                queue.RemoveAt(0);

                for (int i = 0; i < size; i++)
                {
                    //Для каждой смежной вершины "i" с "currentVertex", если она еще не посещена (элемент "visitedi" равен "false") и есть ребро между "currentVertex" и "i" (элемент "graph[currentVertex, i]" равен 1), выполняется: 
                    if (graph[currentVertex, i] == 1 && !visited[i])
                    {
                        //Пометить "i" как посещенную
                        visited[i] = true;
                        //Добавить "i" в "queue".
                        queue.Add(i);
                    }
                }
            }
        }
        private static void BreadthFirstSearch(int[,] adjacencyMatrix, int startVertex)
        {
            //Создается массив "visited" размером "size", который будет хранить информацию о посещенных вершинах.
            int size = adjacencyMatrix.GetLength(0);
            bool[] visited = new bool[size];

            //Создается пустая очередь "queue", которая будет использоваться для хранения вершин, ожидающих обработки.
            Queue<int> queue = new Queue<int>();

            //Помечаем начальную вершину как посещенную
            visited[startVertex] = true;

            //Добавляем начальную вершину в очередь
            queue.Enqueue(startVertex);

            while (queue.Count > 0)
            {
                //Извлекаем следующую вершину из очереди
                int currentVertex = queue.Dequeue();

                //Посещенная вершина "currentVertex" выводится на консоль.
                Console.WriteLine("Посещена вершина: №" + currentVertex);

                for (int i = 0; i < size; i++)
                {
                    //Для каждой смежной вершины "i" с "currentVertex", если она еще не посещена (элемент "visitedi" равен "false") и есть ребро между "currentVertex" и "i" (элемент "adjacencyMatrix[currentVertex, i]" равен 1),
                    if (adjacencyMatrix[currentVertex, i] == 1 && !visited[i])
                    {
                        //Помечаем смежную вершину как посещенную
                        visited[i] = true;
                        //Добавляем смежную вершину в очередь
                        queue.Enqueue(i);
                    }
                }
            }
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
    }
}
