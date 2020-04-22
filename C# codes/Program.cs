using System;
using System.Runtime.CompilerServices;

namespace SharpLabs
{


    class Program
    {
        static void Main(string[] args)
        {
            float[] array = {3.5f, 1.4f, -2f, 7f};
            ShowArray(array);
            CountNegativeElements(array);
            SumAfterFirstElement(array);
            СhangeNegativeElements(array);
            ShowArray(array);
            

        }
        #region 1 lab
        static void Lab_1()
        {
            double m = 10;
            double z1, z2;
            z1 = Math.Sqrt(Math.Pow(3 * m + 2, 2) - 24 * m) / (3 * Math.Sqrt(m) - 2 / Math.Sqrt(m));
            z2 = -Math.Sqrt(m);
            Console.WriteLine(z1);
            Console.WriteLine(z2);
        }
        #endregion 
        #region 2 lab
        static void Lab_2(double x)
        {
            double y;
            int R = 2;
            if(x>=-5 && x<=-3)
            {
                y = 1;
                //Console.WriteLine("X="+x+ " Y="+y);
                Console.WriteLine(FormattableString.Invariant($"x = {x} y = {y}"));
            }
            if (x >= -3 && x <= -1  )
            {
                y = Math.Sqrt(Math.Pow(R, 2) - Math.Pow(x + 1, 2));
                y *= -1;
                Console.WriteLine(FormattableString.Invariant($"x = {x} y = {y}"));
            }
            else if(x>=-1 && x<=2)
            {
                y = -2;
                Console.WriteLine(FormattableString.Invariant($"x = {x} y = {y}"));
            }
            else if (x >= 2 && x <= 5)
            {
                y = x-4;
                Console.WriteLine(FormattableString.Invariant($"x = {x} y = {y}"));
            }
        }
        #endregion  
        #region 2.1 lab
        static bool Lab_21(double x,double y)
        {
            int R = 4;
            if ((x > -R && x < R) && (y > -R && y < R))
            {
                if ((Math.Sqrt(Math.Pow(x + R, 2) + y * y)) <= R && y > 0)
                {
                    return true;
                }
                else if ((Math.Sqrt(Math.Pow(x - R, 2) + y * y)) <= R && y < 0)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion  
        #region 3.1 lab
        static void Lab_31()
        {
            for(double i =-5;i<=5; i+=0.5f)
            {
                Lab_2(i);
            }
        }
        #endregion  
        #region 3.2 lab
        static void Lab_32()
        {
            double x, y;
            for(int i=0;i<10;i++)
            {
                Console.WriteLine("Введите х:");
                x= Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите y:");
                y = Convert.ToDouble(Console.ReadLine());
                if(Lab_21(x,y))
                {
                    Console.WriteLine("Есть попадание!");
                }
                else Console.WriteLine("Промах");
            }
        }
        #endregion

        #region 5 lab

        static void CountNegativeElements(float[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length-1; i++)
            {
                if (array[i] < 0) count++;
            }
            Console.WriteLine();
            Console.WriteLine($"Отрицательных элементов: {count}");
        }

        static void SumAfterFirstElement(float[] array)
        {
            int index=0;

            for (int i = 0; i < array.Length-1; i++) // Поиск минимального элемента по модулю
            {
                if (Math.Abs(array[i]) < Math.Abs(array[i + 1])) index = i;
                else index = i + 1;
            }
            float sum = 0;
            for (int i = index; i < array.Length; i++)
            {
                sum += Math.Abs(array[i]);
            }
            Console.WriteLine($"Сумма модулей элемента : {sum}");
        }

        static void ShowArray(float[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"|{array[i]}| ");
            }
        }

        static void СhangeNegativeElements(float[] array)
        {
            for (int i = 0; i < array.Length-1; i++)
            {
                if (array[i] < 0) array[i] *= array[i];
            }
        }

        #endregion

    }
    #region 4 lab
    class Еquation
    {
        double a, b, c, x;
        public Еquation(double a,double b,double c) // Стандартный констуктор класса Еquation
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public void Show() // Вывод многочлена
        {
            Console.WriteLine($"{a}x^2+{b}x+{c}");
        }
        public void Result(double x) // Вывод значения многочлена
        {
            Console.WriteLine($"Значение многочлена:{a*Math.Pow(x,2)+b*x+c}");
        }
        public static Еquation operator -(Еquation equation1,Еquation equation2)// Оператор вычитания многочлена
        {
            Еquation temp = new Еquation(0, 0, 0);
            temp.a = equation1.a - equation2.a;
            temp.b = equation1.b - equation2.b;
            temp.c = equation1.c - equation2.c;
            return temp;
        }
        public static Еquation operator +(Еquation equation1,Еquation equation2) // Оператор суммы многочлена
        {
            Еquation temp = new Еquation(0, 0, 0);
            temp.a = equation1.a + equation2.a;
            temp.b = equation1.b + equation2.b;
            temp.c = equation1.c + equation2.c;
            return temp;
        }
    }
    #endregion
}
