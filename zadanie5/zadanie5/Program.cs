using System;
using System.Collections;
using System.Collections.Generic;

namespace zadanie5
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 5;
            int[,] mass = new int[5, 5];
            List<int> list = new List<int>();
            Random rnd = new Random();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    mass[i, j] = rnd.Next(-50, 50);
                }
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    Console.Write(String.Format("{0,5}", mass[i, j]));
                Console.WriteLine();
            }

            int count = 0;
            bool check = false;
            int sum = 0;
            
                for (int i = 0; i < size; i++)
                {
                    sum = 0;
                    for (int j = 0; j < size; j++)
                    {
                    if (i == j && mass[i, j] < 0)
                    {

                        for (int k = i; k < i + 1; k++)
                        {
                            for (int p = 0; p < j; p++)
                            {
                                sum += mass[k, p];
                            }
                        }
                        list.Add(sum);

                    }
                    else if (i == j && mass[i, j] >= 0)
                    {
                        for (int k = i; k < i + 1; k++)
                        {
                            for (int p = 0; p < size; p++)
                            {
                                if (mass[k, p] < 0)
                                {
                                    count = p;
                                    check = true;
                                    break;
                                }
                                
                            }
                            if (check) break;
                        }

                        if(check == true)
                        {
                            if (count == size-1) list.Add(0);
                            else
                            {
                                for (int k = i; k < i + 1; k++)
                                {
                                    for (int p = count + 1; p < size; p++)
                                    {
                                        sum += mass[k, p];
                                    }
                                }
                                list.Add(sum);
                            }
                        }
                        else
                        {
                            list.Add(0);
                        }


                    }
                    }
                }
            foreach (int item in list)
            {
                Console.WriteLine(item);
            }

        }
    }
}
