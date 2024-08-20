# 알고리즘

알고리즘이란 문제를 해결하기 위한 과정을 논리적 절차에 따라 구성한 일련의 단계, 입력값에 따른 결과가 도출되는것

## 알고리즘의 설계 과정
문제 이해 -> 예시와 테스트 케이스 작성 -> 알고리즘 설계 -> 알고리즘 구현 및 검증 -> 알고리즘 분석과 계산

### 1. 문제의 이해
알고리즘을 풀어내며 가장 먼저 해야할것은 문제의 요구사항을 분석하고 입력과 출력의 형식을 파악하는것

### 2. 예시와 테스트 케이스 작성
예시를 들어 무엇을 넣었을 시 어떠한 결과를 도출 해 내는지 파악해야한다. 이를 테스트 케이스를 작성한다고 표현한다.

### 3. 알고리즘 설계
문제 해결을 위한 알고리즘 구상 단계
최우선 목표는 `정확도`이며 그 다음 고려사항은 `효율성`과 `Big O`값이다.<br>
설계시 `의사코드(pseudo 코드)` 혹은 흐름도를 먼저 그리는 것이 좋다.

#### 의사코드의 예시
```
while(b가 100보다 작다면?)
{
  i를 1 올린다;
  if(배열의 i번째 요소가 10보다 크다면?)
    {
      b를 제곱 시킨다;
      n도 올려서 총 b가 몇번 제곱되었는지 측정;
    }
}
```

### 4. 알고리즘 구현 및 검증
설계에서 만든 의사코드나 흐름도에 따라 코드를 작성한다. 그 후 사전에 작성한 테스크 케이스로 검증을 거친다.

### 5. 알고리즘 분석과 개선
작동이 정상적이라면 성능 분석을 통해 최적화와 개선의 여지가 있는지 확인한다.

입력에 따른 정확한 출력이 나와야 알고리즘이라고 할 수 있다.   
알고리즘을 설계할 때는 알고리즘의 `정확성`과 이를 검증할 `검증 방법`을 최우선으로 고려해야한다.

## 재귀(Recursion)

어떠한 것을 정의할 때 자기 자신을 참조하는것으로   
함수를 정의할 때 자기 자신을 이용하여 표현하는 방법   

### 재귀함수의 조건
1. 함수내용 중 자기자신함수를 다시 호출해야 함
2. 반드시 종료조건이 있어야함

### 재귀 사용이 좋은 상황
1. 반복사용이 정의하기 힘든 내용도 재귀를 이용하면 가능하다
2. 작업 효율이 올라가는 상황이 있다.
    - EX)2의 n승 구하기
        
```c#
//2^8 = 2^4 * 2^4 = 2^2 * 2^2 * 2^2 * 2^2 

public static int LoopPow(int value, int pow) // O(pow)
{
    int result = 1
    for(int i = 0; i<pow; i++)
    {
        result += value;
    }
    return result;
}

public static int Pow(int value, int pow) // O(log(Pow))
{
    if(pow == 1)
        return value;

    return Pow(value * value, pow/2)
}
```
 

---

- EX1) 팩토리얼
```C#
// 팩토리얼은 재귀로 설명하기 편한 알고리즘이지만 효율성 있는 유용한 알고리즘은 아님
public static int Factorial(int value)
{
    if(value == 1) return 1;

    return value = value * Factorial(value - 1);
}

```
<br>

- EX2) 폴더 삭제
```C#
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
    static void Main()
    {
        Folder parentFolder = new Folder() { name = "부모폴더" };
        Folder childrenFolder1 = new Folder() { name = "자식폴더1" };
        Folder childrenFolder2 = new Folder() { name = "자식폴더2" };
        parentFolder.children.Add(childrenFolder1);
        parentFolder.children.Add(childrenFolder2);
        RemoveFolder(parentFolder);
    }
}
```



<!-- 주석-->
