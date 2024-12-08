using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GetRandow
{
    public static int Randow(int[] array)
    {
        int total = 0; //�}�C�����v�`�M

        foreach (int i in array) //�p��}�C�����v�`�M
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
