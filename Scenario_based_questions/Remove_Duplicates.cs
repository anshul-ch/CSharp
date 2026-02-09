using System;

namespace CSharp.Scenario_based_questions
{
    class Remove_Duplicates
    {
        static void Main()
        {
            int[] data = { 4, 5, 4, 3, 5, 2, 3 };
            int[] unique = new int[data.Length];
            int count = 0;

            for (int i = 0; i < data.Length; i++)
            {
                bool exists = false;

                for (int j = 0; j < count; j++)
                {
                    if (unique[j] == data[i])
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    unique[count] = data[i];
                    count++;
                }
            }

            for (int i = 0; i < count; i++)
            {
                Console.Write(unique[i] + " ");
            }
        }
    }
}