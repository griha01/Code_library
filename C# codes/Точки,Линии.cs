using System;
using System.Linq;
using System.Threading.Channels;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
          ColoredPoint p = new ColoredPoint(5,2,"Red");
          Point obj = new ColoredPoint(1,2,"Green");
          obj.Info();
        }
    }

    class Point
    {
        public float x { get; set; }
        public float y { get; set; }

        public Point()
        {
            x = 0;
            y = 0;
        }

        public Point(float x,float y)
        {
            this.x = x;
            this.y = y;
        }

        public virtual void Info()
        {
            Console.WriteLine($"X: {x} Y: {y}");
        }
    }

    class ColoredPoint : Point
    {
        private string color{ get; set; }

        public ColoredPoint()
        {
            color = "None";
        }

        public ColoredPoint(float x,float y,string color): base(x,y)
        {
            this.color = color;
        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine($"Color: {color}");
        }
    }

    class Line
    {
        private Point p1;
        private Point p2;

        public Point GetPointA => p1;
        public Point GetPointB => p2;

        public Line()
        {
            p1 = new Point();
            p2 = new Point();
        }

        public Line(float a , float b , float c , float d)
        {
            p1 = new Point(a,b);
            p2 = new Point(c,d);
        }

        public virtual void Info()
        {
            Console.WriteLine($"PointA({p1.x},{p1.y}");
            Console.WriteLine($"PointA({p2.x},{p2.y}");
        }
    }

    class ColoredLine : Line
    {
        private Point p1;
        private Point p2;
        private string color;
        public Point GetPointA => p1;
        public Point GetPointB => p2;

        public ColoredLine() 
        {
            p1 = new Point();
            p2 = new Point();
            
        }

        public ColoredLine(float a , float b , float c , float d,string color) : base(a,b,c,d)
        {
            p1 = new Point(a,b);
            p2 = new Point(c,d);
        }

        public override void Info()
        {
            Console.WriteLine($"PointA({p1.x},{p1.y}");
            Console.WriteLine($"PointA({p2.x},{p2.y}");
        }
    }

    class Polyline
    {
        
    }
}
