using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingArray
{
    class Program
    {
        static double[] GetRandomArr(uint length, int minVaule, int maxVaule, int precision)
        {
            double[] arr = new double[length];
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
                arr[i] = Math.Round(rnd.NextDouble() * (maxVaule - minVaule) + minVaule, precision);
            return arr;
        }
        static void WriteArray(double[] arr,string text ="")
        {
            Console.WriteLine(text +" Array is :");
            for (int i = 0; i < arr.Length; i++)
                Console.Write("arr[{0}]= \"{1}\"\n", i, arr[i]);
        }
        static void ConsoleConfig(string title)
        {
            Console.Title = title;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            // Console.OutputEncoding = Encoding.GetEncoding(1251); // може буть несумісність кодувань
        }
        static double [] BulbSort (double [] array)
       {
        double temp = 0;
        double [] arr= (double []) array.Clone();
            bool ws=true;
           while(ws)
            {
                ws = false;
                for(int j=0;j<arr.Length-1;j++)
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        ws = true;
                    }

            }
        return arr;
    }
        static double[] InputSort(double[] array)
        {
            double[] arr = (double[])array.Clone();
            double temp = 0;int j = 0;
            for (int i=1; i < arr.Length; i++)
            {
               
               temp = arr[i];
               j = i;
               while (j > 0 && arr[j - 1] > temp)
               {
                   arr[j] = arr[j - 1];
                   j = j - 1;
               }

               arr[j] = temp;
            }
            return arr;
        }
        static double[] Choise(double[] array)
        {
            double[] arr = (double[])array.Clone();
            double temp = 0;
            for (int j = 0; j < arr.Length - 1; j++)
            {
                double min = arr[j];
                int min_el = j;
                for (int i = j; i < arr.Length; i++)
                {
                    if (min > arr[i]) { min = arr[i]; min_el = i; }
                }
                temp = arr[j];
                arr[j] = arr[min_el];
                arr[min_el] = temp;
            }
            return arr;
        }
        /*static double[] ShellsSort(double[] array)
        {
            double[] arr = (double[])array.Clone();

        }*/

        static void Main(string[] args)
        {
            
            ConsoleConfig("Сортування масиву");
            Console.Write("Введіть довжину масиву");
            uint n = uint.Parse(Console.ReadLine());
            double[] arr = GetRandomArr(n, -20, 10, 1);
            WriteArray(arr,"Згенерований");
            double[] arr1 = BulbSort(arr);
            WriteArray(arr1,"Відсортований бульбашкою");
            double[] arr2 = InputSort(arr);
            WriteArray(arr2,"Відсортований вставкою");
            double[] arr3 = Choise(arr);
            WriteArray(arr3,"Відсортований вибором");


            Console.ReadKey();

        }
    }
}
