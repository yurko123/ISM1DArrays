using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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
        static void QickSort(double[] arr,int begin,int end)
        {
            if (begin >= end) return;
            double mediana = 0,temp=0;
            int i=begin+1,j=end-1;
            while (i < j)
            {

                while (arr[i] <= mediana)
                { i++; if (i > arr.Length-1) break; }
               
                while (arr[j] >= mediana)
                { j--; if (j <1) break; }
                if (i < j)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            
                temp = arr[begin];
                arr[begin] = arr[j];
                arr[j] = temp;
            
            
            QickSort(arr,begin,j);
            QickSort(arr,j+1,end);

            }
        static double[] ShellsSort(double[] array)
        {
            double[] arr = (double[])array.Clone();
            double temp =0;
            
            for (int d = (arr.Length / 2)-1; d > 0; d /= 2)
           
                for (int i = d; i < arr.Length; i += 1)
                {
                    if(arr[i-d]>arr[i]) 
                    {
                        temp=arr[i-d];
                        arr[i-d]=arr[i];
                        arr[i]=temp;
                    }

                }

         return arr;
        }

        static void Main(string[] args)
        {
            
            ConsoleConfig("Сортування масиву");
            Console.Write("Введіть довжину масиву ");
            uint n = uint.Parse(Console.ReadLine());
            Stopwatch time = new Stopwatch();
            time.Start();
            double[] arr = GetRandomArr(n, -20, 10, 0);
            time.Stop();
            WriteArray(arr,"Згенерований за "+time.Elapsed +"\n");
            
            time.Restart();
            double[] arr1 = BulbSort(arr);
            time.Stop();
            WriteArray(arr1, "Відсортований бульбашкою за " + time.Elapsed + "\n");
            time.Restart();
            double[] arr2 = InputSort(arr);
            time.Stop();
            WriteArray(arr2, "Відсортований вставкою за " + time.Elapsed + "\n");
            time.Restart();
            double[] arr3 = Choise(arr);
            time.Stop();
            WriteArray(arr3, "Відсортований вибором за " + time.Elapsed + "\n");
             time.Restart();
            double[] arr4 = ShellsSort(arr);
            time.Stop();
            WriteArray(arr4, "Відсортований методом Шелла за " + time.Elapsed + "\n");
            time.Restart();
            double[] arr5 = (double[])arr.Clone();
            QickSort(arr5, 0, arr5.Length);
            time.Stop();
            WriteArray(arr5, "Відсортований швидким сортуванням за " + time.Elapsed + "\n");
            time.Restart();
            double[] arr6 = (double[])arr.Clone();
            Array.Sort<double>(arr6);
            time.Stop();
            WriteArray(arr6, "Відсортований сортуванням .NET за " + time.Elapsed + "\n");

            Console.ReadKey();

        }
    }
}
