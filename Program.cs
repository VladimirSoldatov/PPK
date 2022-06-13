using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PPK
{
    class Program
    {
        class PointArrayInumerator : IEnumerator<PointXY>
        {
            public PointArrayInumerator(PointXY[] pointArray)
            {
                array = pointArray;
            }
            PointXY[] array;
            int position = -1;
    

            PointXY IEnumerator<PointXY>.Current 
            {
                get
                {
                    if (position == -1 || position >= array.Length)
                        throw new ArgumentException();
                    return array[position];
                }
            }

            public object Current => throw new NotImplementedException();

            public bool MoveNext()
            {
                if (position < array.Length - 1)
                {
                    position++;
                    return true;
                }
                else
                    return false;
            }

            public void Reset() => position = -1;

            public void Dispose()
            {
 
            }
        }
        class PointXY:IComparable
        {
            public int X { get; set; }
            public int Y { get; set; }
            public static PointXY operator ++(PointXY s)
            {
                s.X++;
                s.Y++;
                return s;
            }
            public static PointXY operator --(PointXY s)
            {
                s.X--;
                s.Y--;
                return s;
            }
            public static PointXY operator - (PointXY s)
            {
                return new PointXY { X = -s.X, Y = -s.Y };

            }
            public static PointXY operator- (PointXY s, int width)
            {
                s.X -= width;
                return s;

            }
            public static PointXY operator +(PointXY s, PointXY t)
            {
                s.X += t.X;
                s.Y += t.Y;
                return s;

            }
            public override string ToString()
            {
                return $"Объект имеет координаты: {X} по оси Х, {Y} по оси Y\n";
            }

            public int CompareTo(object obj)
            {
                if (this.X > ((PointXY)obj).X)
                    return 1;
                else if (this.X == ((PointXY)obj).X)
                    return 0;
                else
                    return -1;
            }

            public IEnumerator GetEnumerator()
            {
                throw new NotImplementedException();
            }

            public static string operator >(PointXY s, PointXY t)
            {
                if (s.X > t.X && s.Y > t.Y)
                    return "Да, значение слева больше";
                else if (s.X == t.X && s.Y == t.Y)
                    return "Объекты равны";
                else if (s.X < t.X && s.Y < t.Y)
                    return "Нет, оьъектв слева меньше";
                else
                    return "ЭХЗ";

            }
            public static string operator <(PointXY s, PointXY t)
            {
                if (s.X < t.X && s.Y < t.Y)
                    return "Да,  значение слева меньше";
                else if (s.X == t.X && s.Y == t.Y)
                    return "Обекты равны";
                else if (s.X > t.X && s.Y > t.Y)
                    return "Нет, значение слева меньше";
                else
                    return "ЭХЗ";

            }
        }
        class ArrayPoint:IEnumerable
        {
            public PointXY[] pointArray { get; set; }
            public ArrayPoint(PointXY[] tmp) => this.pointArray = tmp;

            public ArrayPoint()
            {
                pointArray = new PointXY[0];
            }

            public ArrayPoint Add(PointXY tmp)
            {
                //if (pointArray.Length > 0)
                


                    PointXY[] tpmArray = new PointXY[pointArray.Length + 1];
                    for (int i = 0; i < pointArray.Length; i++)
                    {
                        tpmArray[i] = pointArray[i];
                    }
                tpmArray[tpmArray.Length - 1] = tmp;
                    pointArray = tpmArray;


                    return this;
                
            }
            public IEnumerator<PointXY> GetEnumerator() => new PointArrayInumerator(pointArray);
            

            IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();


        }
        static void Main(string[] args)
        {
            PointXY point = new PointXY { X = 10, Y = 10 };
            PointXY point2 = new PointXY { X = -5, Y = 15 };
          /*  WriteLine($"Исходная точка\n{point.ToString()}");
            WriteLine(point2);
            //WriteLine("Префиксная и постфиксная формы " +
            //    "инкремента выполняются одинаково");
           // WriteLine(point + point2);
            WriteLine(point > point2);
            WriteLine(point.CompareTo(point2));*/
            ArrayPoint pointXies = new ArrayPoint();
            pointXies.Add(point);
            pointXies.Add(point2);
            foreach(var item in pointXies)
            {
                WriteLine($"{item}");
            }
           string[] money = {"10" };
            object f = (object)money;

            string[] othermoney = f as string[];
            if (othermoney == null)
            {
                WriteLine("Не удалось");
            }
            else
            {
                othermoney = othermoney.Append("20").ToArray();
            }
            for (int i = 0; i<othermoney.Length; i++)
            {
                WriteLine(othermoney[i]);
            }
            
        }
    }
}
