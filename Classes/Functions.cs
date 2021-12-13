using System;
using System.Drawing;

namespace Graph_Converter.Classes
{
    interface IFunctionGraphPoints
    {
        Point[] GetGraphPoints(int boxWidth);
    }
    abstract class Functions : IFunctionGraphPoints
    {
        abstract public Point[] GetGraphPoints(int boxWidth);
    }
    class Sinusoid : Functions
    {
        public override Point[] GetGraphPoints(int boxWidth)
        {
            Point[] functionPoints = new Point[boxWidth];
            for (int i = 0; i < functionPoints.Length; ++i)
            {
                int y = (int)(Math.Sin((double)i / 10) * 100) + 120;
                functionPoints[i] = new Point(i + 32, y > 240 ? 240 : y);
            }
            return functionPoints;
        }
    }
    class Cosinusoid : Functions
    {
        public override Point[] GetGraphPoints(int boxWidth)
        {
            Point[] functionPoints = new Point[boxWidth];
            for (int i = 0; i < functionPoints.Length; ++i)
            {
                int y = (int)(Math.Cos((double)i / 10) * 100) + 120;
                functionPoints[i] = new Point(i + 32, y > 240 ? 240 : y);
            }
            return functionPoints;
        }
    }
    class SquareRoot : Functions
    {
        public override Point[] GetGraphPoints(int boxWidth)
        {
            Point[] functionPoints = new Point[boxWidth];
            for (int i = 0; i < functionPoints.Length; ++i)
            {
                int y = (int)(Math.Sqrt((double)i * 20)) + 120;
                functionPoints[i] = new Point(i + 32, y > 240 ? 240 : y);
            }
            return functionPoints;
        }
    }
}
