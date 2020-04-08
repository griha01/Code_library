using System;
using System.Threading.Channels;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector a = new Vector();
            Vector b = new Vector(6);
            Vector c = new Vector(1,2,4);
            Vector d = new Vector(3,7,8);
            Vector e = new Vector(2,8,2,4,6,8);
            Vector f = new Vector(8,4,8);

            try
            {
                Console.WriteLine(c+d);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
            Console.WriteLine("the end");
        }
    }

    class Vector
    {
        private int[] array;
        private int length;

        public Vector(int size)
        {
            array = new int[size];
            length = size; 
        }
        public Vector()
        {
            array = new int[1];
            length = 1;
        }
        public Vector(params int[] array)
        {
            this.array = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                this.array[i] = array[i];
            }
            length = array.Length;
        }

        public int this[int i]
        {
            get
            {
                if (i >= 0 && i < length)
                {
                    return array[i];
                }
                else throw new IndexOutOfRangeException();
            }
            set
            {
                if (i >= 0 && i < length)
                {
                    array[i] = value;
                }
                else throw new IndexOutOfRangeException();
            }
        }

        public static Vector operator +(Vector a, Vector b)
        {
            if (a.length == b.length)
            {
                Vector temp = new Vector(a.length);
                for (int i = 0; i < a.length; i++)
                {
                    temp[i] = a[i] + b[i];
                }
                return temp;
            }
            else throw new Exception("Different size");
        }
        public static Vector operator -(Vector a, Vector b)
        {
            if (a.length == b.length)
            {
                Vector temp = new Vector(a.length);
                for (int i = 0; i < a.length; i++)
                {
                    temp[i] = a[i] - b[i];
                }
                return temp;
            }
            else throw new Exception("Different size");
        }
        public static Vector operator *(Vector a, int x)
        {
            Vector temp = new Vector(a.length);
            for (int i = 0; i < a.length; i++)
            {
                temp[i] = a[i] * x;
            }
            return temp;
        }
        public static Vector operator /(Vector a, int x)
        {
            Vector temp = new Vector(a.length);
            for (int i = 0; i < a.length; i++)
            {
                temp[i] = a[i] / x;
            }
            return temp;
        }

        public void Print()
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }

        public override string ToString()
        {
            string temp = String.Empty;
            for (int i = 0; i < array.Length; i++)
            {
                temp += array[i] + " ";
            }
            return temp;
        }
    }
}
