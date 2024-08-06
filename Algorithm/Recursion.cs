namespace Algorithm
{
    internal class Recursion
    {
        public class Folder
        {
            public string name;
            public List<Folder> children = new List<Folder>();
        }

        public static void RemoveFolder(Folder folder)
        {

            for (int i = 0; i < folder.children.Count; i++)
            {
                RemoveFolder(folder.children[i]);
            }
            Console.WriteLine($"{folder.name} 폴더를 삭제합니다.");

        }

        public static int Factorial(int value)
        {
            if (value == 1) return 1;

            return value = Factorial(value - 1);

        }

        public static int Fibonachi(int value) // O(2^n) 재귀로 구현하면 최악
        {
            if (value == 1 || value == 2)
                return 1;

            return Fibonachi(value - 1) + Fibonachi(value - 2);
        }


        static void Main()
        {
            Folder parentFolder = new Folder() { name = "부모폴더" };
            Folder childrenFolder1 = new Folder() { name = "자식폴더1" };
            Folder childrenFolder2 = new Folder() { name = "자식폴더2" };

            parentFolder.children.Add(childrenFolder1);
            parentFolder.children.Add(childrenFolder2);

            RemoveFolder(parentFolder);
        }

        public static void QuickSort(int[] array, int start, int end)
        {
            int pivot = start;
            int left = pivot + 1;
            int right = end;

            while (left <= right)
            {
                while (array[left] <= array[pivot] && left < right)
                {
                    left++;
                }
                while (array[right] > array[pivot] && left <= right)
                {
                    right--;
                }

                if (left < right)
                {
                    int temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                }
                else
                {
                    int tmep = array[right];
                    array[right] = array[pivot];
                    array[pivot] = tmep;
                    break;
                }
            }

            QuickSort(array, start, right - 1);
            QuickSort(array, right + 1, end);
        }


        //병합정렬
        public static void MergeSort(int[] array, int start, int end)
        {
            if (start == end)
                return;
            int mid = (start + end) / 2;
            MergeSort(array, start, mid);
            MergeSort(array, mid + 1, end);
            Merge(array, start, mid, end);
        }

        public static void Merge(int[] array, int start, int mid, int end)
        {
            List<int> sortedList = new List<int>();
            int leftIndex = start;
            int rightIndex = mid + 1;

            // 왼쪽 배열과 오른쪽 배열 중 하나라도 모두 소진될때까지
            while (leftIndex <= mid && rightIndex <= end)
            {
                //왼쪽 배열의 요소가 더 작을 경우
                if(array[leftIndex] < array[rightIndex])
                {
                    // 추가 메모리공간에 왼쪽 요소 추가하고 인덱스 한칸 이동
                    sortedList.Add(leftIndex);
                    leftIndex++;
                }
                //오른쪽 배열의 요소가 더 작을 경우
                else
                {
                    //추가 메모리공간에 오른쪽 요소 추가하고 인덱스 한칸 이동
                    sortedList.Add((int)array[rightIndex]);
                    rightIndex++;
                }
            }
            // 남아 있는 배열을 모두 나머지 뒷쪽으로 붙이기
            if(leftIndex > mid) // 왼쪽 배열이 모두 소진됐을 때
            {
                while(rightIndex <= end)
                {
                    sortedList.Add(array[rightIndex]);
                    rightIndex++;
                }                
            }
            else // 오른쪽 배열이 모두 소진됐을 때
            {
                while(leftIndex <= mid)
                {
                    sortedList.Add(array[leftIndex]);
                    leftIndex++;
                }
            }

            //추가적인 메모리에 정렬 시켜두었던 것을 다시 원래 배열에다 교체
            for (int i = 0; i < sortedList.Count; i++)
            {
                array[start + i] = sortedList[i];
            }
        }
    }
}
