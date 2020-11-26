using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp15
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[5];
            int n = 10; // задати значення n
            float[] A = new float[n];
            float sum; // результат - сума елементів масиву
            float avg;  // результат - середнє арифметичне
            // заповнення масиву A 
            for (int i = 0; i < n; i++)
                A[i] = 0.1f * i;

            // спочатку занулити значення sum
            sum = 0;

            // цикл обчислення суми
            for (int i = 0; i < n; i++)
                sum = sum + A[i];
            avg = sum / n;  // обчислення середнього арифметичного
            for (int i = 0; i < n; i++)
{
                int element = array[i];
               
                if (element % 2 == 1)
                {
                    Console.WriteLine(element);
                }
            }
            int maxValue = array.Max();
            int minValue = array.Min();

            Console.Read();

        }
    }
}

