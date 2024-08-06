# 탐색 알고리즘

## 선형 자료구조 탐색

### 순차 탐색(IndexOf)
자료구조에서 순차적으로 찾고자 하는 데이터를 탐색하는 방법   
시간복잡도 : O(n)

### 이진 탐색(BinarySearch)
숫자가 정렬되어 있어야 사용 가능   
정렬되어있는 자료구조에서 2분할을 통해 데이터를 탐색
시간복잡도 : O(logn)

## 비선형 자료구조 탐색
<!--[깊이 우선과 너비 우선](https://devuna.tistory.com/32)-->

### 깊이 우선 탐색(DFS)

- 그래프의 분기를 최대한 깊이 내려간 뒤, 더이상 깊이 갈 곳이 없을 경우 옆 분기로 이동함
- 루트노드에서 시작한 후 다음 분기로 넘어가기 전에 해당 분기를 완벽하게 탐색함
- 재귀(스택)을 통해 구현할 수 있다
- 모든 노드를 방문하고자 하는 경우 사용
- 깊이 우선 탐색보다 간단하지만 검색 속도가 느림
- 단점 : 최단 경로를 보장하지 않음
- 트리는 경로가 하나라 트리에서 사용하기 좋음


#### 구현

```c#
// 깊이 우선 탐색
public static void DFS(bool[,] graph, int start, out bool[] visited, out int[] parent)
{
    int size = graph.GetLength(0);
    visited = new bool[size];
    parent = new int[size];

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
```


### 너비 우선 탐색(BFS)
- 그래프의 분기를 만났을 때 모든 분기들을 탐색 후 다음 깊이의 분기를 탐색
- 루트노드에서 시작한 후 인접한 노드를 먼저 탐색하는 방법
- 큐를 사용해 구현 가능
- 두 노드사이의 `최단 경로`를 찾고 싶을 때 사용
- 단점 : 많은 메모리를 필요로 함
- 그래프(경로를 여러개 가질 수 있음)에서 사용하기 좋음
#### 구현
```c#
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
```
