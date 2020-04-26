using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace SharpLabs
{


    class Program
    {
        static void Main(string[] args)
        {
            #region 5 lab var 16
            // float[] array = {3.5f, 1.4f, -2f, 7f};
            // ShowArray(array);
            // CountNegativeElements(array);
            // SumAfterFirstElement(array);
            // СhangeNegativeElements(array);
            // ShowArray(array);
            #endregion
            #region 6 lab var 16
            // int[,] squareArray = new int[5, 5];
            // FillSquareArray(squareArray);
            // ShowSquareArray(squareArray);
            // RegularizeSquareArray(squareArray);
            // Console.WriteLine();
            // ShowSquareArray(squareArray);
            // SearchNotNegativeColumn(squareArray);
            #endregion

            #region 7 lab var 16

            //lab_7();

            #endregion

            #region 8 lab var 16
            
            // Station station = new Station(new Train[] {
            //     new Train("Москва", "1B", 86400), // 00:00:00
            //     new Train("Владивосток", "2D", 86399) // 23:59:59
            // });
            //  station.ShowTrainInfo(1);
            // station.ShowTrainsAfterTime(86391);
            // station.ShowTrainsDestinationInfo("Москва");
            #endregion

        }
        #region 1 lab var 17
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
        #region 2 lab var 17
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
        #region 2.1 lab var 17
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

        #region 5 lab var 16

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
            BubbleSort(array);
        }
        static void BubbleSort(float[] array) 
        {
            for (int i = 0;i < array.Length - 1;i++) {
                for (int j = array.Length - 1;j > i;j--) {
                    if (array[j] < array[j - 1])
                    {
                        (array[j - 1], array[j]) = (array[j], array[j - 1]);
                    }
                }
            }
        }

        #endregion

        #region 6 lab var 16

        static void ShowSquareArray(int[,] array) // вывод массива
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                   Console.Write("{0,4}", array[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void FillSquareArray(int[,] array) //Заполнение массива случайными числами
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = new Random().Next(-10,10);
                }
            } 
        }

        static void RegularizeSquareArray(int[,] array) // Упорядочить по количеству одинаковых элементов
        {
            int[] countRepeat = new int[array.GetLength(1)];
            for (int i = 0; i < countRepeat.Length; i++)
            {
                countRepeat[i] = CountRepeatElements(array, i);
            }

            for (int i = 0; i < countRepeat.Length; i++) // Вывод количества одинаковых чисел в матрице через запятаую ( первая число - первая строка)
            {
                Console.Write($"{countRepeat[i]} ");
            }
            SquareArrayBubbleSort(countRepeat,array); 
        }

        static int CountRepeatElements(int[,] array,int line) // Подсчет количества одинаковых цифр
        {
            int count = 0;
            int temp = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                temp = 0;
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    if (array[line,i] == array[line,j]) temp++;
                }

                if (temp > count)
                {
                    count = temp;
                }
            }
            return count;
        }

        static void ReplaceArrayLines(int[,] array, int first, int second)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                (array[first, i], array[second, i]) = (array[second, i], array[first, i]);
            }
        }  // Поменять местами строки массив
        static void SquareArrayBubbleSort(int[] numbers,int[,]array) 
        {
            for (int i = 0;i < numbers.Length - 1;i++) {
                for (int j = numbers.Length - 1;j > i;j--) {
                    if (numbers[j] < numbers[j - 1])
                    {
                        (numbers[j - 1], numbers[j]) = (numbers[j], numbers[j - 1]);
                        ReplaceArrayLines(array,j,j-1);
                    }
                }
            }
        } // Сортировка

        static void SearchNotNegativeColumn(int[,] array) //Поиск столбца без отрицательных элементов
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    if (array[j, i] >= 0)
                    {
                        count++;
                    }
                }
                if (count == array.GetLength(0))
                {
                    Console.WriteLine($"Столбец под номером {i} не содержит отрицательных элементов");
                    break;
                }
            }
        }
        #endregion

        #region 7 lab var 16

        static void lab_7()
        {
            string str;
            using (var stream = new StreamReader("B:/test.txt", Encoding.Default)) // путь к файлу
            {
                str = stream.ReadToEnd();
            }
            Regex regex = new Regex(@"[A-ZА-ЯЁ][^!?.]+[.?!]");
            List<string> strings = new List<string>();
            foreach (Match item in regex.Matches(str))
            {
                strings.Add(item.Value);
            }
            foreach (string item in strings.OrderBy((x) => !x.EndsWith("?")))
            {
                Console.WriteLine(item);
            }
        }
        

        #endregion
    
    }
    #region 4 lab var 10 // Вы разрешили сменить вариант
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

    #region 8 lab var 16

    class Train
    {
        public string StationName { get; private set; }
        public string TrainNumber { get; private set; }
        public int Time { get; private set; } // В секундах . В сутках 86400 секунд

        public Train(string stationName,string trainNumber,int time)
        {
            StationName = stationName;
            TrainNumber = trainNumber;
            if (time >= 0 && time < 86400) Time = time;
            else Time = 0;
        }

        public string ShowTime(int time)
        {
            int hours, minutes, seconds = 0;
            hours = (int)Math.Truncate((double)time / 3600); // часы 
            time -= hours * 3600;
            minutes = (int) Math.Truncate((double) time / 60);
            if (time%60!=0)
            {
                time -= minutes * 60;
                seconds = time;
            } 
            return $"{hours} ч. {minutes} мин. {seconds} сек.";
        }

        public static bool operator >(Train train1, Train train2)
        {
            return train1.Time > train2.Time;
        }

        public static bool operator <(Train train1, Train train2)
        {
            return train1.Time < train2.Time;
        }
        public static bool operator==(Train train1, Train train2)
        {
            return train1.Time == train2.Time;
        }

        public static bool operator !=(Train train1, Train train2)
        {
            return !(train1 == train2);
        }
    }

    class Station
    {
        private Train[] _trains;

        public Station(Train[] trains)
        {
            _trains = trains;
        }

        public void ShowTrainInfo(int index)
        {
            Console.WriteLine($"Станция назначения: {_trains[index].StationName}");
            Console.WriteLine($"Номер поезда: {_trains[index].TrainNumber}");
            Console.WriteLine($"Время отправления: {_trains[index].ShowTime(_trains[index].Time)}");
        }
        public void ShowTrainsAfterTime(int time)
        {
            for (int i = 0; i < _trains.Length; i++)
            {
                if (_trains[i].Time > time)
                {                    
                    Console.WriteLine();
                    ShowTrainInfo(i);
                    Console.WriteLine();
                }
            }
        }

        public void TrainTimeComparison(int index1,int index2)
        {
            if(_trains[index1] > _trains[index2]) Console.WriteLine($"Поезд {_trains[index2].TrainNumber} отправляется раньше поезда {_trains[index1].TrainNumber} ");
            else if(_trains[index1] < _trains[index2]) Console.WriteLine($"Поезд {_trains[index1].TrainNumber} отправляется раньше поезда {_trains[index2].TrainNumber} ");
            else if(_trains[index1] == _trains[index2]) Console.WriteLine($"Поезда {_trains[index1].TrainNumber} и {_trains[index2].TrainNumber} имеют одинаковое время отправления");
        }

        public void ShowTrainsDestinationInfo(string station)
        {
            for (int i = 0; i < _trains.Length; i++)
            {
                if (_trains[i].StationName == station)
                {
                    ShowTrainInfo(i);
                }
            }
        }
    }
    

    #endregion
}
