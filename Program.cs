
// счастливым считается билет с номером a1a2...aNa1b2...bN для которого выполняется условие a1+a2+...+aN = b1+b2+...+bN
// 
// длина половины номера N/2, проверим, что N четно

int N = 8;
if (N % 2 == 0)
{
    ulong res = findNumbDecomposition(N / 2);
    Console.WriteLine(res);
}
else
{
    Console.WriteLine("N - нечетно");
}

ulong findNumbDecomposition(int N) {
    ulong[] curArr;
    ulong res = 0;

    // инициируем начальный массив для N=1
    curArr = new ulong[10];
    for (int i = 0; i < 10; i++)
        curArr[i] = 1;

    for(int i = 1; i < N; i++) 
        curArr = getNextArr(curArr);
 
    for(int i=0; i < curArr.Length; i++)
        res += curArr[i]*curArr[i]; 

    return res;
}

ulong[] getNextArr(ulong[] curArr)
{
    // каждый следующий массив на 9 элементов длинее
    // N=1  - 0..9
    // N=2  - 0..18
    // N=3  - 0..27
    int curLen = curArr.Length;
    int newLen = curLen + 9;
    ulong[] newArr = new ulong[newLen];


    for (int i = 0; i < newLen; i++)
    {
        ulong w = 0; // временная переменная
        int jj;
        // сумма 10 элементов предыдущего массива, у которых индекс <= искомому значению.
        for (int j = 0; j < 10; j++)
        {
            jj = i - j;
            // проверяем границу
            if((jj < curLen) && (jj>-1)) 
                w += curArr[jj];  // добавляем
        }

        newArr[i] = w;
    }

    return newArr;
}