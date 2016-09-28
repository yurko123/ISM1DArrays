using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Arrays2";
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.OutputEncoding = Encoding.GetEncoding(1251);
            Console.Write("Введіть довжину масиву випадкових чисел: ");
            int n = int.Parse(Console.ReadLine());
            double [] arr = new double[n];
            int i=0;
            Random rnd = new Random();
            for (; i < n; i++)
            {
               arr[i] = /*rnd.NextDouble() **/ rnd.Next(-100, 101);
                Console.Write(arr[i] + (i == n - 1 ? "\n" : ", "));
            }
            int min_el=0;
            double min=arr[0];
            for (i = 1; i < n; i++)
            {
                if (min > arr[i])
                {
                    min = arr[i];
                    min_el = i;
                }
            }
            double product_after_min = 1;
            for(i=min_el+1 ; i<n;i++)
                product_after_min *= arr[i];
            Console.WriteLine("добуток елементів масиву, що розташовані після мінімального елемента: {0};", product_after_min);
            int first_negative = 0, second_positive = 0,l=0;
            double sum = 0;
            i = 0;
            for (; l == 1 ^ i < n; i++)
                if (arr[i] < 0) l++;
            first_negative = i;
            i = 0;l=0;
            for (; l==2^ i < n; i++)
                if (arr[i] > 0) l++;
            second_positive=i-1;
            first_negative = Math.Min(first_negative, second_positive);
            second_positive = Math.Max(first_negative, second_positive);
            Console.WriteLine("{0} {1}", first_negative, second_positive);
            for (; first_negative < second_positive; first_negative++)
                sum += arr[first_negative];
            
            Console.WriteLine("сума елементів масиву, що розташовані між першим від'ємним та другим додатним елементами: {0};", sum);
            int last_zero = 0,first_zero=0;

            for (i = n - 1; (i > 0 ? arr[i] != 0 : false); i--) ; 
                 last_zero = i-1;
            for (i = 0; (i < n ? arr[i] != 0 : false); i++) ;
            first_zero = i;
            //Console.WriteLine("{0} {1}", first_zero, last_zero);
            sum = 0;
            for (i = first_zero; i < last_zero; i++)
                sum += i;
            Console.WriteLine("сума елементів масиву, які розташовані між першим і останнім нульовими елементами: {0};", sum);

            double min_abs = Math.Abs(arr[0]), max_abs = Math.Abs(arr[0]);
            int el_min_abs=0,el_max_abs=0;
            for(i=1;i<n;i++)
            {
                if (Math.Abs(arr[i]) > max_abs) { max_abs = Math.Abs(arr[i]); el_max_abs = i; }
                if (Math.Abs(arr[i]) < min_abs) { min_abs = Math.Abs(arr[i]); el_min_abs = i; }
            }
           
            double product = 1;
            //Console.WriteLine("{0} {1}", el_max_abs, el_min_abs);
            int a=Math.Min(el_min_abs,el_max_abs);
            int b=Math.Max(el_min_abs,el_max_abs);
            for (i=a+1 ;i< b; i++)
                product *= arr[i];
            Console.WriteLine("добуток елементів масиву, що розташовані між максимальним за модулем і мінімальним за модулем елементами: {0};", product);

             
            Console.ReadKey();

        }
    }
}
