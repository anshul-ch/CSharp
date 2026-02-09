using System;

class Array_Rotation
{
    static void Main()
    {
        int[] arr = { 10, 20, 30, 40, 50 };
        int k = Convert.ToInt32(Console.ReadLine());

        int n = arr.Length;
        k = k % n;

        int[] rotated = new int[n];
        int index = 0;

        for (int i = n - k; i < n; i++)
        {
            rotated[index++] = arr[i];
        }

        for (int i = 0; i < n - k; i++)
        {
            rotated[index++] = arr[i];
        }

        for (int i = 0; i < n; i++)
        {
            Console.Write(rotated[i] + " ");
        }
    }
}
