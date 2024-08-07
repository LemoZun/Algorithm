using System.Security.Cryptography.X509Certificates;

namespace Searching
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 3, 5, 7, 9, 8, 6, 4, 2, 0 };
            Console.Write("배열 : ");
            foreach (int value in array)
            {
                Console.Write($" {value} ");
            }
            Console.WriteLine();

            //int index = Util.IndexOf(array, 2);
            //int index2 = Array.IndexOf(array, index); // c# 기본 구현, 배열이면 Array, 리스트면 List
            //Console.WriteLine($"순차 탐색 결과 위치 : {index}");
            //Console.WriteLine();
            Array.Sort(array);
            foreach (int value in array)
            {
                Console.Write($" {value} ");
            }
            Console.WriteLine();
            int index4 = Util.BinarySearch(array, 2);
            int index5 = Array.BinarySearch(array, 2); // c# 기본 구현
            Console.WriteLine($"이진 탐색 결과 위치 : {index4}");
            Console.WriteLine();

            bool[,] graph = new bool[8, 8];

            bool[] dfsVisited;
            int[] dfsParent;
            Util.DFS(graph, 0, out dfsVisited, out dfsParent);

            bool[] bfsVisited;
            int[] bfsParent;
           //  Util.BFS(graph, 0, out bfsVisited, out bfsParent);


        }
    }
    


    public class Util
    {
        // 깊이 우선 탐색
        public static void DFS(bool[,] graph, int start, out bool[] visited, out int[] parent)
        {
            int size = graph.GetLength(0); // 그래프의 정점 개수
            visited = new bool[size]; // visited : 탐색 여부
            parent = new int[size]; // 정점을 탐색한 정점이 누구인지 (역순이면 경로가 나옴)

            for(int i = 0; i<size; i++) //초기화
            {
                visited[i] = false;
                parent[i] = -1;
            }
            SearchNode(graph, start, visited, parent);
        }

        public static void SearchNode(bool[,] graph, int vertex, bool[] visited, int[] parent)
        {
            int size = graph.GetLength(0);
            visited[vertex] = true; // 이 정점을 탐색했다는 뜻

            for(int i = 0;i<size;i++)
            {
                if (graph[vertex,i] == true && // 연결되어있는 정점
                    visited[i] == false) // 찾은적 없는 정점, 이미 찾았던 걸 되돌아 갈 필요는 없음
                {
                    parent[i] = vertex;
                    SearchNode(graph, i, visited, parent);
                }
            }
        }


        // 너비 우선 탐색
        public static void BFS(bool[,] graph, int start, out bool[] visited, int[] parent)
        {
            int size = graph.GetLength(0); // 정점의 개수
            visited = new bool[size]; // 정점의 탐색 여부
            parent = new int[size]; // 해당 정점을 누가 찾았는지(역순 경로)

            for(int i = 0; i < size; i++)
            {
                visited[i] = false;
                parent[i] = -1;
            }

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            visited[start] = true;

            while(queue.Count > 0)
            {
                int vertex = queue.Dequeue();

                for(int i = 0; i < size;i++)
                {
                    if (graph[vertex, i] == true && //연결 되어 있는 정점
                        visited[i] == false) // 찾은 적 없는 정점
                    {
                        visited[i] = true; // 탐색 여부 체크
                        parent[i] = vertex; // 탐색하게되는 정점을 표시
                        queue.Enqueue(i); // 탐색해야 하는 정점을 큐에 추가
                    }
                }
            }
        }



        public static int IndexOf(int[] array, int target)
        {
            int result = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    result = i; break;
                }
            }
            return result;
        }

        public static bool Contains(int[] array, int target)
        {
            if (Array.IndexOf(array, target) == -1)            
                return false;            
            else return true;
        }

        public static int BinarySearch(int[] array, int target)
        {
            int result = -1;
            int min = 0;
            int max = array.Length;

            while (min <= max)
            {
                int mid = (min + max) / 2; // 중간위치
                if (array[mid] < target)
                {
                    min = mid + 1;
                }
                else if (array[mid] > target)
                {
                    max = mid - 1;
                }
                else // if(array[mid] == target)
                {
                    result = mid;
                    break;
                }
            }
            return result;
        }
    }


}
