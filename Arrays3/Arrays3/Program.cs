using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays3
{
    public class Program
    {
         static  double[] GetRandomArr(uint length,int minVaule,int maxVaule,int precision)
            { double[] arr=new double [length];
               Random rnd=new Random();
               for(int i=0;i<arr.Length;i++)
                arr[i]=Math.Round(rnd.NextDouble()*(maxVaule-minVaule)+minVaule,precision);
             return arr;
            }
         static void WriteArray(double[] arr)
         {
             Console.WriteLine("Array is :");
             for (int i = 0; i < arr.Length; i++)
                 Console.Write("arr[{0}]= \"{1}\"\n", i, arr[i]);
         }
         static void ConsoleConfig(string title)
         {
             Console.Title=title;
             Console.BackgroundColor = ConsoleColor.White;
             Console.Clear();
             Console.ForegroundColor = ConsoleColor.Black;
            // Console.OutputEncoding = Encoding.GetEncoding(1251); // може буть несумісність кодувань
         }
         static double SumNegative(double[] arr)
         {
             double sum = 0;
             for (int i = 0; i < arr.Length; i++)
                 if (arr[i] < 0) sum += arr[i];
             return sum;
         }
         static double MaxOfArr(double[] arr)
         {
             double max = arr[0];
             for(int i=1;i<arr.Length;i++)
             if(max<arr[i]) max=arr[i];
             return max;
         }
         static string indexMaxOfArr(double[] arr)
         {
             double max = arr[0];
             string num = "";
             int indexMax=0;
             for (int i = 1; i < arr.Length; i++)
              if (max < arr[i]) { max = arr[i]; indexMax = i; }
             for (int i = indexMax; i < arr.Length; i++)
              if (Math.Abs(arr[i] - max) < 1e-5) num += "Номер (індекс) максимального елемента масиву: "+i+"\n"; 
             return num;
         }
         static double AbsMaxOfArr(double[] arr)
         {
             double max = Math.Abs(arr[0]);
             for (int i = 1; i < arr.Length; i++)
                 if (max < Math.Abs(arr[i])) max = Math.Abs(arr[i]);
             return max;
         }
         static int SumIndexPositive(double[] arr)
        {   int SumPositive=0;
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] > 0) SumPositive += i;
        return SumPositive; 
         }
         static int NumOfInteger(double[] arr)
         {   int l=-1;
             for (int i = 0; i < arr.Length; i++)
             {
                 if (arr[i] - (int)arr[i] == 0) l++; 
             }
             return l;
         }
         static double ProductAfterMin(double[] arr)
         {
             int min_el = 0;
             double min = arr[0];
             for (int i = 1; i < arr.Length; i++)
             {
                 if (min > arr[i])
                 {
                     min = arr[i];
                     min_el = i;
                 }
             }
             double product_after_min = 1;
             for (int i = min_el + 1; i < arr.Length; i++)
                 product_after_min *= arr[i];
             return product_after_min;
         }
         static string SumAtNegativeAndPositive(double[] arr)
         {
             int l = 0, first_negative = -1, second_positive = -1,i = 0,a=0,b=0;
             double sum = 0;
             for (;i < arr.Length; i++)
                 if (arr[i] < 0)
                 {
                     l++;
                     first_negative = i + 1;
                     if (l == 1) break; 
                     
                 }

             i = 0; l = 0; 
             for (; i < arr.Length; i++)
                 if (arr[i] > 0)
                 {
                     l++;
                     second_positive = i;
                     if (l == 2) break;
                     
                 }
             if (first_negative==-1 && second_positive == -1) return "Відсутні відємні i дотатні числа!";
             if (first_negative == -1) return "Відсутні відємні числа!";
             if (second_positive == -1||l<2) return "Відсутнє друге дотатнє число!";
             a= Math.Min(first_negative, second_positive);
             b = Math.Max(first_negative, second_positive);
             
             for (; a <b; a++)
                 sum += arr[a];
             return ""+sum;
            
         }
         static string DoubleZeroSum(double[] arr)
         {
             int last_zero = -1, first_zero = -1,i=0 ;

             
             for (; i < arr.Length ; i++)
                 if (Math.Abs(arr[i]) < 1e-15)
                 { first_zero = i+1; break; }


             for (i = arr.Length- 1; i > first_zero; i--)
                 if (Math.Abs(arr[i]) < 1e-15) 
                 { last_zero = i ; break; }
             if (last_zero == -1 || first_zero == -1) return "Відсутні нулі або він один !";
            double sum =0;
             for (i = first_zero; i < last_zero; i++)
                 sum += arr[i];
             return "Сума елементів масиву, які розташовані між першим і останнім нульовими елементами: " + sum;
         }
         static double ProductAtAbs(double[] arr)
         {
             double min_abs = Math.Abs(arr[0]), max_abs = Math.Abs(arr[0]);
             int el_min_abs = 0, el_max_abs = 0;
             int i;
             for (i = 1; i < arr.Length; i++)
                 if (Math.Abs(arr[i]) > max_abs) { max_abs = Math.Abs(arr[i]); el_max_abs = i; }
             for(i=arr.Length-1;i>0;i--)
                 if (Math.Abs(arr[i]) < min_abs) { min_abs = Math.Abs(arr[i]); el_min_abs = i; }
             double product = 1;
             int a = Math.Min(el_min_abs, el_max_abs);
             int b = Math.Max(el_min_abs, el_max_abs);
             for (i = a + 1; i < b; i++)
                 product *= arr[i];
             return product;
         }
         static void Main(string[] args)
        {   ConsoleConfig("Опрацювання масивів");
            Console.Write("Введіть довжину генерованого масиву: ");
             uint n=uint.Parse(Console.ReadLine());
             double[] arr = GetRandomArr(n,-20,10,1);
             WriteArray(arr);
            // Arrays 1 Func
             double sum_negative=SumNegative(arr);
             if (Math.Abs(sum_negative)>1e-15) Console.WriteLine("Сумма від`ємних елементів масиву: {0}", sum_negative);
             else Console.WriteLine("Від`ємні елементи відсутні");
             Console.WriteLine( "Максимальний елемент масиву: "+MaxOfArr(arr));
             Console.WriteLine(indexMaxOfArr(arr));
             Console.WriteLine("Максимальний елемент масиву по модулю: " + AbsMaxOfArr(arr));
             int Sum=SumIndexPositive(arr);
             Console.WriteLine("Сума індексів додатних елементів :" + Sum );
             Sum = NumOfInteger(arr);
             if (Sum == -1) Console.WriteLine("Цілі числа відсутні");
             else Console.WriteLine("Кількість цілих чисел у масиві :" + (Sum + 1));
             // Arrays 2 Func
             Console.WriteLine("добуток елементів масиву, що розташовані після мінімального елемента: {0};",ProductAfterMin(arr));
             Console.WriteLine("Cума елементів масиву, що розташовані між першим від'ємним та другим додатним елементами: {0};", SumAtNegativeAndPositive(arr));
             Console.WriteLine(DoubleZeroSum(arr));
             Console.WriteLine("добуток елементів масиву, що розташовані між максимальним за модулем і мінімальним за модулем елементами: {0};",ProductAtAbs(arr));
             Console.ReadKey();
              
        }

    }
}

