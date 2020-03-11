using System;

namespace SharpLabs
{
    class Program
    {
        static void Main(string[] args)
        {
            Еquation test1= new Еquation(3,3,2);
            Еquation test2 = new Еquation(2,4,1);
            test1.Multiplication(test2);
            
        }
        static void Lab_1()
        {
            double m = 10;
            double z1, z2;
            z1 = Math.Sqrt(Math.Pow(3 * m + 2, 2) - 24 * m) / (3 * Math.Sqrt(m) - 2 / Math.Sqrt(m));
            z2 = -Math.Sqrt(m);
            Console.WriteLine(z1);
            Console.WriteLine(z2);
        }
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
        static void Lab_31()
        {
            for(double i =-5;i<=5; i+=0.5f)
            {
                Lab_2(i);
            }
        }
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
    }
    class Еquation
    {
        double a, b, c, x;


        double degree; // Степень многочлена
        public Еquation(double a,double b,double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public void Show()
        {
            Console.WriteLine($"{a}x^2+{b}x+{c}");
        }
        public void Result(double x)
        {
            Console.WriteLine($"Значение многочлена:{a*Math.Pow(x,2)+b*x+c}");
        }
        public Еquation Addition(Еquation B)
        {
            Еquation temp = new Еquation(0,0,0);
            temp.a=a + B.a;
            temp.b=b + B.b;
            temp.c=c + B.c;
            return temp;
        }
        public Еquation Subtraction(Еquation B)
        {
            Еquation temp = new Еquation(0, 0, 0);
            temp.a = a - B.a;
            temp.b = b - B.b;
            temp.c = c - B.c;
            return temp;
        }
        public void Multiplication(Еquation B)
        {
            Console.WriteLine($"{a*B.a}x^4 + {B.a*b + a * B.b}x^3 +{}");
        }
    }
}
