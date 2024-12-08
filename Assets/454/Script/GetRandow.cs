using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GetRandow
{
    public static int Randow(int[] array)
    {
        int total = 0; //陣列內機率總和

        foreach (int i in array) //計算陣列內機率總和
        {
            total += i;
        }

        int rd = Random.Range(0, total + 1);
        int tmp = 0;

        for (int i = 0; i < array.Length; i++)
        {
            tmp += array[i];
            if (rd < tmp)
            {
                return i;
            }
        }

        return 0;
    }
}
